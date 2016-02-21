using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Wunderlist.Data.Infrastructure;
using Wunderlist.Data.Repositories;
using Wunderlist.Models;
using Wunderlist.Service.Interfaces;

namespace Wunderlist.Service.Services
{
    public class UserService:IUserService
    {
        private readonly IUnitOfWork uoWork;
        private readonly IUserRepository repository;

        public UserService(IUnitOfWork uoW, IUserRepository rep)
        {
            this.repository = rep;
            this.uoWork = uoW;
        }
        public void Add(User entity)
        {
            repository.Add(entity);
            uoWork.Commit();
        }

        public void Delete(User entity)
        {
            var user = GetById(entity.Id);
            repository.Delete(user);
            uoWork.Commit();
        }

        public IEnumerable<User> GetAll()
        {
            return repository.GetAll();
        }

        public void Delete(string id)
        {
            repository.Delete(u=>u.Id==id);
            uoWork.Commit();
        }

        public User GetByEmail(string email)
        {
            return repository.Get(u => u.Email.Contains(email));
        }

        public User GetById(string id)
        {
            return repository.GetById(id);
        }


        public void Update(User entity)
        {
            repository.Update(entity);
            uoWork.Commit();
        }
    }
}
