using Microsoft.AspNet.Identity;


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wunderlist.Models
{
    public class User : IUser
    {       
        public string Id { get; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }

        public string UserPassword { get; set; }
        public int UserProfileId { get; set; }

        public virtual ICollection<Role> UserRoles{ get; set; }


    }
}
