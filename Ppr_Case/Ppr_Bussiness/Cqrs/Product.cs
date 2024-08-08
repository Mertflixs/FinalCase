using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Ppr_Base.Response;
using Ppr_Schema;

namespace Ppr_Bussiness.Cqrs;

public record CreateProductCommand(ProductRequest Request) : IRequest<ApiResponse<ProductResponse>>;
public record UpdateProductCommand(long ProductId, ProductRequest Request) : IRequest<ApiResponse>;
public record DeleteProductCommand(long ProductId) : IRequest<ApiResponse>;
public record GetAllProductQuery() : IRequest<ApiResponse<List<ProductResponse>>>;
public record GetProductByIdQuery(long ProductId) : IRequest<ApiResponse<ProductResponse>>;