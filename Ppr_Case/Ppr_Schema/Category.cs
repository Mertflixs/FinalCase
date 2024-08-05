using Ppr_Base.Schema;

namespace Ppr_Schema;

public class CategoryRequest : BaseRequest
{

    public long CategoryId { get; set; }
    public string CategoryName { get; set; }
    public string CategoryUrl { get; set; }
    public string CategoryTags { get; set; }
}

public class CategoryResponse : BaseResponse
{
    public long CategoryId { get; set; }
    public string CategoryName { get; set; }
    public string CategoryUrl { get; set; }
    public string CategoryTags { get; set; }
}