using System;
using System.Linq;
using SessionManager.Helpers;
using SessionManager.Services;

namespace SessionManager
{
    class Program
    {
        static void Main(string[] args)
        {
            if (!DotNetRuntimeChecker.IsDotNet6OrHigherInstalled())
            {
                Console.WriteLine(".NET 6 runtime or higher is not installed. Please install it from https://dotnet.microsoft.com/download/dotnet/6.0.");
                Environment.Exit(1);
            }

            if (args.Contains("-v"))
            {
                PrintVersionInfo.PrintVersion();
                Environment.Exit(0);
            }

            if (args.Contains("-h"))
            {
                PrintVersionInfo.PrintHelp();
                Environment.Exit(0);
            }

            try
            {
                var sessionService = new SessionService();
                var disconnectedSessions = sessionService.GetDisconnectedSessions();

                foreach (var sessionId in disconnectedSessions)
                {
                    sessionService.LogoffSession(sessionId);
                    Console.WriteLine($"Logged off session ID: {sessionId}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
