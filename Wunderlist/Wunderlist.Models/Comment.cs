using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Wunderlist.Models;

namespace Epam.Wunderlist.Models
{
    public class Comment
    {
        public int Id { get;protected set; }
        public User CommentUser { get; set; }
        public string CommentText { get; set; }
    }
}
