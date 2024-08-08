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

public class OrderQueryHandler :
IRequestHandler<GetAllOrderQuery, ApiResponse<List<OrderResponse>>>,
IRequestHandler<GetOrderByIdQuery, ApiResponse<OrderResponse>>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public OrderQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this._unitOfWork = unitOfWork;
        this._mapper = mapper;
    }

    public async Task<ApiResponse<List<OrderResponse>>> Handle(GetAllOrderQuery request, CancellationToken cancellationToken)
    {
        var Order = await _unitOfWork.OrderRepository.GetAll();
        var res = _mapper.Map<List<OrderResponse>>(Order);
        return new ApiResponse<List<OrderResponse>>(res);
    }

    public async Task<ApiResponse<OrderResponse>> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
    {
        var Order = await _unitOfWork.OrderRepository.GetById(request.OrderId);
        if (Order == null)
        {
            return new ApiResponse<OrderResponse>();
        }
        var res = _mapper.Map<OrderResponse>(Order);
        return new ApiResponse<OrderResponse>(res);
    }
}