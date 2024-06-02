using System;

namespace SessionManager.Helpers
{
    public static class PrintVersionInfo
    {
        public static void PrintVersion()
        {
            Console.WriteLine("Session Manager vX.X.X");
        }

        public static void PrintHelp()
        {
            Console.WriteLine("Website: https://github.com/repasscloud/SessionManager");
        }
    }
}
