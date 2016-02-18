using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wunderlist.Service.Infrastructure
{
    public interface IService<T> where T : class
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        T GetById(long id);
        T GetById(string id);
        IEnumerable<T> GetAll();

    }
}
