﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wunderlist.Data.Infrastructure
{
    public interface IDatabaseFactory : IDisposable
    {
        WunderlistContext Context { get; }
    }
}
