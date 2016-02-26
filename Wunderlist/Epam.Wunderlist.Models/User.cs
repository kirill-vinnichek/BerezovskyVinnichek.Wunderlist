using System;
using System.Collections.Generic;

namespace Epam.Wunderlist.Models
{
    public class User 
    {       
        public Int16 Id { get;protected set; }
        public string UserName { get; set; }
        public string Email { get; set; }

        public string UserPasswordHash { get; set; }
        public int UserProfileId { get; set; }

        public virtual ICollection<Role> UserRoles{ get; set; }


    }
}
