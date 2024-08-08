using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ppr_Base.Schema;

namespace Ppr_Schema;

public class PointRequest : BaseRequest
{
    public long PointId { get; set; }
    public long TotalPoint { get; set; }
}

public class PointResponse : BaseResponse
{
    public long PointId { get; set;}
    public long TotalPoint { get; set;}
}