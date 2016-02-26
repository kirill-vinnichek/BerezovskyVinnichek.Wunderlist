using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Wunderlist.Models
{
    public class ToDoItemList
    {
        public int Id { get;protected set; }
        public string Name { get; set;}
        public virtual ICollection<ToDoItem> ToDoItemsList { get; set; }
        public virtual ICollection<UserProfile>ProfilesList{ get; set; }
    }
}
