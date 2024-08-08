using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ppr_Base.Schema;

namespace Ppr_Schema;

public class OrderDetailRequest : BaseRequest
{
    public long OrderDetailId { get; set; }
    public long OrderId { get; set; }
    public long CustomerId { get; set; }
    public long ProductId { get; set; }
    public int Quantity { get; set; }
}

public class OrderDetailResponse : BaseRequest
{
    public long OrderDetailId { get; set; }
    public long OrderId { get; set; }
    public long CustomerId { get; set; }
    public long ProductId { get; set; }
    public int Quantity { get; set; }
}