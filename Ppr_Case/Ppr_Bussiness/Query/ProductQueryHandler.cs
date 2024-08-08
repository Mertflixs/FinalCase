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

public class ProductQueryHandler :
IRequestHandler<GetAllProductQuery, ApiResponse<List<ProductResponse>>>,
IRequestHandler<GetProductByIdQuery, ApiResponse<ProductResponse>>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public ProductQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this._unitOfWork = unitOfWork;
        this._mapper = mapper;
    }

    public async Task<ApiResponse<List<ProductResponse>>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
    {
        var product = await _unitOfWork.ProductRepository.GetAll();
        var res = _mapper.Map<List<ProductResponse>>(product);
        return new ApiResponse<List<ProductResponse>>(res);
    }

    public async Task<ApiResponse<ProductResponse>> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var product = await _unitOfWork.ProductRepository.GetById(request.ProductId);
        if (product == null)
        {
            return new ApiResponse<ProductResponse>();
        }
        var res = _mapper.Map<ProductResponse>(product);
        return new ApiResponse<ProductResponse>(res);
    }
}