using PacketExample.Enums;
using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacketExample.Networking
{
    public class Packet
    {
        protected MemoryStream stream;

        public PacketType Id { get; protected set; }

        public Packet(byte[] buffer)
        {
            stream = new MemoryStream(buffer);
            stream.Seek(0, SeekOrigin.Begin);
        }

        public Packet(PacketType type)
        {
            this.Id = Id;
        }

        ~Packet()
        {
            stream.Close();
            stream.Dispose();
        }

        public virtual byte[] GetBuffer()
        {
            return stream.ToArray();
        }

    }
}
