using System;
using KeyLogger.Messages;
using KeyLogger.Network.Events;
using Lidgren.Network;

namespace KeyLogger.Network
{
    public class Client
    {
        private readonly NetClient _nclient;

        public Client()
        {
            var npconfig = new NetPeerConfiguration("KeyLogger");

            npconfig.EnableMessageType(NetIncomingMessageType.DiscoveryResponse);
            npconfig.UseMessageRecycling = true;
            npconfig.LocalAddress = NetUtility.Resolve(NetworkHelper.GetHostIpAdresses()[0]);

            // 10 Seconds Connection Timeout
            npconfig.MaximumHandshakeAttempts = 2;
            npconfig.ResendHandshakeInterval = 5;

            //npconfig.LocalAddress = NetUtility.Resolve("localhost");

            _nclient = new NetClient(npconfig);

            _nclient.RegisterReceivedCallback(GotMessage);

            _nclient.Start();
        }

        public Client(string ip)
        {
            var npconfig = new NetPeerConfiguration("KeyLogger");

            npconfig.EnableMessageType(NetIncomingMessageType.DiscoveryResponse);
            npconfig.UseMessageRecycling = true;
            npconfig.LocalAddress = NetUtility.Resolve(ip);

            _nclient = new NetClient(npconfig);

            _nclient.RegisterReceivedCallback(GotMessage);

            _nclient.Start();
        }

        public event EventHandler<NetworkEventArgs> NetworkEvent = null;
        public event EventHandler<NetworkDiscoveryResponseEventArgs> NetworkDiscoveryEvent = null;
        public event EventHandler<DeviceRequestEventArgs> DeviceRequestEvent = null;

        public void GotMessage(object peer)
        {
            var nclient = (NetClient) peer;

            NetIncomingMessage msg = nclient.ReadMessage();

            switch (msg.MessageType)
            {
                case NetIncomingMessageType.DiscoveryResponse:
                    if (NetworkDiscoveryEvent != null)
                        NetworkDiscoveryEvent(this,
                            new NetworkDiscoveryResponseEventArgs {EndPoint = msg.SenderEndPoint});
                    //msg.SenderEndPoint; msg.ReadString();

                    break;

                case NetIncomingMessageType.StatusChanged:
                    var status = (NetConnectionStatus) msg.ReadByte();

                    if (status == NetConnectionStatus.Connected)
                        if (NetworkEvent != null)
                            NetworkEvent(this, new NetworkEventArgs {NetworkStatus = NetworkStatus.Connected});

                    if (status == NetConnectionStatus.Disconnected)
                        if (NetworkEvent != null)
                            NetworkEvent(this, new NetworkEventArgs {NetworkStatus = NetworkStatus.Disconnected});

                    break;

                case NetIncomingMessageType.Data:

                    //string chat = msg.ReadString();

                    byte messagetype = msg.ReadByte();

                    switch (messagetype)
                    {
                        case 1:
                            int numberOfBytes = (msg.LengthBits + 7)/8;
                            --numberOfBytes; // minus one for msgType
                            var data = new byte[numberOfBytes];
                            msg.ReadBits(data, 0, msg.LengthBits - (int) msg.Position);

                            var datamsg = new byte[data.Length];

                            Buffer.BlockCopy(data, 0, datamsg, 0, datamsg.Length);

                            var im = SerializeHelper.Deserialize<DeviceConnectRequestMessage>(datamsg);

                            if (DeviceRequestEvent != null)
                                DeviceRequestEvent(this,
                                    new DeviceRequestEventArgs {Message = im, Ip = msg.SenderEndPoint});

                            break;
                    }

                    break;
            }
        }

        public void Connect(string host, int port, string clientname)
        {
            NetOutgoingMessage hailmessage = _nclient.CreateMessage(clientname);
            _nclient.Connect(host, port, hailmessage);
        }

        public void Disconnect()
        {
            _nclient.Disconnect("User request");
        }

        public void Send(InputMessage inputmessage)
        {
            byte[] datatosend = SerializeHelper.Serialize(inputmessage);

            NetOutgoingMessage message = _nclient.CreateMessage();
            message.Write((byte) 1); // Message Typ 1
            message.Write(datatosend);

            _nclient.SendMessage(message, NetDeliveryMethod.ReliableOrdered);
            _nclient.FlushSendQueue();
        }

        public void Send(DeviceConnectedMessage deviceconnectedmessage)
        {
            byte[] datatosend = SerializeHelper.Serialize(deviceconnectedmessage);

            NetOutgoingMessage message = _nclient.CreateMessage();
            message.Write((byte) 2); // Message Typ 2
            message.Write(datatosend);

            _nclient.SendMessage(message, NetDeliveryMethod.ReliableOrdered);
            _nclient.FlushSendQueue();
        }

        public void DiscoveryRequest(int port)
        {
            _nclient.DiscoverLocalPeers(port);
        }
    }
}