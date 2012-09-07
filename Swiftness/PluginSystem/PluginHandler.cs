using System;
using System.Collections.Generic;
using System.Text;

namespace Swiftness.PluginSystem
{
    static unsafe class PluginHandler
    {
        public delegate void PacketHandler(TPacket* packet);

        public static void RegisterPacketHandler(PacketDirection direction, ushort OpCode, PacketHandler handler)
        {

        }

    }

    enum PacketDirection
    {
        FROM_CLIENT,
        TO_CLIENT,
        FROM_SERVER,
        TO_SERVER
    }

    struct TPacket
    {

    }
}
