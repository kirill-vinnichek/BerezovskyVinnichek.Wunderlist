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
    public class UserController : ApiController
    {
        private IUserService _userService;
        private IImageService _imageService;

        public UserController(IUserService userService, IImageService imageService)
        {
            _userService = userService;
            _imageService = imageService;
        }

        [HttpGet]
        // GET api/<controller>
        public IHttpActionResult Get()
        {
            var user =Mapper.Map<UserInfo>(_userService.GetById(User.Identity.GetUserId<int>()));
            if (user != null)
            {
                user.UserPhotoUrl = _imageService.GetImage(user.UserPhotoId)?.Url;
                return Ok(user);
            }
            return NotFound();
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost]
        // POST api/<controller>
        public IHttpActionResult Post([FromBody] UserInfo user)
        {
            if (ModelState.IsValid)
            {
                _userService.Update(Mapper.Map<User>(user));
            }
            return Ok();
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