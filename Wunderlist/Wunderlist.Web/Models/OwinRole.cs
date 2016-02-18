using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wunderlist.Web.Models
{
    public class OwinRole:IRole
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public OwinRole()
        {
            Id = Guid.NewGuid().ToString();
        }

        public OwinRole(string name):this()
        {
            Name = name;
        }
    }
}