using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using Ppr_Base.Entity;

namespace Ppr_Data.Domain;

[Table("ProductCategory", Schema = "dbo")]
public class ProductCategory : BaseEntity
{
    public long AccountId { get; set; }
    public virtual Account Account { get; set; }
    public long ProductId { get; set; }
    public virtual Product Product { get; set; }
    public long CategoryId { get; set; }
    public virtual Category Category { get; set; }
}