using SignalR.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wunderlist.Data.Repositories
{
    public class ToDoItemRepository:RepositoryBase<Task>,IToDoItemRepository
    {
        public ToDoItemRepository(IDatabaseFactory dbF) : base(dbF) { }

    }

    public interface IToDoItemRepository : IRepository<Task> { }


}
