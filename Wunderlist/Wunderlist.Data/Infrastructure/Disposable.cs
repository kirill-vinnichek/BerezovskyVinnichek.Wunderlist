using System;

namespace Epam.Wunderlist.DataAccess.MsSql.Infrastructure
{
    public class Disposable : IDisposable
    {
        private bool _disposed;

        ~Disposable()
        {
            Dispose(false);
        }

        private void Dispose(bool disposing)
        {
            if(!_disposed && disposing)
            {
                DisposeCore();
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void DisposeCore()
        {

        }

    }
}
