using Blogy.Entities.Concrete.Common;

namespace Blogy.Entities.Concrete;

public class Category : BaseEntity
{
    public string Name { get; set; }
    public virtual List<Blog> Blogs { get; set; }
}
