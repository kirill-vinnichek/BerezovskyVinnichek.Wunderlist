using Epam.Wunderlist.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Epam.Wunderlist.Web.ViewModels
{
    public class ToDoItemViewModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }

        public DateTime? Date { get; set; }
        public DateTime? DateCompleted { get; set; }
        public ToDoItemStatus CurrentState { get; set; }

        public int NumberInList { get; set; }

        public bool IsMarked { get; set; }

        public int ToDoItemListId { get; set; }
    }
}