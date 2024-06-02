using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using SessionManager.Helpers;
using SessionManager.Models;

namespace SessionManager.Services
{
    public class SessionService
    {
        public List<uint> GetDisconnectedSessions()
        {
            var disconnectedSessions = new List<uint>();
            IntPtr pSessionInfo = IntPtr.Zero;
            uint count = 0;

            if (NativeMethods.WTSEnumerateSessions(NativeMethods.WTS_CURRENT_SERVER_HANDLE, 0, 1, out pSessionInfo, out count))
            {
                int dataSize = Marshal.SizeOf(typeof(SessionInfo));
                IntPtr currentSession = pSessionInfo;

                for (int i = 0; i < count; i++)
                {
                    SessionInfo sessionInfo = Marshal.PtrToStructure<SessionInfo>(currentSession);
                    if (sessionInfo.State == WTSConnectStateClass.WTSDisconnected)
                    {
                        disconnectedSessions.Add(sessionInfo.SessionId);
                    }
                    currentSession = IntPtr.Add(currentSession, dataSize);
                }

                NativeMethods.WTSFreeMemory(pSessionInfo);
            }

            return disconnectedSessions;
        }

        public void LogoffSession(uint sessionId)
        {
            if (!NativeMethods.WTSLogoffSession(NativeMethods.WTS_CURRENT_SERVER_HANDLE, sessionId, false))
            {
                throw new InvalidOperationException($"Failed to log off session ID: {sessionId}");
            }
        }
    }
}
