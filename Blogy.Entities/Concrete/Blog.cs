using Blogy.Entities.Concrete.Common;

namespace Blogy.Entities.Concrete;

public class Blog : BaseEntity
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string CoverImage { get; set; }
    public string BlogImage1 { get; set; }
    public string BlogImage2 { get; set; }

    public int CategoryId { get; set; }
    public virtual Category Category { get; set; }

    public virtual List<BlogTag> BlogTags { get; set; }

    public int WriterId { get; set; }
    public virtual AppUser Writer { get; set; }
    public virtual List<Comment> Comments { get; set; }
}
