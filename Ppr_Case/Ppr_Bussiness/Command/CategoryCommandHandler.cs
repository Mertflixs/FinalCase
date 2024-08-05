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
public class CategoryCommandHandler :
IRequestHandler<CreateCategoryCommand, ApiResponse<CategoryResponse>>,
IRequestHandler<UpdateCategoryCommand, ApiResponse>,
IRequestHandler<DeleteCategoryCommand, ApiResponse>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public CategoryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    public async Task<ApiResponse<CategoryResponse>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = mapper.Map<Category>(request.Request);
        category.CategoryId = new Random().Next(1000000, 9999999);
        await unitOfWork.CategoryRepository.Insert(category);
        await unitOfWork.Complete();

        var response = mapper.Map<CategoryResponse>(category);
        return new ApiResponse<CategoryResponse>(response);
    }

    public async Task<ApiResponse> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        var entity = await unitOfWork.CategoryRepository.GetById(request.CategoryId);
        if (entity == null)
        {
            return new ApiResponse();
        }

        mapper.Map(request.Request, entity);
        entity.InsertUser = entity.InsertUser;
        unitOfWork.CategoryRepository.Update(entity);
        await unitOfWork.Complete();

        return new ApiResponse();
    }

    public async Task<ApiResponse> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        await unitOfWork.CategoryRepository.Delete(request.CategoryId);
        await unitOfWork.Complete();
        return new ApiResponse();
    }
}