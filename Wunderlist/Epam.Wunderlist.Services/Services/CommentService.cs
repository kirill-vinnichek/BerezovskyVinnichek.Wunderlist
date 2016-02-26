using System.Collections.Generic;
using Epam.Wunderlist.DataAccess.Interfaces;
using Epam.Wunderlist.DataAccess.Interfaces.Infrastructure;
using Epam.Wunderlist.Models;
using Epam.Wunderlist.Services.Interfaces;

namespace Epam.Wunderlist.Services.Services
{
    public class CommentService : ICommentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICommentRepository _repository;

        public CommentService(IUnitOfWork uoW, ICommentRepository rep)
        {
            this._repository = rep;
            this._unitOfWork = uoW;
        }
        public void Add(Comment entity)
        {
            _repository.Add(entity);
            _unitOfWork.Commit();
        }

        public void Delete(int id)
        {
            _repository.Delete(c=>c.Id==id);
        }

        public void Delete(Comment entity)
        {
            var comment = GetById(entity.Id);
            _repository.Delete(comment);
            _unitOfWork.Commit();
        }

        public IEnumerable<Comment> GetAll(int id)
        {
            return _repository.GetMany(c => c.CommentUser.Id == id);
        }

        public Comment GetById(int id)
        {
            return _repository.GetById(id);
        }

        public void Update(Comment entity)
        {
            _repository.Update(entity);
            _unitOfWork.Commit();
        }
    }
}
