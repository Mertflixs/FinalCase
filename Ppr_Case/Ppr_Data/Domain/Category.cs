using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using Ppr_Base.Entity;

namespace Ppr_Data.Domain;

[Table("Category", Schema = "dbo")]
public class Category : BaseEntity
{
    public long CategoryId { get; set; }
    public string CategoryName { get; set; }
    public string CategoryUrl { get; set; }
    public string CategoryTags { get; set; }
}