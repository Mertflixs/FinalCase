using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Ppr_Data.Domain;
using Ppr_Schema;

namespace Ppr_Bussiness.Mapper;

public class MapperConfig : Profile
{
    public MapperConfig()
    {
        CreateMap<Account, AccountResponse>();
        CreateMap<AccountRequest, Account>();

        CreateMap<Category, CategoryResponse>();
        CreateMap<CategoryRequest, Category>();
    }
}