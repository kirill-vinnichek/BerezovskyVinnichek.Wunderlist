﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wunderlist.Models
{
    public class Task
    {
        public int TaskId { get; set; }

        public string TaskText { get; set; }

        public DateTime? TaskDate { get; set; }

        public bool TaskIsMarked { get; set; }

        public bool TaskIsComplete { get; set; }
    }
}
