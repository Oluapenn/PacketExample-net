using PacketExample.Enums;

using System;
using System.IO;

namespace PacketExample.Networking
{
    public class OutPacket : Packet
    {
        private StreamWriter writer;

        public OutPacket(PacketType type)
            : base(type)
        {
            writer = new StreamWriter(stream);
            Write((ushort)0); // Will be replaced w/ length later. (Will be content size).
            Write((ushort)Id); // Writes the id to the packet.
        }

        ~OutPacket()
        {
            writer.Close();
            writer.Dispose();
        }

        public void Write(bool value)
        {
            writer.Write((byte)(value ? 1 : 0));
        }

        public void Write(byte value)
        {
            writer.Write(value);
        }

        public void Write(byte[] value)
        {
            writer.Write(value);
        }

        public void Write(short value)
        {
            writer.Write(value);
        }

        public void Write(ushort value)
        {
            writer.Write(value);
        }

        public void Write(int value)
        {
            writer.Write(value);
        }

        public void Write(uint value)
        {
            writer.Write(value);
        }

        public void Write(long value)
        {
            writer.Write(value);
        }

        public void Write(ulong value)
        {
            writer.Write(value);
        }

        public void Write(float value)
        {
            writer.Write(value);
        }

        public void Write(string value)
        {
            byte[] stringBuffer = System.Text.Encoding.UTF8.GetBytes(value);
            if (stringBuffer.Length > ushort.MaxValue)
                throw new Exception("The stringBuffer length is longer then the max value fo ushort.");
            Write((ushort)stringBuffer.Length);
            Write(stringBuffer);
        }

        public override byte[] GetBuffer()
        {
            byte[] buffer = base.GetBuffer();
            ushort length = (ushort)(buffer.Length - 4); // Remove the header size so we have the content size.
            byte[] num = BitConverter.GetBytes(length);

            // First 2 bytes
            buffer[0] = num[0];
            buffer[1] = num[1];

            return buffer;
        }
    }
}
