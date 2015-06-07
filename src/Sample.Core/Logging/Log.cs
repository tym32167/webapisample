using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using NLog;

namespace Sample.Core.Logging
{

    public class Log : ILog
    {
        private static readonly Lazy<Logger> Logger = new Lazy<Logger>(LogManager.GetCurrentClassLogger);

        private static bool _configured;
        private static readonly object Lock = new object();

        private static void Configure()
        {
            if (!_configured)
            {
                lock (Lock)
                {
                    if (!_configured)
                    {
                        //XmlConfigurator.Configure();
                        LogManager.ReconfigExistingLoggers();
                        _configured = true;
                    }
                }
            }
        }

        private Logger _log
        {
            get
            {

                

                if (!_configured) Configure();
                return Logger.Value;
            }
        }

        private string MemberFormat(
             string memberName = null,
             string sourceFilePath = null,
             int sourceLineNumber = 0,
            object message = null)
        {
            return string.Format("{0}, {1} : {2}\n{3}", memberName, sourceFilePath, sourceLineNumber, message);
        }


        #region Implementation of ILog

        public void Debug(object message,
           [CallerMemberName] string memberName = null,
           [CallerFilePath] string sourceFilePath = null,
           [CallerLineNumber] int sourceLineNumber = 0)
        {
            var m = MemberFormat(memberName, sourceFilePath, sourceLineNumber, message);
            _log.Debug(m);
        }

        public void Debug(object message, Exception exception,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string sourceFilePath = null,
            [CallerLineNumber] int sourceLineNumber = 0)
        {
            var m = MemberFormat(memberName, sourceFilePath, sourceLineNumber, message);
            _log.Debug(m, exception);
        }

        [StringFormatMethod("format")]
        public void DebugFormat(string format, params object[] args)
        {
            _log.Debug(format, args);
        }

        [StringFormatMethod("format")]
        public void DebugFormat(string format, object arg0)
        {
            _log.Debug(format, arg0);
        }

        [StringFormatMethod("format")]
        public void DebugFormat(string format, object arg0, object arg1)
        {
            _log.Debug(format, arg0, arg1);
        }
        
        [StringFormatMethod("format")]
        public void DebugFormat(string format, object arg0, object arg1, object arg2)
        {
            _log.Debug(format, arg0, arg1, arg2);
        }

        [StringFormatMethod("format")]
        public void DebugFormat(IFormatProvider provider, string format, params object[] args)
        {
            _log.Debug(provider, format, args);
        }

        public void Info(string message)
        {
            _log.Info(message);
        }

        public void Info(object message,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string sourceFilePath = null,
            [CallerLineNumber] int sourceLineNumber = 0)
        {
            var m = MemberFormat(memberName, sourceFilePath, sourceLineNumber, message);
            _log.Info(m);
        }

        public void Info(object message, Exception exception,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string sourceFilePath = null,
            [CallerLineNumber] int sourceLineNumber = 0)
        {
            var m = MemberFormat(memberName, sourceFilePath, sourceLineNumber, message);
            _log.Info(m, exception);
        }

        [StringFormatMethod("format")]
        public void InfoFormat(string format, params object[] args)
        {
            _log.Info(format, args);
        }

        [StringFormatMethod("format")]
        public void InfoFormat(string format, object arg0)
        {
            _log.Info(format, arg0);
        }

        [StringFormatMethod("format")]
        public void InfoFormat(string format, object arg0, object arg1)
        {
            _log.Info(format, arg0, arg1);
        }

        [StringFormatMethod("format")]
        public void InfoFormat(string format, object arg0, object arg1, object arg2)
        {
            _log.Info(format, arg0, arg1, arg2);
        }

        [StringFormatMethod("format")]
        public void InfoFormat(IFormatProvider provider, string format, params object[] args)
        {
            _log.Info(provider, format, args);
        }


        public void Warn(object message,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string sourceFilePath = null,
            [CallerLineNumber] int sourceLineNumber = 0)
        {
            var m = MemberFormat(memberName, sourceFilePath, sourceLineNumber, message);
            _log.Warn(m);
        }

