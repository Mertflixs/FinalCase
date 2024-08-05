using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Ppr_Base.Response;
using Ppr_Schema;

namespace Ppr_Bussiness.Cqrs;

public record CreateCategoryCommand(CategoryRequest Request) : IRequest<ApiResponse<CategoryResponse>>;

public record UpdateCategoryCommand(long CategoryId, CategoryRequest Request) : IRequest<ApiResponse>;

public record DeleteCategoryCommand(long CategoryId) : IRequest<ApiResponse>;

public record GetAllCategoriesQuery() : IRequest<ApiResponse<List<CategoryResponse>>>;

public record GetCategoryByIdQuery(long CategoryId) : IRequest<ApiResponse<CategoryResponse>>;