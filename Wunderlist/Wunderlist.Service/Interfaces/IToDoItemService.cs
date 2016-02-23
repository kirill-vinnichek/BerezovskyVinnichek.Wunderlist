using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wunderlist.Models;

namespace Wunderlist.Service.Interfaces
{
    public interface IToDoItemService
    {
        void Add(ToDoItem entity);
        void Update(ToDoItem entity);
        void Delete(ToDoItem entity);
        void Delete(int id);
        ToDoItem GetById(int id);
        IEnumerable<ToDoItem> GetAll(int id);
    }
}
