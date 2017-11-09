using System;
using System.Linq;
using System.Net;
using KeyLogger.Messages;
using KeyLogger.Network.Events;
using Lidgren.Network;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Diagnostics;
using System.IO;

namespace KeyLogger.Network
{
    public class Server
    {
        private readonly NetServer _nserver;

        public Server(int port, int maxconnections)
        {
            Port = port;
            MaxConnections = maxconnections;

            var npconfig = new NetPeerConfiguration("KeyLogger")
            {
                Port = port,
                MaximumConnections = port,
                UseMessageRecycling = true
            };

            npconfig.EnableMessageType(NetIncomingMessageType.DiscoveryRequest);
            //npconfig.LocalAddress = NetUtility.Resolve("localhost");

            npconfig.LocalAddress = NetUtility.Resolve(NetworkHelper.GetHostIpAdresses()[0]);

            _nserver = new NetServer(npconfig);

            _nserver.RegisterReceivedCallback(GotMessage);

            _nserver.Start();
        }

        public Server(string ip, int port, int maxconnections)
        {
            Port = port;
            MaxConnections = maxconnections;

            var npconfig = new NetPeerConfiguration("KeyLogger")
            {
                Port = port,
                MaximumConnections = port,
                UseMessageRecycling = true
            };

            npconfig.EnableMessageType(NetIncomingMessageType.DiscoveryRequest);
            //npconfig.LocalAddress = NetUtility.Resolve("localhost");

            npconfig.LocalAddress = NetUtility.Resolve(ip);

            _nserver = new NetServer(npconfig);

            _nserver.RegisterReceivedCallback(GotMessage);

            _nserver.Start();
        }

        public int Port { get; private set; }
        public int MaxConnections { get; private set; }

        public event EventHandler<NetworkEventArgs> NetworkEvent = null;

        public event EventHandler<InputEventArgs> InputEvent = null;

        public event EventHandler<DeviceEventArgs> DeviceEvent = null;

        public void GotMessage(object peer)
        {
            var nserver = (NetServer)peer;

            NetIncomingMessage msg = nserver.ReadMessage();

            switch (msg.MessageType)
            {
                case NetIncomingMessageType.DiscoveryRequest:

                    NetOutgoingMessage response = nserver.CreateMessage();
                    response.Write("Server");

                    nserver.SendDiscoveryResponse(response, msg.SenderEndPoint);
                    break;

                case NetIncomingMessageType.StatusChanged:
                    var status = (NetConnectionStatus)msg.ReadByte();

                    //var reason = msg.ReadString();
                    //Output(NetUtility.ToHexString(im.SenderConnection.RemoteUniqueIdentifier) + " " + status + ": " + reason);

                    if (status == NetConnectionStatus.Connected)
                    {
                        if (NetworkEvent != null)
                            NetworkEvent(this,
                                new NetworkEventArgs
                                {
                                    NetworkStatus = NetworkStatus.Connected,
                                    Ip = msg.SenderEndPoint,
                                    Name = msg.SenderConnection.RemoteHailMessage.ReadString()
                                });
                    }
                    else if (status == NetConnectionStatus.Disconnected)
                    {
                        if (NetworkEvent != null)
                            NetworkEvent(this,
                                new NetworkEventArgs
                                {
                                    NetworkStatus = NetworkStatus.Disconnected,
                                    Ip = msg.SenderEndPoint
                                });
                    }
                    //    Output("Remote hail: " + im.SenderConnection.RemoteHailMessage.ReadString());

                    break;
                case NetIncomingMessageType.Data:

                    //string chat = msg.ReadString();
                    byte messagetype = msg.ReadByte();

                    switch (messagetype)
                    {
                        case 1:
                            int numberOfBytes = (msg.LengthBits + 7) / 8;
                            --numberOfBytes; // minus one for msgType
                            var data = new byte[numberOfBytes];
                            msg.ReadBits(data, 0, msg.LengthBits - (int)msg.Position);

                            var datamsg = new byte[data.Length];

                            Buffer.BlockCopy(data, 0, datamsg, 0, datamsg.Length);

                            ProcessMessage(datamsg, msg.SenderEndPoint);
                            LogMessage(msg.ReceiveTime, datamsg, msg.SenderEndPoint);
                            break;
                        case 2:
                            numberOfBytes = (msg.LengthBits + 7) / 8;
                            --numberOfBytes; // minus one for msgType
                            data = new byte[numberOfBytes];
                            msg.ReadBits(data, 0, msg.LengthBits - (int)msg.Position);

                            datamsg = new byte[data.Length];

                            Buffer.BlockCopy(data, 0, datamsg, 0, datamsg.Length);

                            var dcm = SerializeHelper.Deserialize<DeviceConnectedMessage>(datamsg);

                            if (DeviceEvent != null)
                                DeviceEvent(this, new DeviceEventArgs { Message = dcm, Ip = msg.SenderEndPoint });


                            break;
                    }



                    break;
            }
        }



        private void ProcessMessage(byte[] datamsg, IPEndPoint senderEndPoint)
        {
            var im = SerializeHelper.Deserialize<InputMessage>(datamsg);

            if (InputEvent != null)
            {
                InputEvent(this, new InputEventArgs { Message = im, Ip = senderEndPoint });
            }
        }


        public void Send(DeviceConnectRequestMessage deviceconnectrequestmessage, string clientip)
        {
            NetConnection nc = _nserver.Connections.SingleOrDefault(c => c.RemoteEndPoint.Address.ToString() == clientip);

            if (nc == null)
                return; // No Client found

            byte[] datatosend = SerializeHelper.Serialize(deviceconnectrequestmessage);

            NetOutgoingMessage message = _nserver.CreateMessage();
            message.Write((byte)1); // Message Typ 1
            message.Write(datatosend);


            _nserver.SendMessage(message, nc, NetDeliveryMethod.ReliableOrdered);
            _nserver.FlushSendQueue();
        }

        public void DisconnectClient(string clientip)
        {
            NetConnection nc = _nserver.Connections.SingleOrDefault(c => c.RemoteEndPoint.Address.ToString() == clientip);

            if (nc == null)
                return; // No Client found

            nc.Disconnect("User request");

            if (sw != null)
            {
                sw.Close();
                sw = null;
            }
        }

        public void Shutdown()
        {
            _nserver.Shutdown("User request");
        }



        private DateTime lastEvent = DateTime.Now;
        private bool capturing = false;
        private FileStream currentFile;
        private StreamWriter sw;
        public void StartCapture()
        {
            capturing = true;
            lastEvent = DateTime.Now;

            currentFile = new FileStream("../../../Logs/"+DateTime.Now.ToString("yyyy_MM_dd_H_mm_ss")+".log", (FileMode)1);
            sw = new StreamWriter(currentFile);

        }
        public void StopCapture()
        {
            capturing = false;
            currentFile.Close();
        }
        private void LogMessage(double time, byte[] msg, IPEndPoint ip)
        {
            if (!capturing)
                return;
            DoLog(
                (DateTime.Now - lastEvent).TotalMilliseconds,
                msg,
                ip.Address.Address,
                ip.Port
            );
            lastEvent = DateTime.Now;
        }

        public static string sep = "|";
        public static char lineSep = '\n';

        private void DoLog(double totalMilliseconds, byte[] msg, long address, int port)
        {
            var entry =
                ((int)totalMilliseconds).ToString() + sep +
                Convert.ToBase64String(msg) + sep +
                address.ToString() + sep +
                port.ToString();

            sw.WriteLine(entry);
            sw.Flush();
        }
    }
}