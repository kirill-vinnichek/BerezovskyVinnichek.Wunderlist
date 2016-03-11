using System.Linq;
using Epam.Wunderlist.DataAccess.Interfaces;
using Epam.Wunderlist.DataAccess.Interfaces.Infrastructure;
using Epam.Wunderlist.Models;
using Epam.Wunderlist.Services.Interfaces;

namespace Epam.Wunderlist.Services.Services
{
    public class ToDoItemListService:IToDoItemListService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IToDoItemListRepository _repository;
        private readonly IToDoItemService _toDoItemService;

        public ToDoItemListService(IUnitOfWork uoW, IToDoItemListRepository rep, IToDoItemService itemService)
        {
            this._repository = rep;
            this._unitOfWork = uoW;
            this._toDoItemService = itemService;
        }

        public void Add(ToDoItemList entity)
        {
            _repository.Add(entity);
            _unitOfWork.Commit();
        }

        public void Update(ToDoItemList entity)
        {
            _repository.Update(entity);
            _unitOfWork.Commit();
        }

        public void Delete(ToDoItemList entity)
        {
            var category = GetById(entity.Id);
            _repository.Delete(category);
            _unitOfWork.Commit();
        }

        public void Delete(int id)
        {
            _repository.Delete(c=>c.Id==id);
            _unitOfWork.Commit();
        }

        public ToDoItemList GetById(int id)
        {
            return _repository.GetById(id);
        }

        //public void ChangeItemsOrder(int id, int newNumberInList)
        //{
        //    var item = _toDoItemService.GetById(id);
        //    var itemList = GetById(item.ToDoItemListId);
        //    var list = itemList.ToDoItemsList.OrderBy(t => t.NumberInList).ToList();
        //    if (item.NumberInList < newNumberInList)
        //    {
        //        for (int i = item.NumberInList + 1; i < newNumberInList; i++)
        //        {
        //            list[i].NumberInList = list[i-1].NumberInList;
        //        }            
        //    }
        //    if (item.NumberInList > newNumberInList)
        //    {
        //        for (int i = item.NumberInList - 1; i > newNumberInList; i--)
        //        {
        //            list[i].NumberInList = list[i + 1].NumberInList;
        //        }
        //    }
        //    list[item.NumberInList].NumberInList = newNumberInList;
        //    itemList.ToDoItemsList = list;
        //    Update(itemList);
        //}
    }
}
