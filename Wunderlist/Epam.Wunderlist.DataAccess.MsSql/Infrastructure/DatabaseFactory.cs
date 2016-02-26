namespace Epam.Wunderlist.DataAccess.MsSql.Infrastructure
{
    public class DatabaseFactory : Disposable,IDatabaseFactory
    {

        private WunderlistContext _context;

        protected override void DisposeCore()
        {
            _context?.Dispose();
        }

        public WunderlistContext Context => _context ?? (_context = new WunderlistContext());
    }
}
