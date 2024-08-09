using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Ppr_Base.Response;
using Ppr_Bussiness.Cqrs;
using Ppr_Data.Domain;
using Ppr_Data.UnitOfWork;
using Ppr_Schema;

namespace Ppr_Bussiness.Command;

public class AccountCommandHandler :
IRequestHandler<CreateAccountCommand, ApiResponse<AccountResponse>>,
IRequestHandler<UpdateAccountCommand, ApiResponse>,
IRequestHandler<DeleteAccountCommand, ApiResponse>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public AccountCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    public async Task<ApiResponse<AccountResponse>> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
    {
        var mapped = mapper.Map<AccountRequest, Account>(request.Request);
        await unitOfWork.AccountRepository.Insert(mapped);
        await unitOfWork.Complete();

        var res = mapper.Map<AccountResponse>(mapped);
        return new ApiResponse<AccountResponse>(res);
    }

    public async Task<ApiResponse> Handle(UpdateAccountCommand request, CancellationToken cancellationToken)
    {
        var entity = await unitOfWork.AccountRepository.GetById(request.AccountId);
        if (entity == null)
        {
            return new ApiResponse ();
        }

        mapper.Map(request.Request, entity);
        entity.InsertUser = entity.InsertUser;
        unitOfWork.AccountRepository.Update(entity);
        await unitOfWork.Complete();
        return new ApiResponse();
    }

    public async Task<ApiResponse> Handle(DeleteAccountCommand request, CancellationToken cancellationToken)
    {
        await unitOfWork.AccountRepository.Delete(request.AccountId);
        await unitOfWork.Complete();
        return new ApiResponse();
    }
}