using Blogy.Entities.Concrete.Common;

namespace Blogy.Entities.Concrete;

public class Tag : BaseEntity
{
    public string Name { get; set; }
    public virtual List<BlogTag> BlogTags { get; set; }
}
