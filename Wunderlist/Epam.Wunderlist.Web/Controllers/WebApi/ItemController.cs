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
    public class ItemController : ApiController
    {
        private readonly IToDoItemListService _taskListService;
        private readonly IToDoItemService _taskService;

        public ItemController(IToDoItemListService taskListService, IToDoItemService taskService)
        {
            _taskListService = taskListService;
            _taskService = taskService;
        }

        // GET api/<controller>
        public IHttpActionResult Get(int taskListId)
        {
            var userId = User.Identity.GetUserId<int>();
            var unfinishedTasks = _taskService.GetInStatus(userId,taskListId, ToDoItemStatus.Unfinished);
            var completedTasks = _taskService.GetInStatus(userId,taskListId, ToDoItemStatus.Сompleted);
            return Ok(new { unfinishedTasks = unfinishedTasks, completedTasks = completedTasks });
        }

        // GET api/<controller>/5
      

        // POST api/<controller>
        public IHttpActionResult Post([FromBody] ToDoItemViewModel task)
        {
            try
            {
                task.CurrentState = ToDoItemStatus.Unfinished;
                task.UserId = User.Identity.GetUserId<int>();
                var t = Mapper.Map<ToDoItem>(task);
                _taskService.Add(t);
                return Ok(Mapper.Map<ToDoItemViewModel>(t));
            }
            catch
            {
                return InternalServerError();
            }

        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}