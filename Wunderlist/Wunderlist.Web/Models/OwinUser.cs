using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wunderlist.Web.Models
{
    public class OwinUser : IUser
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string UserPasswordHash { get; set; }
        public string Email { get; set; }
        public OwinUser()
        {
            Id = Guid.NewGuid().ToString();
        }

        public OwinUser(string name):this()
        {
            UserName = name;
        }
    }
}