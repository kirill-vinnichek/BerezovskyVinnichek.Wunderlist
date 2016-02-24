using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wunderlist.Data.Infrastructure;
using Wunderlist.Models;

namespace Wunderlist.Data.Repositories
{
    public class ToDoItemListRepository: RepositoryBase<ToDoItemList>, IToDoItemListRepository
    {
        public ToDoItemListRepository(IDatabaseFactory dbF) : base(dbF) { }
    }
    public interface IToDoItemListRepository : IRepository<ToDoItemList> { }
}

