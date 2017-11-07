using ProtoBuf;

namespace KeyLogger.Messages
{
    [ProtoContract]
    [ProtoInclude(1, typeof (ControllerInputMessage))]
    [ProtoInclude(2, typeof (KeyboardInputMessage))]
    [ProtoInclude(3, typeof (MouseInputMessage))]
    public abstract class InputMessage
    {
    }
}