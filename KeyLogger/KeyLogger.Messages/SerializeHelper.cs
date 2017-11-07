using System.IO;
using ProtoBuf;

namespace KeyLogger.Messages
{
    public static class SerializeHelper
    {
        public static byte[] Serialize<T>(T input)
        {
            using (var ms = new MemoryStream())
            {
                Serializer.Serialize(ms, input);

                return ms.ToArray();
            }
        }

        public static T Deserialize<T>(byte[] input)
        {
            using (var ms = new MemoryStream(input))
            {
                return Serializer.Deserialize<T>(ms);
            }
        }
    }
}