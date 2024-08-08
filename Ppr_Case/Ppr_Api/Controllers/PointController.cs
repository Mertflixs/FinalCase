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
    public class PointController : ControllerBase
    {
        private readonly IMediator mediator;

        public PointController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<ApiResponse<List<PointResponse>>> Get()
        {
            var operation = new GetAllPointQuery();
            var res = await mediator.Send(operation);
            return res;
        }

        [HttpGet("{PointId}")]
        public async Task<ApiResponse<PointResponse>> Post([FromRoute] long PointId)
        {
            var operation = new GetPointByIdQuery(PointId);
            var res = await mediator.Send(operation);
            return res;
        }

        [HttpPost]
        public async Task<ApiResponse<PointResponse>> Post([FromBody] PointRequest value)
        {
            var operation = new CreatePointCommand(value);
            var res = await mediator.Send(operation);
            return res;
        }

        [HttpPut("{PointId}")]
        public async Task<ApiResponse> Put(long PointId, [FromBody] PointRequest value)
        {
            var operation = new UpdatePointCommand(PointId, value);
            var res = await mediator.Send(operation);
            return res;
        }

        [HttpDelete("{PointId}")]
        public async Task<ApiResponse> Delete(long PointId)
        {
            var operation = new DeletePointCommand(PointId);
            var res = await mediator.Send(operation);
            return res;
        }
    }
}