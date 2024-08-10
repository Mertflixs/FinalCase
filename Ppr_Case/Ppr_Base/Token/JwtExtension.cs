using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace Ppr_Base;
public static class JwtManager
{
    public static Session GetSession(HttpContext context)
    {
        Session session = new Session();
        var identity = context.User.Identity as ClaimsIdentity;
        var claims = identity.Claims;
        session.AccountName = GetClaimValue(claims, "AccountName");
        session.AccountStatus = Convert.ToInt32(GetClaimValue(claims, "AccountStatus"));
        session.AccountId = Convert.ToInt64(GetClaimValue(claims, "AccountId"));
        session.AccountRole = GetClaimValue(claims, "AccountRole");
        session.AccountEmail = GetClaimValue(claims, "AccountEmail");
        return session;
    }

    private static string GetClaimValue(IEnumerable<Claim> claims, string name)
    {
        var claim = claims.FirstOrDefault(c => c.Type == name);
        return claim?.Value;
    }
}