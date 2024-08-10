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
    public class ProductCategoryController : ControllerBase
    {
        private readonly IMediator mediator;

        public ProductCategoryController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        [Authorize(Roles = "0, 1")]
        public async Task<ApiResponse<List<ProductCategoryResponse>>> Get()
        {
            var operation = new GetAllProductCategoryQuery();
            var res = await mediator.Send(operation);
            return res;
        }

        [HttpGet("{ProductCategoryId}")]
        [Authorize(Roles = "0, 1")]
        public async Task<ApiResponse<ProductCategoryResponse>> Post([FromRoute] long ProductCategoryId)
        {
            var operation = new GetProductCategoryByIdQuery(ProductCategoryId);
            var res = await mediator.Send(operation);
            return res;
        }

        [HttpPost]
        [Authorize(Roles = "1")]
        public async Task<ApiResponse<ProductCategoryResponse>> Post([FromBody] ProductCategoryRequest value)
        {
            var operation = new CreateProductCategoryCommand(value);
            var res = await mediator.Send(operation);
            return res;
        }

        [HttpPut("{ProductCategoryId}")]
        [Authorize(Roles = "1")]
        public async Task<ApiResponse> Put(long ProductCategoryId, [FromBody] ProductCategoryRequest value)
        {
            var operation = new UpdateProductCategoryCommand(ProductCategoryId, value);
            var res = await mediator.Send(operation);
            return res;
        }

        [HttpDelete("{ProductCategoryId}")]
        [Authorize(Roles = "1")]
        public async Task<ApiResponse> Delete(long ProductCategoryId)
        {
            var operation = new DeleteProductCategoryCommand(ProductCategoryId);
            var res = await mediator.Send(operation);
            return res;
        }
    }
}