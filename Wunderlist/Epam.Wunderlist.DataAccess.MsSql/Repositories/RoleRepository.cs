using Epam.Wunderlist.DataAccess.Interfaces;
using Epam.Wunderlist.DataAccess.MsSql.Infrastructure;
using Epam.Wunderlist.Models;

namespace Epam.Wunderlist.DataAccess.MsSql.Repositories
{
    public class RoleRepository:RepositoryBase<Role>,IRoleRepository
    {
        public RoleRepository(IDatabaseFactory dbF) : base(dbF) { }
    }
}
