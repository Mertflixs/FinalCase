using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Ppr_Base.Response;
using Ppr_Schema;

namespace Ppr_Bussiness.Cqrs;

public record CreatePointCommand(PointRequest Request) : IRequest<ApiResponse<PointResponse>>;
public record UpdatePointCommand(long PointId, PointRequest Request) : IRequest<ApiResponse>;
public record DeletePointCommand(long PointId) : IRequest<ApiResponse>;
public record GetAllPointQuery() : IRequest<ApiResponse<List<PointResponse>>>;
public record GetPointByIdQuery(long PointId) : IRequest<ApiResponse<PointResponse>>;