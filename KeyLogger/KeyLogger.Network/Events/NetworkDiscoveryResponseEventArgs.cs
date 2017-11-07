using System;
using System.Net;

namespace KeyLogger.Network.Events
{
    public class NetworkDiscoveryResponseEventArgs : EventArgs
    {
        public IPEndPoint EndPoint { get; set; }
    }
}