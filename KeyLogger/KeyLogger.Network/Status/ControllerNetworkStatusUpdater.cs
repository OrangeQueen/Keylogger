using System.Collections.Generic;
using KeyLogger.Messages;

namespace KeyLogger.Network.Status
{
    public class ControllerNetworkStatusUpdater : NetworkStatusUpdater
    {
        public ControllerNetworkStatusUpdater(List<Server> serverlist, string ip)
            : base(new DeviceConnectRequestMessage {Controller = false}, serverlist, ip)
        {
        }
    }
}