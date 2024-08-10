using Ppr_Base.Schema;

namespace Ppr_Schema;
public class AccountRequest : BaseRequest
{
    //public long AccountId { get; set; }
    public string AccountName { get; set;}
    public string AccountSurname { get; set;}
    public string AccountEmail { get; set;}
    public int AccountRole { get; set; } // 0 normal user 1 admin
    public string AccountPassword { get; set;}
    public int AccountStatus { get; set; }
    public int AccountWallet { get; set; }
    public string AccountIdentity { get; set; }
    public List<ProductCategoryResponse> ProductCategories { get; set; }
}

public class AccountResponse : BaseResponse
{
    //public long AccountId { get; set; }
    public string AccountName { get; set; }
    public string AccountSurname { get; set; }
    public string AccountEmail { get; set; }
    public int AccountRole { get; set; } // 0 normal user 1 admin
    public string AccountPassword { get; set; }
    public int AccountStatus { get; set; }
    public int AccountWallet { get; set; }
    public List<ProductCategoryResponse> ProductCategories { get; set; }
}