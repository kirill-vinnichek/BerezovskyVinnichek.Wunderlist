using System;
using System.Collections.Generic;
using Wunderlist.Data.Infrastructure;
using Wunderlist.Data.Repositories;
using Wunderlist.Models;
using Wunderlist.Service.Interfaces;

namespace Wunderlist.Service
{
    public class RoleService:IRoleService
    {
        private readonly IUnitOfWork uoWork;
        private readonly IRoleRepository repository;

        public RoleService(IUnitOfWork uow,IRoleRepository rep)
        {
            this.repository = rep;
            this.uoWork = uow;
        }

        public void Add(Role entity)
        {
            repository.Add(entity);
            uoWork.Commit();
        }

        public void Delete(string id)
        {
            repository.Delete(r=>r.Id==id);
            uoWork.Commit();
        }

        public void Delete(Role entity)
        {
            var role = GetById(entity.Id);
            repository.Delete(role);
            uoWork.Commit();
        }

        public IEnumerable<Role> GetAll()
        {
            return repository.GetAll();
        }


        public Role GetByName(string roleName)
        {
            return repository.Get(r => r.Name.ToLower() == roleName.ToLower());
        }

        public void Update(Role entity)
        {
            repository.Update(entity);
            uoWork.Commit();
        }

        public Role GetById(int id)
        {
            return repository.GetById(id);
        }


    }


}
