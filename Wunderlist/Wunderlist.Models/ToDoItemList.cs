using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wunderlist.Models
{
    public class ToDoItemList
    {

        public int ID { get;protected set; }
        public string Name { get; set;}
        public virtual ICollection<ToDoItem> ToDoItemsList { get; set; }
        public virtual ICollection<UserProfile>ProfilesList{ get; set; }
    }
}
