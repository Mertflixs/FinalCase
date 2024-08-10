using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Ppr_Base.Response;
using Ppr_Bussiness.Cqrs;
using Ppr_Schema;

namespace Ppr_Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CouponController : ControllerBase
    {
        private readonly IMediator mediator;

        public CouponController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        [Authorize(Roles = "1")]
        public async Task<ApiResponse<List<CouponResponse>>> Get()
        {
            var operation = new GetAllCouponQuery();
            var res = await mediator.Send(operation);
            return res;
        }

        [HttpGet("{CouponId}")]
        [Authorize(Roles = "0, 1")]
        public async Task<ApiResponse<CouponResponse>> Post([FromRoute] long CouponId)
        {
            var operation = new GetCouponByIdQuery(CouponId);
            var res = await mediator.Send(operation);
            return res;
        }

        [HttpPost]
        [Authorize(Roles = "1")]
        public async Task<ApiResponse<CouponResponse>> Post([FromBody] CouponRequest value)
        {
            var operation = new CreateCouponCommand(value);
            var res = await mediator.Send(operation);
            return res;
        }

        [HttpPut("{CouponId}")]
        [Authorize(Roles = "1")]
        public async Task<ApiResponse> Put(long CouponId, [FromBody] CouponRequest value)
        {
            var operation = new UpdateCouponCommand(CouponId, value);
            var res = await mediator.Send(operation);
            return res;
        }

        [HttpDelete("{CouponId}")]
        [Authorize(Roles = "1")]
        public async Task<ApiResponse> Delete(long CouponId)
        {
            var operation = new DeleteCouponCommand(CouponId);
            var res = await mediator.Send(operation);
            return res;
        }
    }
}