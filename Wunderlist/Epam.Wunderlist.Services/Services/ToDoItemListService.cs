using System;
using System.Collections.Generic;
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
        private readonly ILoggerService _loggerService;

        public ToDoItemListService(IUnitOfWork uoW, IToDoItemListRepository rep, IToDoItemService itemService, ILoggerService logger)
        {
            _repository = rep;
            _unitOfWork = uoW;
            _toDoItemService = itemService;
            _loggerService = logger;
        }

        public void Add(ToDoItemList entity)
        {
            try
            {
                _loggerService.Trace("Add ToDoItemList started");
                _repository.Add(entity);
                _unitOfWork.Commit();
                _loggerService.Trace("Add ToDoItemList finished");
            }
            catch (Exception exeption)
            {
                _loggerService.Error(exeption.Message);
                throw;
            }
        }

        public void Update(ToDoItemList entity)
        {
            try
            {
                _loggerService.Trace("Update ToDoItemList started");
                _repository.Update(entity);
                _unitOfWork.Commit();
                _loggerService.Trace("Update ToDoItemList finished");
            }
            catch (Exception exeption)
            {
                _loggerService.Error(exeption.Message);
                throw;
            }

        }

        public void Delete(ToDoItemList entity)
        {
            try
            {
                _loggerService.Trace("Delete ToDoItemList started");
                Delete(entity.Id);
                _loggerService.Trace("Delete ToDoItemList finished");
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
                _loggerService.Trace("Delete ToDoItemList started");
                _repository.Delete(c => c.Id == id);
                _unitOfWork.Commit();
                _loggerService.Trace("Delete ToDoItemList finished");
            }
            catch (Exception exeption)
            {
                _loggerService.Error(exeption.Message);
                throw;
            }
        }

        public ToDoItemList GetById(int userId,int id)
        {
            try
            {
                _loggerService.Trace("GetById ToDoItemList started");
                var taskList = _repository.GetById(id);
                return taskList?.UserId == userId ? taskList : null;
            }
            catch (Exception exeption)
            {
                _loggerService.Error(exeption.Message);
                throw;
            }
        }

        public IEnumerable<ToDoItemList> GetAll(int userId)
        {
            try
            {
                _loggerService.Trace("GetAll ToDoItemLists started");
                return _repository.GetMany(i => i.UserId == userId);
            }
            catch (Exception exeption)
            {
                _loggerService.Error(exeption.Message);
                throw;
            }

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
