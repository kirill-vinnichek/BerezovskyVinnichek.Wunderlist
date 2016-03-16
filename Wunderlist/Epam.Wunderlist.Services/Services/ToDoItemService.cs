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

        public ToDoItemService(IToDoItemRepository rep, IUnitOfWork uow)
        {
            _repository = rep;
            _unitOfWork = uow;
        }

        public void Add(ToDoItem entity)
        {
            _repository.Add(entity);
            _unitOfWork.Commit();
        }

        public void ChangeStatus(int userId, int id, ToDoItemStatus state)
        {
            //TODO: Выкидывать Exception т.к. не свою обновляешь
            var task = _repository.GetById(id);
            if (task?.UserId == userId)
            {
                task.CurrentState = state;
                Update(task);
            }
        }

        public void Delete(int id)
        {
            _repository.Delete(t => t.Id == id);
            _unitOfWork.Commit();
        }

        public void Delete(ToDoItem entity)
        {
            Delete(entity.Id);
        }

        public IEnumerable<ToDoItem> GetAll(int userId, int taskListid)
        {
            return _repository.GetMany(t => t.ToDoItemListId == taskListid).Where(t => t.UserId == userId);
        }

        public ToDoItem GetById(int userId, int id)
        {
            var task = _repository.GetById(id);
            return task?.UserId == userId ? task : null;
        }


        public IEnumerable<ToDoItem> GetInStatus(int userId, int taskListid, ToDoItemStatus state)
        {
            return _repository.GetMany(t => t.ToDoItemListId == taskListid && t.CurrentState == state).Where(t => t.UserId == userId);
        }

        public IEnumerable<ToDoItem> GetMarked(int userId)
        {
            return _repository.GetMany(t => t.UserId == userId && t.IsMarked && t.CurrentState == ToDoItemStatus.Unfinished);
        }

        public void Update(ToDoItem entity)
        {
            _repository.Update(entity);
            _unitOfWork.Commit();
        }
    }
}
