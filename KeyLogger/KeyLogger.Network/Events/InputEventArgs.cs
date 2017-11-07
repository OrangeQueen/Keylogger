using System;
using System.Net;
using KeyLogger.Messages;

namespace KeyLogger.Network.Events
{
    public class InputEventArgs : EventArgs
    {
        public InputMessage Message { get; set; }
        public IPEndPoint Ip { get; set; }
    }
}