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
    public class ToDoItemListService:IToDoItemListService
    {
        private readonly IUnitOfWork uoWork;
        private readonly IToDoItemListRepository repository;
        private readonly IToDoItemService toDoItemService;

        public ToDoItemListService(IUnitOfWork uoW, IToDoItemListRepository rep, IToDoItemService itemService)
        {
            this.repository = rep;
            this.uoWork = uoW;
            this.toDoItemService = itemService;
        }

        public void Add(ToDoItemList entity)
        {
            repository.Add(entity);
            uoWork.Commit();
        }

        public void Update(ToDoItemList entity)
        {
            repository.Update(entity);
            uoWork.Commit();
        }

        public void Delete(ToDoItemList entity)
        {
            var category = GetById(entity.ID);
            repository.Delete(category);
            uoWork.Commit();
        }

        public void Delete(int id)
        {
            repository.Delete(c=>c.ID==id);
            uoWork.Commit();
        }

        public ToDoItemList GetById(int id)
        {
            return repository.GetById(id);
        }

        public void ChangeItemsOrder(int id, int newNumberInList)
        {
            var item = toDoItemService.GetById(id);
            var itemList = GetById(item.ToDoItemListId);
            var list = itemList.ToDoItemsList.OrderBy(t => t.NumberInList).ToList();
            if (item.NumberInList < newNumberInList)
            {
                for (int i = item.NumberInList + 1; i < newNumberInList; i++)
                {
                    list[i].NumberInList = list[i-1].NumberInList;
                }            
            }
            if (item.NumberInList > newNumberInList)
            {
                for (int i = item.NumberInList - 1; i > newNumberInList; i--)
                {
                    list[i].NumberInList = list[i + 1].NumberInList;
                }
            }
            list[item.NumberInList].NumberInList = newNumberInList;
            itemList.ToDoItemsList = list;
            Update(itemList);
        }
    }
}
