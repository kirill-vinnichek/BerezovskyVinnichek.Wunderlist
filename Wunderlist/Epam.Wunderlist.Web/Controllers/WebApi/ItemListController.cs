using AutoMapper;
using Epam.Wunderlist.Models;
using Epam.Wunderlist.Services.Interfaces;
using Epam.Wunderlist.Web.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace Epam.Wunderlist.Web.Controllers.WebApi
{
    [System.Web.Http.Authorize]
    [HandleError()]
    public class ItemListController : ApiController
    {

        private readonly IToDoItemListService _itemlistService;
        public ItemListController(IToDoItemListService itemlistService)
        {
            _itemlistService = itemlistService;
        }

        [System.Web.Http.HttpGet]
        public IHttpActionResult GetItemlists()
        {
            return Ok(_itemlistService.GetAll(User.Identity.GetUserId<int>()));
        }

        [System.Web.Http.HttpGet]
        public IHttpActionResult GetItemlist(int id)
        {
            var userId = User.Identity.GetUserId<int>();
            var itemList = _itemlistService.GetById(userId,id);
            if (itemList == null)
                return NotFound();
            return Ok(Mapper.Map<ToDoItemListViewModel>(itemList));
        }

        [System.Web.Http.HttpPost]
        public IHttpActionResult CreateItemList([FromBody] ToDoItemListViewModel itemList)
        {
            try
            {
                itemList.UserId = User.Identity.GetUserId<int>();
                var itl = Mapper.Map<ToDoItemList>(itemList);                
                _itemlistService.Add(itl);
                return Ok(Mapper.Map<ToDoItemListViewModel>(itl));
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }

        [System.Web.Http.HttpPut]
        public IHttpActionResult UpdateItemList([FromBody] ToDoItemListViewModel itemList)
        {
            try
            {
                var itl = Mapper.Map<ToDoItemList>(itemList);
                itemList.UserId = User.Identity.GetUserId<int>();
                _itemlistService.Update(itl);
                return Ok(itemList);
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }

        [System.Web.Http.HttpDelete]
        [System.Web.Http.AcceptVerbs("DELETE")]
        public IHttpActionResult DeleteItemList(int id)
        {
            try
            {
                _itemlistService.Delete(id);
                return Ok();
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }
    }
}