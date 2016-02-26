using Epam.Wunderlist.DataAccess.Interfaces;
using Epam.Wunderlist.DataAccess.MsSql.Infrastructure;
using Epam.Wunderlist.Models;

namespace Epam.Wunderlist.DataAccess.MsSql.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(IDatabaseFactory dbF) : base(dbF) { }
    }
}
