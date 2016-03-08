﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Wunderlist.Models
{
    public class UserProfile
    {
        public int Id { get;protected set; }
        public virtual ICollection<ToDoItemList> ProfileToDoItemListList { get; set; }
        public int ProfileBackground { get; set; }
        public int UserId { get; set; }
    }
}