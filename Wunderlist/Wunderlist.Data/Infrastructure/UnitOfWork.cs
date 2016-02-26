using Epam.Wunderlist.DataAccess.Interfaces.Infrastructure;

namespace Epam.Wunderlist.DataAccess.MsSql.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDatabaseFactory _databaseFactory;
        private WunderlistContext _dataContext;

        public UnitOfWork(IDatabaseFactory databaseFactory)
        {
            this._databaseFactory = databaseFactory;
        }

        protected WunderlistContext DataContext => _dataContext ?? (_dataContext = _databaseFactory.Context);

        public void Commit()
        {
            DataContext.SaveChanges();
        }
    }
}
