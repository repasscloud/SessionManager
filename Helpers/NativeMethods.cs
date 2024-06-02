using System;
using System.Runtime.InteropServices;

namespace SessionManager.Helpers
{
    public static class NativeMethods
    {
        public static readonly IntPtr WTS_CURRENT_SERVER_HANDLE = IntPtr.Zero;

        [DllImport("wtsapi32.dll")]
        public static extern bool WTSEnumerateSessions(IntPtr hServer, uint Reserved, uint Version, out IntPtr ppSessionInfo, out uint pCount);

        [DllImport("wtsapi32.dll")]
        public static extern void WTSFreeMemory(IntPtr pMemory);

        [DllImport("wtsapi32.dll")]
        public static extern bool WTSLogoffSession(IntPtr hServer, uint sessionId, bool bWait);
    }
}
