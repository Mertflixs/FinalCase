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
    public class CategoryController : ControllerBase
    {
        private readonly IMediator mediator;

        public CategoryController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<ApiResponse<List<CategoryResponse>>> Get()
        {
            var operation = new GetAllCategoriesQuery();
            var res = await mediator.Send(operation);
            return res;
        }

        [HttpGet("{CategoryId}")]
        public async Task<ApiResponse<CategoryResponse>> Get([FromRoute] long CategoryId)
        {
            var operation = new GetCategoryByIdQuery(CategoryId);
            var res = await mediator.Send(operation);
            return res;
        }

        [HttpPost]
        public async Task<ApiResponse<CategoryResponse>> Post([FromBody] CategoryRequest value)
        {
            var operation = new CreateCategoryCommand(value);
            var res = await mediator.Send(operation);
            return res;
        }

        [HttpPut("{CategoryId}")]
        public async Task<ApiResponse> Put(long CategoryId, [FromBody] CategoryRequest value)
        {
            var operation = new UpdateCategoryCommand(CategoryId, value);
            var res = await mediator.Send(operation);
            return res;
        }

        [HttpDelete("{CategoryId}")]
        public async Task<ApiResponse> Delete(long CategoryId)
        {
            var operation = new DeleteCategoryCommand(CategoryId);
            var res = await mediator.Send(operation);
            return res;
        }
    }
}
