using System;
using System.Configuration;
using System.Diagnostics;
using System.Reflection;

namespace Refactoring
{
    public class Logger: ILogService
    {
        private string _loggerType;

        public Logger()
        {
            _loggerType = ConfigurationManager.AppSettings["LoggerType"];
        }

        private static readonly Logger _instance = new Logger();

        public static Logger Instance
        {
            get
            {
                return _instance;
            }
        }

        public void Log(string message, string level)
        {
            LogDiagnostic _logDiagnostic = new LogDiagnostic();
            LogEventViewer _logEventViewer = new LogEventViewer();
            switch (_loggerType)
            {
                case "Diagnostic":
                    _logDiagnostic.Write(message, level);
                    break;
                case "EventViewer":
                    _logEventViewer.Write(message, level);
                    break;
            }
        }
    }
}