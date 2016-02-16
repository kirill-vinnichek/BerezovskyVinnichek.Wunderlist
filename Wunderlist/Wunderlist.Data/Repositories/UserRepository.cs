using SignalR.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wunderlist.Models;

namespace Wunderlist.Data.Repositories
{
    public class UserRepository : RepositoryBase<AppUser>, IUserRepository
    {
        public UserRepository(IDatabaseFactory dbF) : base(dbF) { }
    }

    public interface IUserRepository : IRepository<AppUser> { }
}
