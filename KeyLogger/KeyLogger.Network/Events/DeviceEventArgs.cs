using System;
using System.Net;
using KeyLogger.Messages;

namespace KeyLogger.Network.Events
{
    public class DeviceEventArgs : EventArgs
    {
        public DeviceConnectedMessage Message { get; set; }
        public IPEndPoint Ip { get; set; }
    }
}