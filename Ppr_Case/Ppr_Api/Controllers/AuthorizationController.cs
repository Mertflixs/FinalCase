using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ppr_Base.Attribute;
using Ppr_Base.Response;
using Ppr_Bussiness.Cqrs;
using Ppr_Schema;

namespace Ppr_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizationController : ControllerBase
    {
        private readonly IMediator mediator;

        public AuthorizationController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        [AllowAnonymous]
        [ResponseHeader("MyCustomHeaderInResponse", "POST")]
        public async Task<ApiResponse<AuthorizationResponse>> Post([FromBody] AuthorizationRequest value)
        {
            var operation = new CreateAuthorizationTokenCommand(value);
            var result = await mediator.Send(operation);
            return result;

        }
    }
}