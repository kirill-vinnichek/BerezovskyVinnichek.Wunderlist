using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Wunderlist.Services.Interfaces
{
    public interface ILoggerService
    {
        void Trace(string message);
        void Error(string message);
        void Debug(string message);
    }
}
