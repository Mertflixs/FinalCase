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
public class ProductCommandHandler :
IRequestHandler<CreateProductCommand, ApiResponse<ProductResponse>>,
IRequestHandler<UpdateProductCommand, ApiResponse>,
IRequestHandler<DeleteProductCommand, ApiResponse>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public ProductCommandHandler(IUnitOfWork _unitOfWork, IMapper _mapper)
    {
        this.unitOfWork = _unitOfWork;
        this.mapper = _mapper;
    }

    public async Task<ApiResponse<ProductResponse>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var product = mapper.Map<Product>(request.Request);
        product.ProductId = new Random().Next(1000000, 9999999);
        await unitOfWork.ProductRepository.Insert(product);
        await unitOfWork.Complete();

        var res = mapper.Map<ProductResponse>(product);
        return new ApiResponse<ProductResponse>(res);
    }

    public async Task<ApiResponse> Handle(UpdateProductCommand request, CancellationToken cancellationToken) {
        var entity = await unitOfWork.ProductRepository.GetById(request.ProductId);
        if (entity == null) {
            return new ApiResponse();
        }

        mapper.Map(request.Request, entity);
        entity.InsertUser = entity.InsertUser;
        unitOfWork.ProductRepository.Update(entity);
        await unitOfWork.Complete();

        return new ApiResponse();
    }
    
    public async Task<ApiResponse> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        await unitOfWork.ProductRepository.Delete(request.ProductId);
        await unitOfWork.Complete();
        return new ApiResponse();
    }
}