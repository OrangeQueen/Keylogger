using System.Windows.Forms;
using KeyLogger.Messages.Events;
using ProtoBuf;

namespace KeyLogger.Messages
{
    [ProtoContract]
    public class KeyboardInputMessage : InputMessage
    {
        [ProtoMember(1)]
        public Keys Key { get; set; }

        [ProtoMember(2)]
        public char KeyChar { get; set; }

        [ProtoMember(3)]
        public KeyboardEvent KeyboardEvent { get; set; }
    }
}