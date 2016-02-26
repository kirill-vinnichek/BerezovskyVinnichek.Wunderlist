using Epam.Wunderlist.Models;

namespace Epam.Wunderlist.Services.Interfaces
{
    public interface IToDoItemListService
    {
        void Add(ToDoItemList entity);
        void Update(ToDoItemList entity);
        void Delete(ToDoItemList entity);
        void Delete(int id);
        ToDoItemList GetById(int id);       
        void ChangeItemsOrder(int id, int newNumberInList);
    }
}
