using Blogy.Entities.Concrete.Common;

namespace Blogy.Entities.Concrete;

public class BlogTag : BaseEntity
{
    public int BlogId { get; set; }
    public Blog Blog { get; set; }
    public int TagId { get; set; }
    public Tag Tag { get; set; }
}
