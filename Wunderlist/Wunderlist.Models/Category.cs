using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wunderlist.Models
{
    public class Category
    {

        public int ID { get; set; }
        public string CategoryName { get; set;}
        public virtual ICollection<ToDoItem> ToDoItemsList { get; set; }
        public virtual ICollection<UserProfile> CategoryUser{ get; set; }
    }
}
