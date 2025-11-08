using Blogy.Entities.Concrete.Common;

namespace Blogy.Entities.Concrete;

public class Comment :BaseEntity
{
    public string Content { get; set; }
    public int BlogId { get; set; }
    public virtual Blog Blog { get; set; }
    public int UserId { get; set; }
    public virtual AppUser User { get; set; }

}
