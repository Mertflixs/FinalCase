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

public class PointQueryHandler :
IRequestHandler<GetAllPointQuery, ApiResponse<List<PointResponse>>>,
IRequestHandler<GetPointByIdQuery, ApiResponse<PointResponse>>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public PointQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this._unitOfWork = unitOfWork;
        this._mapper = mapper;
    }

    public async Task<ApiResponse<List<PointResponse>>> Handle(GetAllPointQuery request, CancellationToken cancellationToken)
    {
        var point = await _unitOfWork.PointRepository.GetAll();
        var res = _mapper.Map<List<PointResponse>>(point);
        return new ApiResponse<List<PointResponse>>(res);
    }

    public async Task<ApiResponse<PointResponse>> Handle(GetPointByIdQuery request, CancellationToken cancellationToken)
    {
        var point = await _unitOfWork.PointRepository.GetById(request.PointId);
        if (point == null)
        {
            return new ApiResponse<PointResponse>();
        }
        var res = _mapper.Map<PointResponse>(point);
        return new ApiResponse<PointResponse>(res);
    }
}