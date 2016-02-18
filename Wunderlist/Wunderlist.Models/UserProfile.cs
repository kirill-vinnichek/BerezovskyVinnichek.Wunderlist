using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wunderlist.Models
{
    public class UserProfile
    {
        public virtual ICollection<Category> ProfileCategoryList { get; set; }
        public int ProfileBackground { get; set; } 
    }
}
