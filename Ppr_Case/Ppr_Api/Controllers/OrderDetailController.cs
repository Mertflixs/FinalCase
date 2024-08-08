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
    public class OrderDetailController : ControllerBase
    {
        private readonly IMediator mediator;

        public OrderDetailController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<ApiResponse<List<OrderDetailResponse>>> Get()
        {
            var operation = new GetAllOrderDetailQuery();
            var res = await mediator.Send(operation);
            return res;
        }

        [HttpGet("{OrderDetailId}")]
        public async Task<ApiResponse<OrderDetailResponse>> Post([FromRoute] long OrderDetailId)
        {
            var operation = new GetOrderDetailByIdQuery(OrderDetailId);
            var res = await mediator.Send(operation);
            return res;
        }

        [HttpPost]
        public async Task<ApiResponse<OrderDetailResponse>> Post([FromBody] OrderDetailRequest value)
        {
            var operation = new CreateOrderDetailCommand(value);
            var res = await mediator.Send(operation);
            return res;
        }

        [HttpPut("{OrderDetailId}")]
        public async Task<ApiResponse> Put(long OrderDetailId, [FromBody] OrderDetailRequest value)
        {
            var operation = new UpdateOrderDetailCommand(OrderDetailId, value);
            var res = await mediator.Send(operation);
            return res;
        }

        [HttpDelete("{OrderDetailId}")]
        public async Task<ApiResponse> Delete(long OrderDetailId)
        {
            var operation = new DeleteOrderDetailCommand(OrderDetailId);
            var res = await mediator.Send(operation);
            return res;
        }
    }
}