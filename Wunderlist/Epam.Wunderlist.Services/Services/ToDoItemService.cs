using System;
using System.Collections.Generic;
using Epam.Wunderlist.DataAccess.Interfaces;
using Epam.Wunderlist.DataAccess.Interfaces.Infrastructure;
using Epam.Wunderlist.Models;
using Epam.Wunderlist.Services.Interfaces;
using System.Linq;

namespace Epam.Wunderlist.Services.Services
{
    public class ToDoItemService : IToDoItemService
    {
        private readonly IToDoItemRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILoggerService _loggerService;

        public ToDoItemService(IToDoItemRepository rep, IUnitOfWork uow, ILoggerService logger)
        {
            _repository = rep;
            _unitOfWork = uow;
            _loggerService = logger;
        }

        public void Add(ToDoItem entity)
        {
            try
            {
                _loggerService.Trace("Add ToDoItem started");
                _repository.Add(entity);
                _unitOfWork.Commit();
                _loggerService.Trace("Add ToDoItem finished");
            }
            catch(Exception exeption)
            {
                _loggerService.Error(exeption.Message);
                throw;
            }
        }

        public void ChangeStatus(int userId, int id, ToDoItemStatus state)
        {
            try
            {
                //TODO: Выкидывать Exception т.к. не свою обновляешь
                _loggerService.Trace("ChangeStatus ToDoItem started");
                var task = _repository.GetById(id);
                if (task?.UserId == userId)
                {
                    task.CurrentState = state;
                    Update(task);
                }
                _loggerService.Trace("Delete ToDoItem finished");
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
                _loggerService.Trace("Delete ToDoItem started");
                _repository.Delete(t => t.Id == id);
                _unitOfWork.Commit();
                _loggerService.Trace("Delete ToDoItem finished");
            }
            catch (Exception exeption)
            {
                _loggerService.Error(exeption.Message);
                throw;
            }
        }

        public void Delete(ToDoItem entity)
        {
            try
            {
                _loggerService.Trace("Delete ToDoItem started");
                Delete(entity.Id);
                _loggerService.Trace("Delete ToDoItem finished");
            }
            catch (Exception exeption)
            {
                _loggerService.Error(exeption.Message);
                throw;
            }
        }

        public IEnumerable<ToDoItem> GetAll(int userId, int taskListid)
        {
            try
            {
                _loggerService.Trace("GetAll ToDoItems started");
                return _repository.GetMany(t => t.ToDoItemListId == taskListid).Where(t => t.UserId == userId);
            }
            catch (Exception exeption)
            {
                _loggerService.Error(exeption.Message);
                throw;
            }
        }

        public ToDoItem GetById(int userId, int id)
        {
            try
            {
                _loggerService.Trace("GetById ToDoItem started");
                var task = _repository.GetById(id);
                return task?.UserId == userId ? task : null;
            }
            catch (Exception exeption)
            {
                _loggerService.Error(exeption.Message);
                throw;
            }

        }


        public IEnumerable<ToDoItem> GetInStatus(int userId, int taskListid, ToDoItemStatus state)
        {
            try
            {
                _loggerService.Trace("GetInStatus ToDoItem started");
                return _repository.GetMany(t => t.ToDoItemListId == taskListid && t.CurrentState == state).Where(t => t.UserId == userId);
            }
            catch (Exception exeption)
            {
                _loggerService.Error(exeption.Message);
                throw;
            }

        }

        public IEnumerable<ToDoItem> GetMarked(int userId)
        {
            return _repository.GetMany(t => t.UserId == userId && t.IsMarked && t.CurrentState == ToDoItemStatus.Unfinished);
        }

        public IEnumerable<ToDoItem> Search(int userId, string search)
        {
            var s = search.ToLower();
            return _repository.GetMany(t => t.UserId == userId && (t.Name.ToLower().Contains(s) || t.Text.ToLower().Contains(s)) && t.CurrentState == ToDoItemStatus.Unfinished);
        }

        public void Update(ToDoItem entity)
        {
            try
            {
                _loggerService.Trace("Update ToDoItem started");
                _repository.Update(entity);
                _unitOfWork.Commit();
                _loggerService.Trace("Update ToDoItem finished");
            }
            catch (Exception exeption)
            {
                _loggerService.Error(exeption.Message);
                throw;
            }
        }


    }
}
