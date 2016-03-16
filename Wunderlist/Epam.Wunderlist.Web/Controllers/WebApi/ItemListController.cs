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


namespace Epam.Wunderlist.Web.Controllers.WebApi
{
    [Authorize]
    public class ItemListController : ApiController
    {

        private readonly IToDoItemListService _itemlistService;
        public ItemListController(IToDoItemListService itemlistService)
        {
            _itemlistService = itemlistService;
        }

        [HttpGet]
        public IHttpActionResult GetItemlists()
        {
            return Ok(_itemlistService.GetAll(User.Identity.GetUserId<int>()));
        }

        [HttpGet]
        public IHttpActionResult GetItemlist(int id)
        {
            var userId = User.Identity.GetUserId<int>();
            var itemList = _itemlistService.GetById(userId,id);
            if (itemList == null)
                return NotFound();
            return Ok(Mapper.Map<ToDoItemListViewModel>(itemList));
        }

        [HttpPost]
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

        [HttpPut]
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

        [HttpDelete]
        [AcceptVerbs("DELETE")]
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