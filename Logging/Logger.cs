using System;
using System.Reflection;
using log4net;
using log4net.Config;
using log4net.Core;
using System.Configuration;
using System.Xml;
using System.IO;

namespace TwitterBotCore.Logging
{
    //Todo:Improve Logger
    public interface ILogger
    {
        string LogLocation { set; get; }

        void Log(string message);

        void LogError(string message,Exception exception);

        void LogInfo(string message, Exception exception);
    }

    public class Log4NetLogger:ILogger
    {
        private readonly string _logLocation = ConfigurationManager.AppSettings["LogLocation"];

        public string LogLocation
        {
            set { }
            get => _logLocation;
        }

        private static ILogger _instance;

        public static ILogger Instance => _instance ?? (_instance = new Log4NetLogger());

        public Log4NetLogger()
        {
            var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
            XmlDocument log4netConfig = new XmlDocument();
            log4netConfig.Load(File.OpenRead(ConfigurationManager.AppSettings["LogConfigLocation"]));
            XmlConfigurator.Configure(logRepository, log4netConfig["log4net"]);
            //XmlConfigurator.Configure(logRepository, new System.IO.FileInfo("app.config"));
            Log4NetInstance = Log4NetInstance ?? LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        }

        private static ILog Log4NetInstance;

        public void Log(string message)
        {
            var loggingEventDate = new LoggingEventData { Level = Level.Error, Message = message, LoggerName = this.ToString(), TimeStampUtc = DateTime.Now.ToUniversalTime() };
            var logEvent = new LoggingEvent(loggingEventDate);
            Log4NetInstance.Logger.Log(logEvent);
        }

        public new string ToString()
        {
            return MethodBase.GetCurrentMethod().DeclaringType.ToString();
        }

        public void LogError(string message, Exception exception)
        {
            var loggingEventDate = new LoggingEventData { Level = Level.Error, Message = message, LoggerName = this.ToString(), ExceptionString = exception.InnerException.Message , TimeStampUtc = DateTime.Now.ToUniversalTime() };
            var logEvent = new LoggingEvent(loggingEventDate);
            Log4NetInstance.Logger.Log(logEvent);
        }

        public void LogInfo(string message, Exception exception)
        {
            var loggingEventDate = new LoggingEventData { Level = Level.Info, Message = message, LoggerName = this?.ToString(), ExceptionString = exception?.InnerException?.Message};
            var logEvent = new LoggingEvent(loggingEventDate);
            Log4NetInstance.Logger.Log(logEvent);
        }
    }
}