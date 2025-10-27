using Microsoft.AspNetCore.Identity;

namespace Blogy.Entities.Concrete;

public class AppUser : IdentityUser<int>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string? Title { get; set; }
    public string? ImageUrl { get; set; }
    public List<Blog> Blogs { get; set; }
    public List<Comment> Comments { get; set; }
}
