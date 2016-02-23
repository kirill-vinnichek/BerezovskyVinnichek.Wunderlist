using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wunderlist.Models;

namespace Wunderlist.Service.Interfaces
{
    public interface ICommentService
    {
        void Add(Comment entity);
        void Update(Comment entity);
        void Delete(Comment entity);
        void Delete(int id);
        Comment GetById(int id);
        IEnumerable<Comment> GetAll(string id);
    }
}
