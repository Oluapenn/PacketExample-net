using PacketExample.Enums;
using PacketExample.Networking;

namespace PacketExample.Packets
{
    public class ChatPacket : OutPacket
    {
        public ChatPacket(string username, string message)
            : base(PacketType.Chat)
        {
            Write((byte)1); // Type
            Write(username);
            Write(message);
            Write(true); // Is Gm (an example).
        }
    }
}
