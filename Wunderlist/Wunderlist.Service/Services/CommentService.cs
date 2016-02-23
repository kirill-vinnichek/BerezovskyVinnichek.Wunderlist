using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wunderlist.Data.Infrastructure;
using Wunderlist.Data.Repositories;
using Wunderlist.Models;
using Wunderlist.Service.Interfaces;

namespace Wunderlist.Service.Services
{
    public class CommentService : ICommentService
    {
        private readonly IUnitOfWork uoWork;
        private readonly ICommentRepository repository;

        public CommentService(IUnitOfWork uoW, ICommentRepository rep)
        {
            this.repository = rep;
            this.uoWork = uoW;
        }
        public void Add(Comment entity)
        {
            repository.Add(entity);
            uoWork.Commit();
        }

        public void Delete(int id)
        {
            repository.Delete(c=>c.ID==id);
        }

        public void Delete(Comment entity)
        {
            var comment = GetById(entity.ID);
            repository.Delete(comment);
            uoWork.Commit();
        }

        public IEnumerable<Comment> GetAll(string id)
        {
            return repository.GetMany(c => c.CommentUser.Id == id);
        }

        public Comment GetById(int id)
        {
            return repository.GetById(id);
        }

        public void Update(Comment entity)
        {
            repository.Update(entity);
            uoWork.Commit();
        }
    }
}
