using System.Collections.Generic;
using Epam.Wunderlist.DataAccess.Interfaces;
using Epam.Wunderlist.DataAccess.Interfaces.Infrastructure;
using Epam.Wunderlist.Models;
using Epam.Wunderlist.Services.Interfaces;

namespace Epam.Wunderlist.Services.Services
{
    public class ToDoItemService : IToDoItemService
    {
        private readonly IToDoItemRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public ToDoItemService(IToDoItemRepository rep, IUnitOfWork uow)
        {
            this._repository = rep;
            this._unitOfWork = uow;
        }

        public void Add(ToDoItem entity)
        {
            _repository.Add(entity);
            _unitOfWork.Commit();
        }

        public void ChangeStatus(int id, ToDoItemStatus status)
        {
            var task = GetById(id);
            task.CurrentState = status;
            Update(task);
        }

        public void Delete(int id)
        {
            _repository.Delete(t=>t.Id==id);
            _unitOfWork.Commit();
        }

        public void Delete(ToDoItem entity)
        {
            var toDoItem = GetById(entity.Id);
            _repository.Delete(toDoItem);
            _unitOfWork.Commit();
        }

        public IEnumerable<ToDoItem> GetAll(int id)
        {
            return _repository.GetMany(t => t.ToDoItemListId == id);
        }

        public ToDoItem GetById(int id)
        {
            return _repository.GetById(id);
        }



        public void Update(ToDoItem entity)
        {
            _repository.Update(entity);
            _unitOfWork.Commit();
        }
    }
}
