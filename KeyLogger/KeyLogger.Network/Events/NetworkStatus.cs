using System.ComponentModel;

namespace KeyLogger.Network.Events
{
    [DefaultValue(Unkown)]
    public enum NetworkStatus
    {
        Unkown,
        Connected,
        Disconnected
    }
}