namespace PacketExample.Enums
{
    public enum PacketType : ushort
    {
        Unknown = 0,
        Handshake,
        Login,
        Entities,
        MapData,
        Chat,
        Something
    }
}
