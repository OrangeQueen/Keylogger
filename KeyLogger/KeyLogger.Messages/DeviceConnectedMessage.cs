using ProtoBuf;

namespace KeyLogger.Messages
{
    [ProtoContract]
    public class DeviceConnectedMessage
    {
        [ProtoMember(1)]
        public bool? Mouse { get; set; }

        [ProtoMember(2)]
        public bool? Keyboard { get; set; }

        [ProtoMember(3)]
        public bool? Controller { get; set; }
    }
}