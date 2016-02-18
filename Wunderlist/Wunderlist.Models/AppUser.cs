using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wunderlist.Models
{
    public class AppUser : IdentityUser
    {
        public AppUser()
        {
            UserBackground = new HashSet<Picture>();
        }

        public virtual  ICollection<Category> UserCategoryList{get ;set ;}

        public virtual ICollection<Picture> UserBackground { get; set; }//подумать!
    }
}
