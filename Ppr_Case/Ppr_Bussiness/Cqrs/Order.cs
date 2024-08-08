using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Ppr_Base.Response;
using Ppr_Schema;

namespace Ppr_Bussiness.Cqrs;

public record CreateOrderCommand(OrderRequest Request) : IRequest<ApiResponse<OrderResponse>>;
public record UpdateOrderCommand(long OrderId, OrderRequest Request) : IRequest<ApiResponse>;
public record DeleteOrderCommand(long OrderId) : IRequest<ApiResponse>;
public record GetAllOrderQuery() : IRequest<ApiResponse<List<OrderResponse>>>;
public record GetOrderByIdQuery(long OrderId) : IRequest<ApiResponse<OrderResponse>>;