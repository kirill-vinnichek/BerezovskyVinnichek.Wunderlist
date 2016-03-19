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
    [HandleError()]
    [System.Web.Http.Authorize]
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
            var unfinishedTasks = _taskService.GetInStatus(userId, taskListId, ToDoItemStatus.Unfinished).OrderBy(x=>x.NumberInList);
            var completedTasks = _taskService.GetInStatus(userId, taskListId, ToDoItemStatus.Сompleted).OrderBy(x => x.NumberInList);
            return Ok(new { unfinishedTasks = unfinishedTasks, completedTasks = completedTasks });
        }

        // GET api/<controller>/5
        public IHttpActionResult GetTask(int taskListId, int taskId)
        {
            var userId = User.Identity.GetUserId<int>();
            var task = _taskService.GetById(userId, taskId);
            if (task != null)
                return Ok(Mapper.Map<ToDoItemViewModel>(task));
            else
                return NotFound();
        }

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
        public IHttpActionResult Put(int id, [FromBody] ToDoItemViewModel task)
        {
            try
            {
                _taskService.Update(Mapper.Map<ToDoItem>(task));
                return Ok(task);
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }

        }

        // DELETE api/<controller>/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                _taskService.Delete(id);
                return Ok();
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }
    }
}