using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Epam.Wunderlist.Web.ViewModels
{
    public class UserInfo
    {
        public int Id { get;set; }
        public string UserName { get; set; }
        public string Email { get; set; }

        public string UserPasswordHash { get; set; }
        public int UserPhotoId { get; set; }
        public string UserPhotoUrl { get; set; }

       // public virtual ICollection<Role> UserRoles { get; set; }
    }
}