using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Ppr_Base.Response;
using Ppr_Schema;

namespace Ppr_Bussiness.Cqrs;

public record CreateAccountCommand(AccountRequest Request) : IRequest<ApiResponse<AccountResponse>>;

public record UpdateAccountCommand(long AccountId, AccountRequest Request) : IRequest<ApiResponse>;

public record DeleteAccountCommand(long AccountId) : IRequest<ApiResponse>;

public record GetAllAccountQuery() : IRequest<ApiResponse<List<AccountResponse>>>;

public record GetAccountByIdQuery(long AccountId) : IRequest<ApiResponse<AccountResponse>>;

public record GetAccountByAccountIdQuery() : IRequest<ApiResponse<AccountResponse>>;

public record GetAccountByParametersQuery(long? AccountId, string AccountName, string AccountSurname, string AccountEmail) : IRequest<ApiResponse<List<AccountResponse>>>;