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
    public class OrderController : ControllerBase
    {
        private readonly IMediator mediator;

        public OrderController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<ApiResponse<List<OrderResponse>>> Get()
        {
            var operation = new GetAllOrderQuery();
            var res = await mediator.Send(operation);
            return res;
        }

        [HttpGet("{OrderId}")]
        public async Task<ApiResponse<OrderResponse>> Post([FromRoute] long OrderId)
        {
            var operation = new GetOrderByIdQuery(OrderId);
            var res = await mediator.Send(operation);
            return res;
        }

        [HttpPost]
        public async Task<ApiResponse<OrderResponse>> Post([FromBody] OrderRequest value)
        {
            var operation = new CreateOrderCommand(value);
            var res = await mediator.Send(operation);
            return res;
        }

        [HttpPut("{OrderId}")]
        public async Task<ApiResponse> Put(long OrderId, [FromBody] OrderRequest value)
        {
            var operation = new UpdateOrderCommand(OrderId, value);
            var res = await mediator.Send(operation);
            return res;
        }

        [HttpDelete("{OrderId}")]
        public async Task<ApiResponse> Delete(long OrderId)
        {
            var operation = new DeleteOrderCommand(OrderId);
            var res = await mediator.Send(operation);
            return res;
        }
    }
}