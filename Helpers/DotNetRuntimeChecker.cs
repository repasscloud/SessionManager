using System;
using System.Diagnostics;
using System.Linq;

namespace SessionManager.Helpers
{
    public static class DotNetRuntimeChecker
    {
        public static bool IsDotNet6OrHigherInstalled()
        {
            try
            {
                var processInfo = new ProcessStartInfo("dotnet", "--list-runtimes")
                {
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                using (var process = Process.Start(processInfo))
                {
                    if (process == null)
                    {
                        return false;
                    }

                    using (var reader = process.StandardOutput)
                    {
                        var output = reader.ReadToEnd();
                        return output
                            .Split(Environment.NewLine)
                            .Any(line => line.StartsWith("Microsoft.NETCore.App") && IsVersion6OrHigher(line));
                    }
                }
            }
            catch
            {
                return false;
            }
        }

        private static bool IsVersion6OrHigher(string line)
        {
            var versionString = line.Split(' ')[1];
            if (Version.TryParse(versionString, out var version))
            {
                return version.Major >= 6;
            }
            return false;
        }
    }
}
