using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wunderlist.Web.Models
{
    public class OwinRole:IRole<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public OwinRole()
        {

        }

        public OwinRole(string name)
        {
            Name = name;
        }
    }
}