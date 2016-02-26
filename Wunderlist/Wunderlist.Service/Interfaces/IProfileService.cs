using Epam.Wunderlist.Models;

namespace Epam.Wunderlist.Services.Interfaces
{
    public interface IProfileService
    {
        void Add(UserProfile entity);
        void Update(UserProfile entity);
        void Delete(UserProfile entity);
        void Delete(int id);    
        UserProfile GetById(int id);       
    }
}
