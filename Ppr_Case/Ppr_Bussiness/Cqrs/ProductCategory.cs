using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Ppr_Base.Response;
using Ppr_Schema;

namespace Ppr_Bussiness.Cqrs;

public record CreateProductCategoryCommand(ProductCategoryRequest Request) : IRequest<ApiResponse<ProductCategoryResponse>>;
public record UpdateProductCategoryCommand(long ProductCategoryId, ProductCategoryRequest Request) : IRequest<ApiResponse>;
public record DeleteProductCategoryCommand(long ProductCategoryId) : IRequest<ApiResponse>;
public record GetAllProductCategoryQuery() : IRequest<ApiResponse<List<ProductCategoryResponse>>>;
public record GetProductCategoryByIdQuery(long ProductCategoryId) : IRequest<ApiResponse<ProductCategoryResponse>>;