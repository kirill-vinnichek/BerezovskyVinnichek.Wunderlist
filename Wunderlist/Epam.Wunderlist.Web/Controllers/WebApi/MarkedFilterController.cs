﻿using AutoMapper;
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
    public class MarkedFilterController : ApiController
    {
        private readonly IToDoItemListService _taskListService;
        private readonly IToDoItemService _taskService;

        public MarkedFilterController(IToDoItemListService taskListService, IToDoItemService taskService)
        {
            _taskListService = taskListService;
            _taskService = taskService;
        }

        public IHttpActionResult Get()
        {
            List<FilteredToDoItemList> markedToDoList = new List<FilteredToDoItemList>();
            var userId = User.Identity.GetUserId<int>();
            var markedTasks = Mapper.Map<IEnumerable<ToDoItemViewModel>>(_taskService.GetMarked(userId));
            var groupTasks = markedTasks.GroupBy(t => t.ToDoItemListId);
            foreach(var grt in groupTasks)
            {
                var taskList = Mapper.Map<FilteredToDoItemList>(_taskListService.GetById(userId,grt.Key));
                taskList.TaskList = grt;
                taskList.ItemsCount = grt.Count();
                markedToDoList.Add(taskList);
            }
            return Ok(markedToDoList);
        }
        
    }
}