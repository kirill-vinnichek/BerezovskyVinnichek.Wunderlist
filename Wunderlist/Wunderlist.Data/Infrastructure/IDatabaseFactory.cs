using System;

namespace Epam.Wunderlist.DataAccess.MsSql.Infrastructure
{
    public interface IDatabaseFactory : IDisposable
    {
        WunderlistContext Context { get; }
    }
}
