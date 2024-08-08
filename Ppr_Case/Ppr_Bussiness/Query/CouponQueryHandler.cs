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

public class CouponQueryHandler :
IRequestHandler<GetAllCouponQuery, ApiResponse<List<CouponResponse>>>,
IRequestHandler<GetCouponByIdQuery, ApiResponse<CouponResponse>>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public CouponQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this._unitOfWork = unitOfWork;
        this._mapper = mapper;
    }

    public async Task<ApiResponse<List<CouponResponse>>> Handle(GetAllCouponQuery request, CancellationToken cancellationToken)
    {
        var coupon = await _unitOfWork.CouponRepository.GetAll();
        var res = _mapper.Map<List<CouponResponse>>(coupon);
        return new ApiResponse<List<CouponResponse>>(res);
    }

    public async Task<ApiResponse<CouponResponse>> Handle(GetCouponByIdQuery request, CancellationToken cancellationToken)
    {
        var coupon = await _unitOfWork.CouponRepository.GetById(request.CouponId);
        if (coupon == null)
        {
            return new ApiResponse<CouponResponse>();
        }
        var res = _mapper.Map<CouponResponse>(coupon);
        return new ApiResponse<CouponResponse>(res);
    }
}