using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ppr_Base.Entity
{
    public class BaseEntity
    {
        public long Id { get; set; }
        public string InsertUser { get; set; }
        public DateTime InsertDate { get; set; }
        public bool IsActive { get; set; }
    }
}