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

public class OrderDetailCommandHandler :
IRequestHandler<CreateOrderDetailCommand, ApiResponse<OrderDetailResponse>>,
IRequestHandler<UpdateOrderDetailCommand, ApiResponse>,
IRequestHandler<DeleteOrderDetailCommand, ApiResponse>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public OrderDetailCommandHandler(IUnitOfWork _unitOfWork, IMapper _mapper)
    {
        this.unitOfWork = _unitOfWork;
        this.mapper = _mapper;
    }

    public async Task<ApiResponse<OrderDetailResponse>> Handle(CreateOrderDetailCommand request, CancellationToken cancellationToken)
    {
        var orderDetail = mapper.Map<OrderDetail>(request.Request);
        orderDetail.OrderDetailId = new Random().Next(1000000, 9999999);
        await unitOfWork.OrderDetailRepository.Insert(orderDetail);
        await unitOfWork.Complete();

        var res = mapper.Map<OrderDetailResponse>(orderDetail);
        return new ApiResponse<OrderDetailResponse>(res);
    }

    public async Task<ApiResponse> Handle(UpdateOrderDetailCommand request, CancellationToken cancellationToken)
    {
        var entity = await unitOfWork.OrderDetailRepository.GetById(request.OrderDetailId);
        if (entity == null)
        {
            return new ApiResponse();
        }

        mapper.Map(request.Request, entity);
        entity.InsertUser = entity.InsertUser;
        unitOfWork.OrderDetailRepository.Update(entity);
        await unitOfWork.Complete();

        return new ApiResponse();
    }

    public async Task<ApiResponse> Handle(DeleteOrderDetailCommand request, CancellationToken cancellationToken)
    {
        await unitOfWork.OrderDetailRepository.Delete(request.OrderDetailId);
        await unitOfWork.Complete();
        return new ApiResponse();
    }
}