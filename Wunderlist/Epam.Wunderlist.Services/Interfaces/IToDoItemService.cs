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
        ToDoItem GetById(int userId,int id);
        IEnumerable<ToDoItem> GetMarked(int userId);
        IEnumerable<ToDoItem> GetAll(int userId,int taskListid);
        IEnumerable<ToDoItem> Search(int userId, string search);
        IEnumerable<ToDoItem> GetInStatus(int userId,int taskListid,ToDoItemStatus state);
        void ChangeStatus(int userId,int id, ToDoItemStatus state);
    }
}
