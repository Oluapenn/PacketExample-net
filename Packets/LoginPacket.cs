using PacketExample.Enums;
using PacketExample.Networking;

namespace PacketExample.Packets
{
    class LoginPacket : OutPacket
    {
        public LoginPacket()
            : base(PacketType.Login)
        {
            Write("Username");
            Write("Password");
            Write(123);
            Write(false);
        }
    }
}
