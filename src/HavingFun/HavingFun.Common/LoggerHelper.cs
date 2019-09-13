using NLog;
using System;
using System.Collections.Generic;
using System.Text;

namespace HavingFun.Common
{
    public class LoggerHelper
    {
        private Logger _logger;

        public LoggerHelper(Logger logger)
        {
            _logger = logger;
        }

        public void Trace(string msg)
        {
            _logger.Trace(msg);
        }

        public void Info(string msg)
        {
            _logger.Info(msg);
        }

        public void Warn(string msg)
        {
            _logger.Warn(msg);
        }

        public void Warn(Exception exc)
        {
            _logger.Warn(exc);
        }

        public void Warn(Exception exc, string msg)
        {
            _logger.Warn(exc, msg);
        }

        public void Error(string msg)
        {
            _logger.Error(msg);
        }

        public void Error(Exception exc, string msg)
        {
            _logger.Error(exc, msg);
        }

        public void Fatal(string msg)
        {
            _logger.Fatal(msg);
        }

        public void Fatal(Exception exc, string msg)
        {
            _logger.Fatal(exc, msg);
        }
    }
}
