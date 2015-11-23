using PacketExample.Networking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacketExample.Packets
{
    class PlayersPacket : OutPacket
    {
        public PlayersPacket()
            : base(Enums.PacketType.Something)
        {
            Write((ushort)5); // Player Count

            for(ushort i = 0; i < 5; i++)
            {
                Write(i); // User Entity Id.
                Write("Username" + i); // Username
                Write((ushort)(6 + i)); // Level (Example);
                Write("SuperCoolSomething"); // Something
                Write(123.5F); // Position X
                Write(123.5F); // Position X
                Write(123.5F); // Position X
            }
        }
    }
}
