﻿using Epam.Wunderlist.Services.Interfaces;
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
    public class OrderController : ApiController
    {
        private readonly IToDoItemService _taskService;

        public OrderController(IToDoItemService taskService)
        {
            _taskService = taskService;
        }

        public IHttpActionResult Put([FromBody]OrderViewModel order)
        {
            var userId = User.Identity.GetUserId<int>();
            ChangeOrder(userId, order.Completed);
            ChangeOrder(userId, order.Unfinished);
            return Ok();
        }

        private void ChangeOrder(int userId, int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                var task = _taskService.GetById(userId, array[i]);
                task.NumberInList = i;
                _taskService.Update(task);
            }
        }

    }
}