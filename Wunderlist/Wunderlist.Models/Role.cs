using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

namespace Wunderlist.Models
{
    public class Role 
    {
        public string Id { get; }

        public string Name { get; set; }

        public virtual ICollection<User> Users{get;set;} 

    }
}
