using Wunderlist.Data.Infrastructure;
using Wunderlist.Models;

namespace Wunderlist.Data.Repositories
{
    public class ToDoItemRepository:RepositoryBase<ToDoItem>,IToDoItemRepository
    {
        public ToDoItemRepository(IDatabaseFactory dbF) : base(dbF) { }

    }

    public interface IToDoItemRepository : IRepository<ToDoItem> { }


}
