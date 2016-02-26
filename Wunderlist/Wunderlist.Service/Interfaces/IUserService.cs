using System.Collections.Generic;
using Epam.Wunderlist.Models;

namespace Epam.Wunderlist.Services.Interfaces
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
