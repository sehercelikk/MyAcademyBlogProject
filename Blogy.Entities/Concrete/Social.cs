using Blogy.Entities.Concrete.Common;

namespace Blogy.Entities.Concrete;

public class Social : BaseEntity
{
    public string Name { get; set; }
    public string Url { get; set; }
    public string Icon { get; set; }
}
