using System;
using System.Diagnostics;
using System.Reflection;

namespace Refactoring
{
    class LogEventViewer : ILogWriter
    {
        public void Write(string message, string level)
        {
            switch (level)
            {
                case "INFO":
                    {
                        var eventLog = new EventLog("Application")
                        {
                            Source = Assembly.GetExecutingAssembly().GetName().Name
                        };
                        eventLog.WriteEntry($"EventViewer {message}", EventLogEntryType.Information);

                        eventLog.Dispose();
                        break;
                    }
                case "ERROR":
                    {
                        var eventLog = new EventLog("Application")
                        {
                            Source = Assembly.GetExecutingAssembly().GetName().Name
                        };
                        eventLog.WriteEntry($"EventViewer {message}", EventLogEntryType.Error);

                        eventLog.Dispose();
                        break;
                    }
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
