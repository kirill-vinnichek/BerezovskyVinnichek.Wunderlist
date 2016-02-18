using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wunderlist.Web.Models
{
    public class OwinUser : IUser
    {
        public string Id { get; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
    }
}