using System.Collections.Generic;
using Epam.Wunderlist.DataAccess.Interfaces;
using Epam.Wunderlist.DataAccess.Interfaces.Infrastructure;
using Epam.Wunderlist.Models;
using Epam.Wunderlist.Services.Interfaces;

namespace Epam.Wunderlist.Services.Services
{
    public class UserService:IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _repository;

        public UserService(IUnitOfWork uoW, IUserRepository rep)
        {
            this._repository = rep;
            this._unitOfWork = uoW;
        }
        public void Add(User entity)
        {
            _repository.Add(entity);
            _unitOfWork.Commit();
        }

        public void Delete(User entity)
        {
            var user = GetById(entity.Id);
            _repository.Delete(user);
            _unitOfWork.Commit();
        }

        public IEnumerable<User> GetAll()
        {
            return _repository.GetAll();
        }

        public void Delete(int id)
        {
            _repository.Delete(u=>u.Id==id);
            _unitOfWork.Commit();
        }

        public User GetByEmail(string email)
        {
            return _repository.Get(u => u.Email.Contains(email));
        }

        public User GetById(int id)
        {
            return _repository.GetById(id);
        }


        public void Update(User entity)
        {
            _repository.Update(entity);
            _unitOfWork.Commit();
        }
    }
}
