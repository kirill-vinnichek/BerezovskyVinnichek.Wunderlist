﻿using System.Collections.Generic;

namespace Wunderlist.Models
{
    public class Role 
    {
        public int Id { get;protected set; }

        public string Name { get; set; }

        public virtual ICollection<User> Users{get;set;} 

    }
}
