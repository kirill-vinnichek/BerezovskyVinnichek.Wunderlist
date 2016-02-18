using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wunderlist.Web.Models
{
    public class OwinRole:IRole
    {
        public string Id { get;}
        public string Name { get; set; }
    }
}