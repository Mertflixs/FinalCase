using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Ppr_Base.Response;
using Ppr_Bussiness.Cqrs;
using Ppr_Data.Domain;
using Ppr_Data.UnitOfWork;
using Ppr_Schema;

namespace Ppr_Bussiness.Query;
public class CategoryQueryHandler :
IRequestHandler<GetAllCategoriesQuery, ApiResponse<List<CategoryResponse>>>,
IRequestHandler<GetCategoryByIdQuery, ApiResponse<CategoryResponse>>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public CategoryQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    public async Task<ApiResponse<List<CategoryResponse>>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
    {
        var categories = await unitOfWork.CategoryRepository.GetAll();
        var response = mapper.Map<List<CategoryResponse>>(categories);
        return new ApiResponse<List<CategoryResponse>>(response);
    }

    public async Task<ApiResponse<CategoryResponse>> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        var category = await unitOfWork.CategoryRepository.GetById(request.CategoryId);
        if (category == null)
        {
            return new ApiResponse<CategoryResponse>();
        }

        var response = mapper.Map<CategoryResponse>(category);
        return new ApiResponse<CategoryResponse>(response);
    }
}