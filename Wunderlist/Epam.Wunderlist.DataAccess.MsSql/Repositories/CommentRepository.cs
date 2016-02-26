using Epam.Wunderlist.DataAccess.Interfaces;
using Epam.Wunderlist.DataAccess.MsSql.Infrastructure;
using Epam.Wunderlist.Models;

namespace Epam.Wunderlist.DataAccess.MsSql.Repositories
{
    public class CommentRepository:RepositoryBase<Comment>,ICommentRepository
    {
        public CommentRepository(IDatabaseFactory dbF) : base(dbF) { }
    }
}
