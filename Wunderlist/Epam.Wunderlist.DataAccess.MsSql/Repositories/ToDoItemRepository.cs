using Epam.Wunderlist.DataAccess.Interfaces;
using Epam.Wunderlist.DataAccess.MsSql.Infrastructure;
using Epam.Wunderlist.Models;

namespace Epam.Wunderlist.DataAccess.MsSql.Repositories
{
    public class ToDoItemRepository:RepositoryBase<ToDoItem>,IToDoItemRepository
    {
        public ToDoItemRepository(IDatabaseFactory dbF) : base(dbF) { }

    }
}
