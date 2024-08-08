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

public class OrderCommandHandler :
IRequestHandler<CreateOrderCommand, ApiResponse<OrderResponse>>,
IRequestHandler<UpdateOrderCommand, ApiResponse>,
IRequestHandler<DeleteOrderCommand, ApiResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public OrderCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this._unitOfWork = unitOfWork;
        this._mapper = mapper;
    }

    public async Task<ApiResponse<OrderResponse>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        var order = _mapper.Map<Order>(request.Request);
        order.OrderId = new Random().Next(1000000, 9999999);
        await _unitOfWork.OrderRepository.Insert(order);
        await _unitOfWork.Complete();

        var res = _mapper.Map<OrderResponse>(order);
        return new ApiResponse<OrderResponse>(res);
    }

    public async Task<ApiResponse> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.OrderRepository.GetById(request.OrderId);
        if (entity == null)
        {
            return new ApiResponse();
        }

        _mapper.Map(request.Request, entity);
        entity.InsertUser = entity.InsertUser;
        _unitOfWork.OrderRepository.Update(entity);
        await _unitOfWork.Complete();

        return new ApiResponse();
    }

    public async Task<ApiResponse> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
    {
        await _unitOfWork.OrderRepository.Delete(request.OrderId);
        await _unitOfWork.Complete();
        return new ApiResponse();
    }
}