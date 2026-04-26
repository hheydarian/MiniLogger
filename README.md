# Mini Logger 

A simple, asynchronous logging library in C# that automatically captures caller information (Class, Method, Line Number) using **Reflection** and **Stack Trace**.

## Features 
- **Automatic Caller Identification**: Uses `System.Diagnostics.StackTrace` to detect where the log call originated.
- **Asynchronous Writing**: Uses `File.AppendAllTextAsync` for non-blocking I/O operations.
- **Structured Logs**: Formats logs with timestamps and severity levels.

## How It Works 
1. The `Logger` class uses `StackTrace` to skip its own frame and look at the caller.
2. It extracts the `DeclaringType` (Class Name), `Name` (Method Name), and `FileLineNumber`.
3. The log entry is written asynchronously to `app.log`.

## Usage Example 

```csharp
var logger = new Logger();
try 
{
    // Some code that might fail
    throw new Exception("Test Error");
}
catch (Exception ex)
{
    await logger.LogError(ex.Message);
}
```
## Output Example (app.log)
```
[2026-04-26 10:00:00] [ERROR] MyNamespace.Program.Main (Line: 25) - Test Error
```
## Technologies Used 
+ C# 14
+ System.Reflection
+ System.Diagnostics
+ System.IO (Async)
