using System.Collections.Generic;
using Epam.Wunderlist.Models;

namespace Epam.Wunderlist.Services.Interfaces
{
    public interface IToDoItemService
    {
        void Add(ToDoItem entity);
        void Update(ToDoItem entity);
        void Delete(ToDoItem entity);
        void Delete(int id);
        ToDoItem GetById(int id);
        IEnumerable<ToDoItem> GetAll(int id);
        void ChangeStatus(int id, ToDoItemStatus status);
    }
}
