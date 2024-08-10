using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Ppr_Base.Response;
using Ppr_Bussiness.Cqrs;
using Ppr_Bussiness.Token;
using Ppr_Data.UnitOfWork;
using Ppr_Schema;

namespace Ppr_Bussiness.Command;

public class AuthorizationCommandHandler :
IRequestHandler<CreateAuthorizationTokenCommand, ApiResponse<AuthorizationResponse>>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;
    private ITokenService tokenService;

    public AuthorizationCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ITokenService tokenService)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
        this.tokenService = tokenService;
    }

    public async Task<ApiResponse<AuthorizationResponse>> Handle(CreateAuthorizationTokenCommand request, CancellationToken cancellationToken)
    {
        var user = await unitOfWork.AccountRepository.FirstOrDefault(x => x.AccountName == request.Request.userName);
        Console.WriteLine("", user);
        if (user is null)
            return new ApiResponse<AuthorizationResponse>("Invalid user informations. Check your username or password. E1");

        if (user.AccountPassword != request.Request.password)
        {
            return new ApiResponse<AuthorizationResponse>("Invalid user informations. Check your username or password. E2");
        }

        if (user.AccountStatus != 1)
            return new ApiResponse<AuthorizationResponse>("Invalid user informations. Check your username or password. E3");

        var token = await tokenService.GetToken(user);
        AuthorizationResponse response = new AuthorizationResponse()
        {
            ExpireTime = DateTime.Now.AddMinutes(5),
            AccessToken = token,
            UserName = user.AccountName
        };

        return new ApiResponse<AuthorizationResponse>(response);
    }
}