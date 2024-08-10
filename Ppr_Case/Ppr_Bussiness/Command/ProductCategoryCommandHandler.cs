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

namespace Ppr_Bussiness.Command;

public class ProductCategoryCommandHandler :
IRequestHandler<CreateProductCategoryCommand, ApiResponse<ProductCategoryResponse>>,
IRequestHandler<UpdateProductCategoryCommand, ApiResponse>,
IRequestHandler<DeleteProductCategoryCommand, ApiResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ProductCategoryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this._unitOfWork = unitOfWork;
        this._mapper = mapper;
    }

    public async Task<ApiResponse<ProductCategoryResponse>> Handle(CreateProductCategoryCommand request, CancellationToken cancellationToken)
    {
        var ProductCategory = _mapper.Map<ProductCategory>(request.Request);
        await _unitOfWork.ProductCategoryRepository.Insert(ProductCategory);
        await _unitOfWork.Complete();

        var res = _mapper.Map<ProductCategoryResponse>(ProductCategory);
        return new ApiResponse<ProductCategoryResponse>(res);
    }

    public async Task<ApiResponse> Handle(UpdateProductCategoryCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.ProductCategoryRepository.GetById(request.ProductCategoryId);
        if (entity == null)
        {
            return new ApiResponse();
        }

        _mapper.Map(request.Request, entity);
        entity.InsertUser = entity.InsertUser;
        _unitOfWork.ProductCategoryRepository.Update(entity);
        await _unitOfWork.Complete();

        return new ApiResponse();
    }

    public async Task<ApiResponse> Handle(DeleteProductCategoryCommand request, CancellationToken cancellationToken)
    {
        await _unitOfWork.ProductCategoryRepository.Delete(request.ProductCategoryId);
        await _unitOfWork.Complete();
        return new ApiResponse();
    }
}