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

public class CouponCommandHandler :
IRequestHandler<CreateCouponCommand, ApiResponse<CouponResponse>>,
IRequestHandler<UpdateCouponCommand, ApiResponse>,
IRequestHandler<DeleteCouponCommand, ApiResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CouponCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this._unitOfWork = unitOfWork;
        this._mapper = mapper;
    }

    public async Task<ApiResponse<CouponResponse>> Handle(CreateCouponCommand request, CancellationToken cancellationToken)
    {
        var coupon = _mapper.Map<Coupon>(request.Request);
        coupon.CouponId = new Random().Next(1000000, 9999999);
        await _unitOfWork.CouponRepository.Insert(coupon);
        await _unitOfWork.Complete();

        var res = _mapper.Map<CouponResponse>(coupon);
        return new ApiResponse<CouponResponse>(res);
    }

    public async Task<ApiResponse> Handle(UpdateCouponCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.CouponRepository.GetById(request.CouponId);
        if (entity == null)
        {
            return new ApiResponse();
        }

        _mapper.Map(request.Request, entity);
        entity.InsertUser = entity.InsertUser;
        _unitOfWork.CouponRepository.Update(entity);
        await _unitOfWork.Complete();

        return new ApiResponse();
    }

    public async Task<ApiResponse> Handle(DeleteCouponCommand request, CancellationToken cancellationToken)
    {
        await _unitOfWork.CouponRepository.Delete(request.CouponId);
        await _unitOfWork.Complete();
        return new ApiResponse();
    }
}