using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ppr_Base.Schema;

namespace Ppr_Schema;

public class ProductCategoryRequest : BaseRequest
{
    public long AccountId { get; set; }
    public long ProductId { get; set; }
    public long CategoryId { get; set; }
}

public class ProductCategoryResponse : BaseResponse
{
    public long AccountId { get; set; }
    public long ProductId { get; set; }
    public long CategoryId { get; set; }
}