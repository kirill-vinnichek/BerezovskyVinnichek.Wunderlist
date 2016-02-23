using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wunderlist.Data.Infrastructure;
using Wunderlist.Data.Repositories;
using Wunderlist.Models;
using Wunderlist.Service.Interfaces;

namespace Wunderlist.Service.Services
{
    public class ToDoItemService : IToDoItemService
    {
        private readonly IToDoItemRepository repository;
        private readonly IUnitOfWork uoWork;

        public ToDoItemService(IToDoItemRepository rep, IUnitOfWork uow)
        {
            this.repository = rep;
            this.uoWork = uow;
        }

        public void Add(ToDoItem entity)
        {
            repository.Add(entity);
            uoWork.Commit();
        }

        public void Delete(int id)
        {
            repository.Delete(t=>t.ID==id);
            uoWork.Commit();
        }

        public void Delete(ToDoItem entity)
        {
            var toDoItem = GetById(entity.ID);
            repository.Delete(toDoItem);
            uoWork.Commit();
        }

        public IEnumerable<ToDoItem> GetAll(int id)
        {
            return repository.GetMany(t => t.CategoryId == id);
        }

        public ToDoItem GetById(int id)
        {
            return repository.GetById(id);
        }

        public void Update(ToDoItem entity)
        {
            repository.Update(entity);
            uoWork.Commit();
        }
    }
}
