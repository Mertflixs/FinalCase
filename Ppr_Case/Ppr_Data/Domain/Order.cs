using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using Ppr_Base.Entity;

namespace Ppr_Data.Domain;

[Table("Order", Schema = "dbo")]
public class Order : BaseEntity
{
    public long OrderId { get; set; }
    public string CartAmount { get; set; }
    public int CouponAmount { get; set; }
    public string CouponCode { get; set; }
    public int PointsAmount { get; set; }
    public DateTime OrderDate { get; set; }
    public string ShippingAddress { get; set; }
}