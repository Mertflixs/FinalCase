using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ppr_Base.Schema;

namespace Ppr_Schema;

public class ProductRequest : BaseRequest
{
    public long ProductId { get; set; }
    public string ProductName { get; set; }
    public string ProductDescription { get; set; }
    public int ProductPrice { get; set; }
    public bool IsActive { get; set; }
    public string ProductFeatures { get; set; }
    public decimal RewardPercentage { get; set; }
    public decimal MaxRewardAmount { get; set; }
    public long CategoryId { get; set; }
}

public class ProductResponse : BaseResponse
{
    public long ProductId { get; set; }
    public string ProductName { get; set; }
    public string ProductDescription { get; set; }
    public int ProductPrice { get; set; }
    public bool IsActive { get; set; }
    public string ProductFeatures { get; set; }
    public double RewardPercentage { get; set; }
    public double MaxRewardAmount { get; set; }
    public long CategoryId { get; set; } // categoryId CategoryTable added 
}
