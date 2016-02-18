using Wunderlist.Data.Infrastructure;
using Wunderlist.Models;

namespace Wunderlist.Data.Repositories
{
    public class ProfileRepository:RepositoryBase<UserProfile>,IProfileRepository
    {
        public ProfileRepository(IDatabaseFactory dbF) : base(dbF) { }
    }

    public interface IProfileRepository : IRepository<UserProfile> { }
}
