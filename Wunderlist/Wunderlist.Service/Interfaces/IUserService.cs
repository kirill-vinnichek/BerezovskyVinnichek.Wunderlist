using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Wunderlist.Models;

namespace Wunderlist.Service.Interfaces
{
    public interface IUserService
    {
        void Add(User entity);
        void Update(User entity);
        void Delete(User entity);
        void Delete(int id);
        User GetById(int id);
        IEnumerable<User> GetAll();
        User GetByEmail(string email);
    }
}
