using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wunderlist.Models;

namespace Wunderlist.Service.Interfaces
{
    public interface IRoleService
    {
        void Add(Role entity);
        void Update(Role entity);
        void Delete(Role entity);
        void Delete(string id);
        Role GetById(int id);
        IEnumerable<Role> GetAll();
        Role GetByName(string roleName);
    }
}
