using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wunderlist.Models;

namespace Wunderlist.Service.Interfaces
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
