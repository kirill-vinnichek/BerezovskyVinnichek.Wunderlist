using System.Collections.Generic;
using Epam.Wunderlist.DataAccess.Interfaces;
using Epam.Wunderlist.DataAccess.Interfaces.Infrastructure;
using Epam.Wunderlist.Models;
using Epam.Wunderlist.Services.Interfaces;
using System;

namespace Epam.Wunderlist.Services.Services
{
    public class UserService:IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _repository;
        private readonly ILoggerService _loggerService;

        public UserService(IUnitOfWork uoW, IUserRepository rep, ILoggerService logger)
        {
            _repository = rep;
            _unitOfWork = uoW;
            _loggerService = logger;
        }
        public void Create(User entity)
        {
            try
            {
                _loggerService.Trace("Add User started");
                entity.UserPhotoId = 1;
                _repository.Add(entity);
                _unitOfWork.Commit();
                _loggerService.Trace("Add User finished");
            }
            catch (Exception exeption)
            {
                _loggerService.Error(exeption.Message);
                throw;
            }
        }

        public void Delete(User entity)
        {
            try
            {
                _loggerService.Trace("Delete User started");
                var user = GetById(entity.Id);
                _repository.Delete(user);
                _unitOfWork.Commit();
                _loggerService.Trace("Delete User finished");
            }
            catch (Exception exeption)
            {
                _loggerService.Error(exeption.Message);
                throw;
            }
        }

        public IEnumerable<User> GetAll()
        {
            try
            {
                _loggerService.Trace("GetAll Users started");
                return _repository.GetAll();
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
                _loggerService.Trace("Delete User started");
                _repository.Delete(u => u.Id == id);
                _unitOfWork.Commit();
                _loggerService.Trace("Delete User finished");
            }
            catch (Exception exeption)
            {
                _loggerService.Error(exeption.Message);
                throw;
            }

        }

        public User GetByEmail(string email)
        {
            try
            {
                _loggerService.Trace("GetByEmail User started");
                return _repository.Get(u => u.Email.Contains(email));
            }
            catch (Exception exeption)
            {
                _loggerService.Error(exeption.Message);
                throw;
            }
        }

        public User GetById(int id)
        {
            try
            {
                _loggerService.Trace("GetById User started");
                return _repository.GetById(id);
            }
            catch (Exception exeption)
            {
                _loggerService.Error(exeption.Message);
                throw;
            }
        }


        public void Update(User entity)
        {
            try
            {
                _loggerService.Trace("Update User started");
                _repository.Update(entity);
                _unitOfWork.Commit();
                _loggerService.Trace("Update User finished");
            }
            catch (Exception exeption)
            {
                _loggerService.Error(exeption.Message);
                throw;
            }
        }
    }
}
