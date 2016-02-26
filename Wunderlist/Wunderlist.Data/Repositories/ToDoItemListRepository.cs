using Epam.Wunderlist.DataAccess.Interfaces;
using Epam.Wunderlist.DataAccess.MsSql.Infrastructure;
using Epam.Wunderlist.Models;

namespace Epam.Wunderlist.DataAccess.MsSql.Repositories
{
    public class ToDoItemListRepository: RepositoryBase<ToDoItemList>, IToDoItemListRepository
    {
        public ToDoItemListRepository(IDatabaseFactory dbF) : base(dbF) { }
    }
}

