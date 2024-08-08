using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Ppr_Base.Response;
using Ppr_Schema;

namespace Ppr_Bussiness.Cqrs;

public record CreateOrderDetailCommand(OrderDetailRequest Request) : IRequest<ApiResponse<OrderDetailResponse>>;
public record UpdateOrderDetailCommand(long OrderDetailId, OrderDetailRequest Request) : IRequest<ApiResponse>;
public record DeleteOrderDetailCommand(long OrderDetailId) : IRequest<ApiResponse>;
public record GetAllOrderDetailQuery() : IRequest<ApiResponse<List<OrderDetailResponse>>>;
public record GetOrderDetailByIdQuery(long OrderDetailId) : IRequest<ApiResponse<OrderDetailResponse>>;