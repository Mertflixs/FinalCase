using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ppr_Base.Schema;

namespace Ppr_Schema;

public class CouponRequest : BaseRequest
{
    public long CouponId { get; set;}
    public string CouponName { get; set;}
    public int CouponAmount { get; set;}
    public string CouponCode { get; set;}
    public DateTime ExpryDate { get; set;}
}

public class CouponResponse : BaseResponse
{
    public long CouponId { get; set; }
    public string CouponName { get; set; }
    public int CouponAmount { get; set; }
    public string CouponCode { get; set; }
    public DateTime ExpryDate { get; set; }
}