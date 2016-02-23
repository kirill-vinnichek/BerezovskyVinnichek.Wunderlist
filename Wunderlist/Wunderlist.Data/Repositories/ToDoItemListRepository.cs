using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wunderlist.Data.Infrastructure;
using Wunderlist.Models;

namespace Wunderlist.Data.Repositories
{
    public class ToDoItemListRepository: RepositoryBase<ToDoItemList>, ICategoryRepository
    {
        public ToDoItemListRepository(IDatabaseFactory dbF) : base(dbF) { }
    }
    public interface ICategoryRepository : IRepository<ToDoItemList> { }
}

