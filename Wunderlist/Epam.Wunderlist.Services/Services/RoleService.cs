using System.Collections.Generic;
using Epam.Wunderlist.DataAccess.Interfaces;
using Epam.Wunderlist.DataAccess.Interfaces.Infrastructure;
using Epam.Wunderlist.Models;
using Epam.Wunderlist.Services.Interfaces;
using System;

namespace Epam.Wunderlist.Services.Services
{
    public class RoleService:IRoleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRoleRepository _repository;
        private readonly ILoggerService _loggerService;

        public RoleService(IUnitOfWork uow,IRoleRepository rep, ILoggerService logger)
        {
            this._repository = rep;
            this._unitOfWork = uow;
            _loggerService = logger;
        }

        public void Add(Role entity)
        {
            try
            {
                _loggerService.Trace("Add Role started");
                _repository.Add(entity);
                _unitOfWork.Commit();
                _loggerService.Trace("Add Role finished");
            }
            catch (Exception exeption)
            {
                _loggerService.Error(exeption.Message);
                throw;
            }
        }

        public void Delete(int id)
        {
            try
            {
                _loggerService.Trace("Delete Role started");
                _repository.Delete(r => r.Id == id);
                _unitOfWork.Commit();
                _loggerService.Trace("Delete Role finished");
            }
            catch (Exception exeption)
            {
                _loggerService.Error(exeption.Message);
                throw;
            }
        }

        public void Delete(Role entity)
        {
            try
            {
                _loggerService.Trace("Delete Role started");
                var role = GetById(entity.Id);
                _repository.Delete(role);
                _unitOfWork.Commit();
                _loggerService.Trace("Delete Role finished");
            }
            catch (Exception exeption)
            {
                _loggerService.Error(exeption.Message);
                throw;
            }
        }

        public IEnumerable<Role> GetAll()
        {
            try
            {
                _loggerService.Trace("GetAll Roles started");
                return _repository.GetAll();
            }
            catch (Exception exeption)
            {
                _loggerService.Error(exeption.Message);
                throw;
            }
        }


        public Role GetByName(string roleName)
        {
            try
            {
                _loggerService.Trace("GetByName Role started");
                return _repository.Get(r => r.Name.ToLower() == roleName.ToLower());
            }
            catch (Exception exeption)
            {
                _loggerService.Error(exeption.Message);
                throw;
            }
        }

        public void Update(Role entity)
        {
            try
            {
                _loggerService.Trace("Update Role started");
                _repository.Update(entity);
                _unitOfWork.Commit();
                _loggerService.Trace("Update Role finished");
            }
            catch (Exception exeption)
            {
                _loggerService.Error(exeption.Message);
                throw;
            }
        }

        public Role GetById(int id)
        {
            try
            {
                _loggerService.Trace("GetById Role started");
                return _repository.GetById(id);
            }
            catch (Exception exeption)
            {
                _loggerService.Error(exeption.Message);
                throw;
            }
        }


    }


}
