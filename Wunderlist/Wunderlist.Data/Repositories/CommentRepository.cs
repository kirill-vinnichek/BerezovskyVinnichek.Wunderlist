using Wunderlist.Data.Infrastructure;
using Wunderlist.Models;

namespace Wunderlist.Data.Repositories
{
    public class CommentRepository:RepositoryBase<Comment>,ICommentRepository
    {
        public CommentRepository(IDatabaseFactory dbF) : base(dbF) { }
    }

    public  interface ICommentRepository : IRepository<Comment> { }
}
