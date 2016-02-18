using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wunderlist.Models
{
    public class AppUser : IUser<int>
    {       
        public int Id { get; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }

        public string UserPassword { get; set; }
        public int UserProfileId { get; set; }
    }
}
