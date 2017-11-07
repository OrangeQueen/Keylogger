using System.Windows.Forms;
using KeyLogger.Messages.Events;
using ProtoBuf;

namespace KeyLogger.Messages
{
    [ProtoContract]
    public class MouseInputMessage : InputMessage
    {
        [ProtoMember(1)]
        public int X { get; set; }

        [ProtoMember(2)]
        public int Y { get; set; }

        [ProtoMember(3)]
        public int Delta { get; set; }

        [ProtoMember(4)]
        public MouseButtons MouseButton { get; set; }

        [ProtoMember(5)]
        public MouseEvent MouseEvent { get; set; }
    }
}