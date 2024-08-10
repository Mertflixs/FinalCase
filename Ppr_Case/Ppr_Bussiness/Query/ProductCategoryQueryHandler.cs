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

public class ProductCategoryQueryHandler :
IRequestHandler<GetAllProductCategoryQuery, ApiResponse<List<ProductCategoryResponse>>>,
IRequestHandler<GetProductCategoryByIdQuery, ApiResponse<ProductCategoryResponse>>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public ProductCategoryQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this._unitOfWork = unitOfWork;
        this._mapper = mapper;
    }

    public async Task<ApiResponse<List<ProductCategoryResponse>>> Handle(GetAllProductCategoryQuery request, CancellationToken cancellationToken)
    {
        var ProductCategory = await _unitOfWork.ProductCategoryRepository.GetAll();
        var res = _mapper.Map<List<ProductCategoryResponse>>(ProductCategory);
        return new ApiResponse<List<ProductCategoryResponse>>(res);
    }

    public async Task<ApiResponse<ProductCategoryResponse>> Handle(GetProductCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        var ProductCategory = await _unitOfWork.ProductCategoryRepository.GetById(request.ProductCategoryId);
        if (ProductCategory == null)
        {
            return new ApiResponse<ProductCategoryResponse>();
        }
        var res = _mapper.Map<ProductCategoryResponse>(ProductCategory);
        return new ApiResponse<ProductCategoryResponse>(res);
    }
}