using Epam.Wunderlist.Models;
using System.Collections.Generic;

namespace Epam.Wunderlist.Services.Interfaces
{
    public interface IToDoItemListService
    {
        void Add(ToDoItemList entity);
        void Update(ToDoItemList entity);
        void Delete(ToDoItemList entity);
        void Delete(int id);
        ToDoItemList GetById(int userId,int id);
        IEnumerable<ToDoItemList> GetAll(int userId);       
        // void ChangeItemsOrder(int id, int newNumberInList);
    }
}
