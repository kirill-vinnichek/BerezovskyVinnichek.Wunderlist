using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wunderlist.Models
{
    public class ToDoItem
    {
        public enum Status
        {
            New,
            Unfinished,
            Сompleted
        }
        public int ID { get; set; }

        public string Text { get; set; }

        public DateTime? Date { get; set; }


        public Status CurrentState { get; set; }

        public int CategoryId { get; set; }
    }
}
