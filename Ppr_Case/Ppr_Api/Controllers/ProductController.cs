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
    public class ProductController : ControllerBase
    {
        private readonly IMediator mediator;

        public ProductController(IMediator mediator) {
            this.mediator = mediator;
        }

        [HttpGet]
        [Authorize(Roles = "0, 1")]
        public async Task<ApiResponse<List<ProductResponse>>> Get() {
            var operation = new GetAllProductQuery();
            var res = await mediator.Send(operation);
            return res;
        }

        [HttpGet("{ProductId}")]
        [Authorize(Roles = "0, 1")]
        public async Task<ApiResponse<ProductResponse>> Post([FromRoute] long ProductId) {
            var operation = new GetProductByIdQuery(ProductId);
            var res = await mediator.Send(operation);
            return res;
        }

        [HttpPost]
        [Authorize(Roles = "1")]
        public async Task<ApiResponse<ProductResponse>> Post([FromBody] ProductRequest value) {
            var operation = new CreateProductCommand(value);
            var res = await mediator.Send(operation);
            return res;
        }

        [HttpPut("{ProductId}")]
        [Authorize(Roles = "1")]
        public async Task<ApiResponse> Put(long ProductId, [FromBody] ProductRequest value) {
            var operation = new UpdateProductCommand(ProductId, value);
            var res = await mediator.Send(operation);
            return res;
        }

        [HttpDelete("{ProductId}")]
        [Authorize(Roles = "1")]
        public async Task<ApiResponse> Delete(long ProductId) {
            var operation = new DeleteProductCommand(ProductId);
            var res = await mediator.Send(operation);
            return res;
        }
    }
}