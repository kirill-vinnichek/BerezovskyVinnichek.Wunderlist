using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Epam.Wunderlist.Web.ViewModels
{
    public class OrderViewModel
    {
        public int[] Completed { get; set; }
        public int[] Unfinished { get; set; }
    }
}