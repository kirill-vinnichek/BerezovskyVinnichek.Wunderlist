using System.Collections.Generic;
using Epam.Wunderlist.Models;

namespace Epam.Wunderlist.Services.Interfaces
{
    public interface ICommentService
    {
        void Add(Comment entity);
        void Update(Comment entity);
        void Delete(Comment entity);
        void Delete(int id);
        Comment GetById(int id);
        IEnumerable<Comment> GetAll(int id);
    }
}
