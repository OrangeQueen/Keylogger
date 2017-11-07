using ProtoBuf;

namespace KeyLogger.Messages
{
    [ProtoContract]
    public class ControllerInputMessage : InputMessage
    {
        [ProtoMember(1)]
        public bool A { get; set; }

        [ProtoMember(2)]
        public bool B { get; set; }

        [ProtoMember(3)]
        public bool X { get; set; }

        [ProtoMember(4)]
        public bool Y { get; set; }

        [ProtoMember(5)]
        public bool RightShoulder { get; set; }

        [ProtoMember(6)]
        public bool LeftShoulder { get; set; }

        [ProtoMember(7)]
        public bool Start { get; set; }

        [ProtoMember(8)]
        public bool Back { get; set; }

        [ProtoMember(9)]
        public int RightTrigger { get; set; }

        [ProtoMember(10)]
        public int LeftTrigger { get; set; }

        [ProtoMember(11)]
        public bool DPadUp { get; set; }

        [ProtoMember(12)]
        public bool DPadLeft { get; set; }

        [ProtoMember(13)]
        public bool DPadDown { get; set; }

        [ProtoMember(14)]
        public bool DPadRight { get; set; }

        [ProtoMember(15)]
        public bool LeftStick { get; set; }

        [ProtoMember(16)]
        public bool RightStick { get; set; }

        [ProtoMember(17)]
        public Point LeftThumbStick { get; set; }

        [ProtoMember(18)]
        public Point RightThumbStick { get; set; }

        [ProtoContract]
        public class Point
        {
            [ProtoMember(1)]
            public int X { get; set; }

            [ProtoMember(2)]
            public int Y { get; set; }
        }
    }
}