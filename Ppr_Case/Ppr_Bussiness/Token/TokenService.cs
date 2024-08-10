using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Ppr_Base.Token;
using Ppr_Data.Domain;
using Ppr_Data.UnitOfWork;

namespace Ppr_Bussiness.Token;

public class TokenService : ITokenService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly JwtConfig jwtConfig;
    public TokenService(IUnitOfWork unitOfWork, JwtConfig jwtConfig)
    {
        this._unitOfWork = unitOfWork;
        this.jwtConfig = jwtConfig;
    }

    public async Task<string> GetToken(Account account)
    {
        return await GenerateToken(account);
    }

    public async Task<string> GenerateToken(Account account)
    {
        Claim[] claims = GetClaims(account);
        var secret = Encoding.ASCII.GetBytes(jwtConfig.Secret);

        JwtSecurityToken jwtToken = new JwtSecurityToken(
            jwtConfig.Issuer,
            jwtConfig.Audience,
            claims,
            expires: DateTime.Now.AddMinutes(jwtConfig.AccessTokenExpiration),
            signingCredentials: new SigningCredentials(new SymmetricSecurityKey
            (secret),
                SecurityAlgorithms.HmacSha256Signature)
        );

        string token = new JwtSecurityTokenHandler().WriteToken(jwtToken);
        return token;
    }

    private Claim[] GetClaims(Account account)
    {
        List<Claim> claims = new List<Claim>()
        {
            new Claim("AccountName", account.AccountName),
            new Claim("AccountId", account.Id.ToString()),
            new Claim(ClaimTypes.Role, account.AccountRole.ToString()),
            new Claim("AccountStatus", account.AccountStatus.ToString()),
            new Claim("AccountEmail", account.AccountEmail),
        };

        if (account.AccountRole.ToString() == "0") //normal user
        {
            claims.Add(new Claim("AccountId", account.Id.ToString()));
            claims.Add(new Claim("AccountName", $"{account.AccountName} {account.AccountSurname}"));
            claims.Add(new Claim("AccountEmail", account.AccountEmail));
        }
        return claims.ToArray();
    }
}
