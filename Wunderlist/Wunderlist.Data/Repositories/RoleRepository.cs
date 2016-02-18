using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SignalR.Data.Infrastructure;
using Wunderlist.Models;

namespace Wunderlist.Data.Repositories
{
    public class RoleRepository:RepositoryBase<Role>,IRoleRepository
    {
        public RoleRepository(IDatabaseFactory dbF) : base(dbF) { }
    }

    interface IRoleRepository : IRepository<Role> { }

}
