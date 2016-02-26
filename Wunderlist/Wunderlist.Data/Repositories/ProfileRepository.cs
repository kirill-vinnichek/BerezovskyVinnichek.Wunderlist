using Epam.Wunderlist.DataAccess.Interfaces;
using Epam.Wunderlist.DataAccess.MsSql.Infrastructure;
using Epam.Wunderlist.Models;

namespace Epam.Wunderlist.DataAccess.MsSql.Repositories
{
    public class ProfileRepository:RepositoryBase<UserProfile>,IProfileRepository
    {
        public ProfileRepository(IDatabaseFactory dbF) : base(dbF) { }
    }
}
