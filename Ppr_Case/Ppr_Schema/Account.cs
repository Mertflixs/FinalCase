using Ppr_Base.Schema;

namespace Ppr_Schema;
public class AccountRequest : BaseRequest
{
    public long AccountNumber { get; set; }
    public string AccountName { get; set;}
    public string AccountSurname { get; set;}
    public string AccountEmail { get; set;}
    public int AccountRole { get; set; } // 0 normal user 1 seller user 2 admin user
    public string AccountPassword { get; set;}
    public int AccountStatus { get; set; }
    public int AccountPoint { get; set; }
    public int AccountWallet { get; set; }
}

public class AccountResponse : BaseResponse
{
    public long AccountNumber { get; set; }
    public string AccountName { get; set; }
    public string AccountSurname { get; set; }
    public string AccountEmail { get; set; }
    public int AccountRole { get; set; } // 0 normal user 1 seller user 2 admin user
    public string AccountPassword { get; set; }
    public int AccountStatus { get; set; }
    public int AccountPoint { get; set; }
    public int AccountWallet { get; set; }
}