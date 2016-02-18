using SignalR.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wunderlist.Data.Repositories
{
    public class TaskRepository:RepositoryBase<Task>,ITaskRepository
    {
        public TaskRepository(IDatabaseFactory dbF) : base(dbF) { }

    }

    public interface ITaskRepository : IRepository<Task> { }


}
