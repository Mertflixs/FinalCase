using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Ppr_Base.Response;
using Ppr_Schema;

namespace Ppr_Bussiness.Cqrs;

public record CreateCouponCommand(CouponRequest Request) : IRequest<ApiResponse<CouponResponse>>;
public record UpdateCouponCommand(long CouponId, CouponRequest Request) : IRequest<ApiResponse>;
public record DeleteCouponCommand(long CouponId) : IRequest<ApiResponse>;
public record GetAllCouponQuery() : IRequest<ApiResponse<List<CouponResponse>>>;
public record GetCouponByIdQuery(long CouponId) : IRequest<ApiResponse<CouponResponse>>;