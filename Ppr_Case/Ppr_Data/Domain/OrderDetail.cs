using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using Ppr_Base.Entity;

namespace Ppr_Data.Domain;

[Table("OrderDetail", Schema = "dbo")]
public class OrderDetail : BaseEntity
{
    public long OrderDetailId { get; set; }
    public long OrderId { get; set; }
    public long CustomerId { get; set; }
    public long ProductId { get; set; }
    public int Quantity { get; set; }
}