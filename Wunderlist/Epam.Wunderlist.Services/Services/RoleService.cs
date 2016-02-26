using System.Collections.Generic;
using Epam.Wunderlist.DataAccess.Interfaces;
using Epam.Wunderlist.DataAccess.Interfaces.Infrastructure;
using Epam.Wunderlist.Models;
using Epam.Wunderlist.Services.Interfaces;

namespace Epam.Wunderlist.Services.Services
{
    public class RoleService:IRoleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRoleRepository _repository;

        public RoleService(IUnitOfWork uow,IRoleRepository rep)
        {
            this._repository = rep;
            this._unitOfWork = uow;
        }

        public void Add(Role entity)
        {
            _repository.Add(entity);
            _unitOfWork.Commit();
        }

        public void Delete(int id)
        {
            _repository.Delete(r=>r.Id==id);
            _unitOfWork.Commit();
        }

        public void Delete(Role entity)
        {
            var role = GetById(entity.Id);
            _repository.Delete(role);
            _unitOfWork.Commit();
        }

        public IEnumerable<Role> GetAll()
        {
            return _repository.GetAll();
        }


        public Role GetByName(string roleName)
        {
            return _repository.Get(r => r.Name.ToLower() == roleName.ToLower());
        }

        public void Update(Role entity)
        {
            _repository.Update(entity);
            _unitOfWork.Commit();
        }

        public Role GetById(int id)
        {
            return _repository.GetById(id);
        }


    }


}
