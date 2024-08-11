using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using Ppr_Base.Entity;

namespace Ppr_Data.Domain;

[Table("Product", Schema = "dbo")]
public class Product : BaseEntity
{
    public long ProductId { get; set; }
    public string ProductName { get; set; }
    public string ProductDescription { get; set; }
    public int ProductPrice { get; set; }
    public bool IsActive { get; set; }
    public string ProductFeatures { get; set; }
    public decimal RewardPercentage { get; set; }
    public decimal MaxRewardAmount { get; set; }
    public virtual List<ProductCategory> ProductCategory { get; set; }
}