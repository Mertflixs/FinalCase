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

public class PointCommandHandler :
IRequestHandler<CreatePointCommand, ApiResponse<PointResponse>>,
IRequestHandler<UpdatePointCommand, ApiResponse>,
IRequestHandler<DeletePointCommand, ApiResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public PointCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this._unitOfWork = unitOfWork;
        this._mapper = mapper;
    }

    public async Task<ApiResponse<PointResponse>> Handle(CreatePointCommand request, CancellationToken cancellationToken)
    {
        var point = _mapper.Map<Point>(request.Request);
        point.PointId = new Random().Next(1000000, 9999999);
        await _unitOfWork.PointRepository.Insert(point);
        await _unitOfWork.Complete();

        var res = _mapper.Map<PointResponse>(point);
        return new ApiResponse<PointResponse>(res);
    }

    public async Task<ApiResponse> Handle(UpdatePointCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.PointRepository.GetById(request.PointId);
        if (entity == null)
        {
            return new ApiResponse();
        }

        _mapper.Map(request.Request, entity);
        entity.InsertUser = entity.InsertUser;
        _unitOfWork.PointRepository.Update(entity);
        await _unitOfWork.Complete();

        return new ApiResponse();
    }

    public async Task<ApiResponse> Handle(DeletePointCommand request, CancellationToken cancellationToken)
    {
        await _unitOfWork.PointRepository.Delete(request.PointId);
        await _unitOfWork.Complete();
        return new ApiResponse();
    }
}