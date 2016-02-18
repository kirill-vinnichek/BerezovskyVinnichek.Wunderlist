using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.Data.Infrastructure
{
    public interface IDatabaseFactory : IDisposable
    {
        WunderlistContext Context { get; }
    }
}
