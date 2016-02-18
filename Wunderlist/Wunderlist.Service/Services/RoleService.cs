using System;
using Wunderlist.Data.Infrastructure;
using Wunderlist.Data.Repositories;
using Wunderlist.Models;
using Wunderlist.Service.Infrastructure;

namespace Wunderlist.Service
{
    public class RoleService:BaseService<Role>,IRoleService
    {
        public RoleService(IUnitOfWork uof,IRoleRepository roleRepository):base(uof,roleRepository)
        {

        }

        public Role GetByName(string roleName)
        {
            return Rep.Get(r => r.Name.ToLower() == roleName.ToLower());
        }
    }

    public interface IRoleService : IService<Role>
    {
        Role GetByName(string roleName);
    }
}
