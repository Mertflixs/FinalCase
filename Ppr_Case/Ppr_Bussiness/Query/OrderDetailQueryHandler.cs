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

public class OrderDetailQueryHandler :
IRequestHandler<GetAllOrderDetailQuery, ApiResponse<List<OrderDetailResponse>>>,
IRequestHandler<GetOrderDetailByIdQuery, ApiResponse<OrderDetailResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public OrderDetailQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this._unitOfWork = unitOfWork;
        this._mapper = mapper;
    }

    public async Task<ApiResponse<List<OrderDetailResponse>>> Handle(GetAllOrderDetailQuery request, CancellationToken cancellationToken)
    {
        var orderDetail = await _unitOfWork.OrderDetailRepository.GetAll();
        var res = _mapper.Map<List<OrderDetailResponse>>(orderDetail);
        return new ApiResponse<List<OrderDetailResponse>>(res);
    }

    public async Task<ApiResponse<OrderDetailResponse>> Handle(GetOrderDetailByIdQuery request, CancellationToken cancellationToken)
    {
        var orderDetail = await _unitOfWork.OrderDetailRepository.GetById(request.OrderDetailId);
        if (orderDetail == null)
        {
            return new ApiResponse<OrderDetailResponse>();
        }
        var res = _mapper.Map<OrderDetailResponse>(orderDetail);
        return new ApiResponse<OrderDetailResponse>(res);
    }
}