using Microsoft.AspNet.Identity;
using System.Collections.Generic;

namespace Wunderlist.Models
{
    public class User 
    {       
        public string Id { get; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }

        public string UserPassword { get; set; }
        public int UserProfileId { get; set; }

        public virtual ICollection<Role> UserRoles{ get; set; }


    }
}
