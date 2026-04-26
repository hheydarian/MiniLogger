using System.Text;

namespace Personal_Logging_System
{
    public class Logger
    {
        private readonly string _logFilePath = "app.log";

        public async Task LogError(string message)
        {
            var callerInfo = GetCallerInfo();

            string logEntry = $"[{DateTime.Now:yyyy:MM:dd HH:mm:ss}] [ERROR] {callerInfo} - {message}\n";

            await File.AppendAllTextAsync(_logFilePath, logEntry, Encoding.UTF8);
        }
        private string GetCallerInfo()
        {
            var stackTrace = new System.Diagnostics.StackTrace(skipFrames: 1, fNeedFileInfo: true);
            var frame = stackTrace.GetFrame(0);
            var method = frame.GetMethod();
            var location = frame.GetFileName();

            string className = method.DeclaringType?.Name ?? "Unknown";
            string methodName = method.Name;
            string lineNumber = frame.GetFileLineNumber().ToString();

            return $"{className}.{methodName} (Line: {lineNumber})";
        }
    }
}
