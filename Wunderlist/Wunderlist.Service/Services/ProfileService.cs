using Epam.Wunderlist.DataAccess.Interfaces;
using Epam.Wunderlist.DataAccess.Interfaces.Infrastructure;
using Epam.Wunderlist.Models;
using Epam.Wunderlist.Services.Interfaces;

namespace Epam.Wunderlist.Services.Services
{
    public class ProfileService : IProfileService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProfileRepository _repository;

        public ProfileService(IUnitOfWork uoW, IProfileRepository rep)
        {
            this._repository = rep;
            this._unitOfWork = uoW;
        }
        public void Add(UserProfile entity)
        {
            _repository.Add(entity);
            _unitOfWork.Commit();
        }

        public void Delete(int id)
        {
            _repository.Delete(p=>p.Id==id);
            _unitOfWork.Commit();
        }

        public void Delete(UserProfile entity)
        {
            var profile = GetById(entity.Id);
            _repository.Delete(profile);
            _unitOfWork.Commit();
        }

        public UserProfile GetById(int id)
        {
            return _repository.GetById(id);
        }

        public void Update(UserProfile entity)
        {
            _repository.Update(entity);
            _unitOfWork.Commit();
        }
    }
}
