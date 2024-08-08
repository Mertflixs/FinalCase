using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using Ppr_Base.Entity;

namespace Ppr_Data.Domain;

[Table("Coupon", Schema = "dbo")]

public class Coupon : BaseEntity
{
    public long CouponId { get; set; }
    public string CouponName { get; set; }
    public int CouponAmount { get; set; }
    public string CouponCode { get; set; }
}