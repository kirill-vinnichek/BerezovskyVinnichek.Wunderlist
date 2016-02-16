using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.Data.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDatabaseFactory databaseFactory;
        private WunderlistContext dataContext;

        public UnitOfWork(IDatabaseFactory databaseFactory)
        {
            this.databaseFactory = databaseFactory;
        }

        protected WunderlistContext DataContext
        {
            get { return dataContext ?? (dataContext = databaseFactory.Context); }
        }

        public void Commit()
        {
            DataContext.SaveChanges();
        }
    }
}
