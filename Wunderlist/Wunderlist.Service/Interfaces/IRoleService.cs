using System.Collections.Generic;
using Epam.Wunderlist.Models;

namespace Epam.Wunderlist.Services.Interfaces
{
    public interface IRoleService
    {
        void Add(Role entity);
        void Update(Role entity);
        void Delete(Role entity);
        void Delete(int id);
        Role GetById(int id);
        IEnumerable<Role> GetAll();
        Role GetByName(string roleName);
    }
}
