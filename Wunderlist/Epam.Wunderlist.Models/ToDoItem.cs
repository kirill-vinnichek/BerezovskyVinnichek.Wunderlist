using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Wunderlist.Models
{
    public class ToDoItem
    {
        
        public int Id { get;protected set; }

        public string Text { get; set; }

        public DateTime? Date { get; set; }


        public ToDoItemStatus CurrentState { get; set; }

        public int NumberInList { get; set; }

        public bool IsMarked { get; set; }

        public int ToDoItemListId { get; set; }

    }
}
