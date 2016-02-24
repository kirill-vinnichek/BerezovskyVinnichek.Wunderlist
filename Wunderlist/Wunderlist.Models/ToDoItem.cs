using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wunderlist.Models
{
    public enum Status
    {
        New,
        Unfinished,
        Сompleted
    }
    public class ToDoItem
    {
        
        public int ID { get;protected set; }

        public string Text { get; set; }

        public DateTime? Date { get; set; }


        public Status CurrentState { get; set; }

        public int NumberInList { get; set; }

        public int ToDoItemListId { get; set; }

        public virtual ICollection<Comment> CommentsList{ get; set; }
    }
}
