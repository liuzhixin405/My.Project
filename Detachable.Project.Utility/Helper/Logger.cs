﻿using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Detachable.Project.Utility.Helper
{
    /// <summary>
    /// 日志管理
    /// </summary>
    public class Logger
    {
        NLog.Logger _logger;
        private Logger(NLog.Logger logger)
        {
            _logger = logger;
        }
        public Logger(string name) : this(LogManager.GetLogger(name))
        {

        }

        public static Logger Default { get; private set; }
        static Logger()
        {
            Default = new Logger(LogManager.GetCurrentClassLogger());
        }

        public void Process(string UserName, string Logger, string msg)
        {
            LogEventInfo lei = new LogEventInfo();
            lei.Properties["UserName"] = UserName;
            lei.Properties["Logger"] = Logger;
            lei.Level = LogLevel.Trace;
            lei.Message = msg;
            _logger.Log(lei);
        }

        public void ProcessError(int statusCode, string msg)
        {
            LogEventInfo lei = new LogEventInfo();
            lei.Properties["Logger"] = Convert.ToString(statusCode);
            lei.Level = LogLevel.Error;
            lei.Message = msg;
            _logger.Log(lei);
        }

        #region Debug
        public void Debug(string msg, params object[] args)
        {
            _logger.Debug(msg, args);
        }

        public void Debug(string msg, Exception err)
        {
            _logger.Debug(err, msg);
        }
        #endregion

        #region Info
        public void Info(string msg, params object[] args)
        {
            _logger.Info(msg, args);
        }

        public void Info(string msg, Exception err)
        {
            _logger.Info(err, msg);
        }
        #endregion

        #region Warn
        public void Warn(string msg, params object[] args)
        {
            _logger.Warn(msg, args);
        }

        public void Warn(string msg, Exception err)
        {
            _logger.Warn(err, msg);
        }
        #endregion

        #region Trace
        public void Trace(string msg, params object[] args)
        {
            _logger.Trace(msg, args);
        }

        public void Trace(string msg, Exception err)
        {
            _logger.Trace(err, msg);
        }
        #endregion

        #region Error
        public void Error(string msg, params object[] args)
        {
            _logger.Error(msg, args);
        }

        public void Error(string msg, Exception err)
        {
            _logger.Error(err, msg);
        }
        #endregion

        #region Fatal
        public void Fatal(string msg, params object[] args)
        {
            _logger.Fatal(msg, args);
        }

        public void Fatal(string msg, Exception err)
        {
            _logger.Fatal(err, msg);
        }
        #endregion
    }
}
