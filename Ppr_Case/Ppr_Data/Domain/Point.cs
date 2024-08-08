using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using Ppr_Base.Entity;

namespace Ppr_Data.Domain;

[Table("Point", Schema = "dbo")]

public class Point : BaseEntity
{
    public long AccountId { get; set; }
    public virtual Account Account { get; set; }
    public long PointId { get; set; }
    public long TotalPoint { get; set; }
}