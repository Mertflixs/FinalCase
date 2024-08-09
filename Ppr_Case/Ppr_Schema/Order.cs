using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ppr_Base.Schema;

namespace Ppr_Schema;

public class OrderRequest : BaseRequest
{
    public long AccountId { get; set; }
    public long OrderId { get; set; }
    public string CartAmount { get; set; }
    public int CouponAmount { get; set; }
    public string CouponCode { get; set; }
    public int PointsAmount { get; set; }
    public string ShippingAddress { get; set; }
    public DateTime OrderDate { get; set; }
    
}

public class OrderResponse : BaseResponse
{
    public long AccountId { get; set; }
    public long OrderId { get; set; }
    public string CartAmount { get; set; }
    public int CouponAmount { get; set; }
    public string CouponCode { get; set; }
    public int PointsAmount { get; set; }
    public DateTime OrderDate { get; set; }
    public string ShippingAddress { get; set; }
}