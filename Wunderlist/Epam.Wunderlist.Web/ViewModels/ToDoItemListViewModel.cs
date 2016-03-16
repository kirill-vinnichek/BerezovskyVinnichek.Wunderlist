using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Epam.Wunderlist.Web.ViewModels
{
    public class ToDoItemListViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int UserId { get; set; }
        public int ItemsCount { get; set; }
    }
}