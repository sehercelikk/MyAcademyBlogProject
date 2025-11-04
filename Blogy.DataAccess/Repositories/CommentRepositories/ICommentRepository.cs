using Blogy.DataAccess.Repositories.GenericRepositories;
using Blogy.Entities.Concrete;

namespace Blogy.DataAccess.Repositories.CommentRepositories;

public interface ICommentRepository : IGenericRepository<Comment>
{
}
