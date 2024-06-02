using System.Runtime.InteropServices;

namespace SessionManager.Models
{
    [StructLayout(LayoutKind.Sequential)]
    public struct SessionInfo
    {
        public uint SessionId;
        [MarshalAs(UnmanagedType.LPStr)]
        public string pWinStationName;
        public WTSConnectStateClass State;
    }
}