        public void Warn(object message, Exception exception,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string sourceFilePath = null,
            [CallerLineNumber] int sourceLineNumber = 0)
        {
            var m = MemberFormat(memberName, sourceFilePath, sourceLineNumber, message);
            _log.Warn(m, exception);
        }


        [StringFormatMethod("format")]
        public void WarnFormat(string format, params object[] args)
        {
            _log.Warn(format, args);
        }

        [StringFormatMethod("format")]
        public void WarnFormat(string format, object arg0)
        {
            _log.Warn(format, arg0);
        }

        [StringFormatMethod("format")]
        public void WarnFormat(string format, object arg0, object arg1)
        {
            _log.Warn(format, arg0, arg1);
        }

        [StringFormatMethod("format")]
        public void WarnFormat(string format, object arg0, object arg1, object arg2)
        {
            _log.Warn(format, arg0, arg1, arg2);
        }

        [StringFormatMethod("format")]
        public void WarnFormat(IFormatProvider provider, string format, params object[] args)
        {
            _log.Warn(provider, format, args);
        }

        public void Error(object message,
           [CallerMemberName] string memberName = null,
           [CallerFilePath] string sourceFilePath = null,
           [CallerLineNumber] int sourceLineNumber = 0)
        {
            var m = MemberFormat(memberName, sourceFilePath, sourceLineNumber, message);
            _log.Error(m);
        }

        public void Error(object message, Exception exception,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string sourceFilePath = null,
            [CallerLineNumber] int sourceLineNumber = 0)
        {
            var m = MemberFormat(memberName, sourceFilePath, sourceLineNumber, message);
            _log.Error(m, exception);
        }

        [StringFormatMethod("format")]
        public void ErrorFormat(string format, params object[] args)
        {
            _log.Error(format, args);
        }

        [StringFormatMethod("format")]
        public void ErrorFormat(string format, object arg0)
        {
            _log.Error(format, arg0);
        }

        [StringFormatMethod("format")]
        public void ErrorFormat(string format, object arg0, object arg1)
        {
            _log.Error(format, arg0, arg1);
        }

        [StringFormatMethod("format")]
        public void ErrorFormat(string format, object arg0, object arg1, object arg2)
        {
            _log.Error(format, arg0, arg1, arg2);
        }

        [StringFormatMethod("format")]
        public void ErrorFormat(IFormatProvider provider, string format, params object[] args)
        {
            _log.Error(provider, format, args);
        }

        public void Fatal(object message,
           [CallerMemberName] string memberName = null,
           [CallerFilePath] string sourceFilePath = null,
           [CallerLineNumber] int sourceLineNumber = 0)
        {
            var m = MemberFormat(memberName, sourceFilePath, sourceLineNumber, message);
            _log.Fatal(m);
        }

        public void Fatal(object message, Exception exception,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string sourceFilePath = null,
            [CallerLineNumber] int sourceLineNumber = 0)
        {
            var m = MemberFormat(memberName, sourceFilePath, sourceLineNumber, message);
            _log.Fatal(m, exception);
        }

        [StringFormatMethod("format")]
        public void FatalFormat(string format, params object[] args)
        {
            _log.Fatal(format, args);
        }

        [StringFormatMethod("format")]
        public void FatalFormat(string format, object arg0)
        {
            _log.Fatal(format, arg0);
        }

        [StringFormatMethod("format")]
        public void FatalFormat(string format, object arg0, object arg1)
        {
            _log.Fatal(format, arg0, arg1);
        }

        [StringFormatMethod("format")]
        public void FatalFormat(string format, object arg0, object arg1, object arg2)
        {
            _log.Fatal(format, arg0, arg1, arg2);
        }

        [StringFormatMethod("format")]
        public void FatalFormat(IFormatProvider provider, string format, params object[] args)
        {
            _log.Fatal(provider, format, args);
        }

        #endregion
    }
}