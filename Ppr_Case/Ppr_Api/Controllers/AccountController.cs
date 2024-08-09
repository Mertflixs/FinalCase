using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Ppr_Base.Response;
using Ppr_Bussiness.Cqrs;
using Ppr_Schema;

namespace Ppr_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IMediator mediator;

        public AccountController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<ApiResponse<List<AccountResponse>>> Get()
        {
            var operation = new GetAllAccountQuery();
            var res = await mediator.Send(operation);
            return res;
        }

        [HttpGet("ByParamaters")]
        public async Task<ApiResponse<List<AccountResponse>>> GetByParameters(
            [FromQuery] string? AccountName = null,
            [FromQuery] string? AccountSurname = null,
            [FromQuery] string? AccountEmail = null
        )
        {
            var operation = new GetAccountByParametersQuery(AccountName, AccountSurname, AccountEmail);
            var res = await mediator.Send(operation);
            return res;
        }

        [HttpGet("ByAccount")]
        public async Task<ApiResponse<AccountResponse>> GetByAccountId()
        {
            var operation = new GetAccountByAccountIdQuery();
            var res = await mediator.Send(operation);
            return res;
        }

        [HttpGet("{AccountId}")]
        public async Task<ApiResponse<AccountResponse>> Get([FromRoute] long AccountId)
        {
            var operation = new GetAccountByIdQuery(AccountId);
            var res = await mediator.Send(operation);
            return res;
        }

        [HttpPost]
        public async Task<ApiResponse<AccountResponse>> Post([FromBody] AccountRequest value)
        {
            var operation = new CreateAccountCommand(value);
            var res = await mediator.Send(operation);
            return res;
        }

        [HttpPut("{AccountId}")]
        public async Task<ApiResponse> Put(long AccountId, [FromBody] AccountRequest value)
        {
            var operation = new UpdateAccountCommand(AccountId, value);
            var res = await mediator.Send(operation);
            return res;
        }

        [HttpDelete("{AccountId}")]
        public async Task<ApiResponse> Delete(long AccountId)
        {
            var operation = new DeleteAccountCommand(AccountId);
            var res = await mediator.Send(operation);
            return res;
        }
    }

}