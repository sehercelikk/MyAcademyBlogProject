using Blogy.Entities.Concrete.Common;

namespace Blogy.Entities.Concrete;

public class BlogTag : BaseEntity
{
    public int BlogId { get; set; }
    public virtual Blog Blog { get; set; }
    public int TagId { get; set; }
    public virtual Tag Tag { get; set; }
}
