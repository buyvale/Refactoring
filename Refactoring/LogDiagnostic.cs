using System;
using System.Diagnostics;

namespace Refactoring
{
    public class LogDiagnostic : ILogWriter
    {
        public void Write(string message, string level)
        {
            switch (level)
            {
                case "INFO":
                    Debug.WriteLine($"Diagnostic Info: {message}", level);
                    break;
                case "ERROR":
                    Debug.WriteLine($"Diagnostic Error: {message}", level);
                    break;
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
