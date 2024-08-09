using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LinqKit;
using MediatR;
using Ppr_Base;
using Ppr_Base.Response;
using Ppr_Bussiness.Cqrs;
using Ppr_Data.Domain;
using Ppr_Data.UnitOfWork;
using Ppr_Schema;

namespace Ppr_Bussiness.Query;

public class AccountQueryHandler :
    IRequestHandler<GetAllAccountQuery, ApiResponse<List<AccountResponse>>>,
    IRequestHandler<GetAccountByIdQuery, ApiResponse<AccountResponse>>,
    IRequestHandler<GetAccountByParametersQuery, ApiResponse<List<AccountResponse>>>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public AccountQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    public async Task<ApiResponse<List<AccountResponse>>> Handle(GetAllAccountQuery request, CancellationToken cancellationToken)
    {
        List<Account> entityList = await unitOfWork.AccountRepository.GetAll();
        var mappedList = mapper.Map<List<AccountResponse>>(entityList);
        return new ApiResponse<List<AccountResponse>>(mappedList);
    }

    public async Task<ApiResponse<AccountResponse>> Handle(GetAccountByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await unitOfWork.AccountRepository.GetById(request.AccountId);
        var mapped = mapper.Map<AccountResponse>(entity);
        return new ApiResponse<AccountResponse>(mapped);
    }

    public async Task<ApiResponse<List<AccountResponse>>> Handle(GetAccountByParametersQuery request, CancellationToken cancellationToken)
    {
        var predicate = PredicateBuilder.New<Account>(true);
        if (!string.IsNullOrEmpty(request.AccountName))
            predicate = predicate.And(x => x.AccountName.ToUpper().Contains(request.AccountName.ToUpper()));
        if (!string.IsNullOrEmpty(request.AccountSurname))
            predicate = predicate.And(x => x.AccountSurname.ToUpper().Contains(request.AccountSurname.ToUpper()));
        if (!string.IsNullOrEmpty(request.AccountEmail))
            predicate = predicate.And(x => x.AccountEmail.ToUpper().Contains(request.AccountEmail.ToUpper()));

        List<Account> entityList = await unitOfWork.AccountRepository.Where(predicate);
        var mappedList = mapper.Map<List<AccountResponse>>(entityList);
        return new ApiResponse<List<AccountResponse>>(mappedList);
    }
}
