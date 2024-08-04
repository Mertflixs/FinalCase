using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using Ppr_Base.Entity;

namespace Ppr_Data.Domain;

[Table("Account", Schema = "dbo")]
public class Account : BaseEntity
{
    public int AccountNumber { get; set; }
    public string AccountName { get; set; }
    public string AccountSurname { get; set; }
    public string AccountEmail { get; set; }
    public int AccountRole { get; set; }
    public string AccountPassword { get; set; }
    public int AccountStatus { get; set; }
    public int AccountPoint { get; set; }
    public int AccountWallet { get; set; }
}