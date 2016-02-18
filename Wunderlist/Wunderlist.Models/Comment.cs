using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wunderlist.Models
{
    public class Comment
    {
        public int CommentId { get; set; }
        public AppUser CommentUser { get; set; }
        public string CommentText { get; set; }
    }
}
