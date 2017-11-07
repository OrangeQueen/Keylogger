using System.Collections.Generic;
using KeyLogger.Messages;

namespace KeyLogger.Network.Status
{
    public abstract class NetworkStatusUpdater
    {
        private readonly DeviceConnectRequestMessage _deviceconnectrequestmessage;
        private readonly string _ip;
        private readonly List<Server> _servers;

        protected NetworkStatusUpdater(DeviceConnectRequestMessage deviceconnectrequestmessage, List<Server> servers,
            string ip)
        {
            this._deviceconnectrequestmessage = deviceconnectrequestmessage;
            this._servers = servers;
            this._ip = ip;
        }

        public void Disconnect()
        {
            foreach (Server server in _servers)
            {
                server.Send(_deviceconnectrequestmessage, _ip);
            }
        }
    }
}