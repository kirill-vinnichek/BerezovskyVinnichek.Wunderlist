using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wunderlist.Data.Infrastructure;
using Wunderlist.Data.Repositories;
using Wunderlist.Models;
using Wunderlist.Service.Infrastructure;

namespace Wunderlist.Service.Services
{
    public class UserService:BaseService<User>,IUserService
    {
        public UserService(IUnitOfWork uof, IUserRepository userRepository):base(uof,userRepository)
        {

        }

        public User GetByEmail(string email)
        {
            return Rep.Get(u => u.Email.Contains(email));
        }
    }

    public interface IUserService : IService<User>
    {
        User GetByEmail(string email);
    }
}
