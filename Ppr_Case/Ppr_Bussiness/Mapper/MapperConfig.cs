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
        
        // Account mappings
        CreateMap<Account, AccountResponse>();
        CreateMap<AccountRequest, Account>();

        // Category mappings
        CreateMap<Category, CategoryResponse>();
        CreateMap<CategoryRequest, Category>();

        // Product mappings
        CreateMap<Product, ProductResponse>();
        CreateMap<ProductRequest, Product>();

        // order mapping
        CreateMap<Order, OrderResponse>();
        CreateMap<OrderRequest, Order>();

        //OrderDetail Mapping
        CreateMap<OrderDetail, OrderDetailResponse>();
        CreateMap<OrderDetailRequest, OrderDetail>();

        //Coupon Mapping
        CreateMap<Coupon, CouponResponse>();
        CreateMap<CouponRequest, Coupon>();

        //Point Mapping
        CreateMap<Point, PointResponse>();
        CreateMap<PointRequest, Point>();

        //ProductCategory Mapping
        CreateMap<ProductCategory, ProductCategoryResponse>();
        CreateMap<ProductCategoryRequest, ProductCategory>();
    }
}