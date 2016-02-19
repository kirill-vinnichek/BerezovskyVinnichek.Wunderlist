using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wunderlist.Models
{
    public class Comment
    {
        public int ID { get; set; }
        public User CommentUser { get; set; }
        public string CommentText { get; set; }
    }
}
