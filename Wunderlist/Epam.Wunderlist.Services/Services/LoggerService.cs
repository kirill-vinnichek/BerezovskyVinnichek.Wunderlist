using Epam.Wunderlist.Services.Interfaces;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Wunderlist.Services.Services
{
    public class LoggerService : ILoggerService
    {
        private readonly Logger _logger ;

        public LoggerService()
        {
            _logger = LogManager.GetCurrentClassLogger();
        }
        public void Error(string message)
        {
            _logger.Error(message);
        }

        public void Trace(string message)
        {
            _logger.Trace(message);
        }

        public void Debug(string message)
        {
            _logger.Debug(message);
        }
    }
}
