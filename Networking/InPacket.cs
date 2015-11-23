using PacketExample.Enums;

using System;
using System.IO;
using System.Text;

namespace PacketExample.Networking
{
    public class InPacket : Packet
    {
        private BinaryReader reader;

        public long Remaining { get { return (stream.Length - stream.Position); } }

        public InPacket(byte[] buffer)
            : base(buffer)
        {
            ushort length = ReadUShort();
            Id = (PacketType)ReadUShort();
        }

        ~InPacket()
        {
            reader.Close();
            reader.Dispose();
        }

        public byte ReadByte()
        {
            if (Remaining < 1)
                throw new IndexOutOfRangeException();
            return reader.ReadByte();
        }

        public sbyte ReadSByte()
        {
            if (Remaining < 1)
                throw new IndexOutOfRangeException();
            return reader.ReadSByte();
        }

        public ushort ReadUShort()
        {
            if (Remaining < 2)
                throw new IndexOutOfRangeException();
            return reader.ReadUInt16();
        }

        public short ReadShort()
        {
            if (Remaining < 2)
                throw new IndexOutOfRangeException();
            return reader.ReadInt16();
        }

        public uint ReadUInt()
        {
            if (Remaining < 4)
                throw new IndexOutOfRangeException();
            return reader.ReadUInt32();
        }

        public int ReadInt()
        {
            if (Remaining < 4)
                throw new IndexOutOfRangeException();
            return reader.ReadInt32();
        }

        public ulong ReadULong()
        {
            if (Remaining < 8)
                throw new IndexOutOfRangeException();
            return reader.ReadUInt64();
        }

        public long ReadLong()
        {
            if (Remaining < 8)
                throw new IndexOutOfRangeException();
            return reader.ReadInt64();
        }

        public float ReadFloat()
        {
            if (Remaining < 4)
                throw new IndexOutOfRangeException();
            return reader.ReadSingle();
        }

        public void Skip(int size)
        {
            if (Remaining < size)
                throw new IndexOutOfRangeException();
            reader.ReadBytes(size); // Skip
        }

        public string ReadString()
        {
            if (Remaining < 2)
                throw new IndexOutOfRangeException();

            int length = (int)ReadUShort();

            if (Remaining < length)
                throw new IndexOutOfRangeException();

            byte[] stringBytes = ReadBytes(length);
            string result = Encoding.UTF8.GetString(stringBytes);

            return result;
        }

        public byte[] ReadBytes(int len)
        {
            byte[] result = new byte[len];
            if (Remaining < result.Length)
                throw new IndexOutOfRangeException();
            this.stream.Read(result, 0, result.Length);
            return result;
        }
    }
}
