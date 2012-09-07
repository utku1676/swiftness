using System;
using System.Text;
using System.Runtime.InteropServices;

namespace Swiftness
{
    [StructLayoutAttribute(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct TPacket
    {
        public ushort size;
        public ushort opcode;
        public byte securityCount;
        public byte securityCRC;
        public fixed byte data[8186];
    };

    [StructLayoutAttribute(LayoutKind.Sequential, Pack = 1)]
    unsafe struct TPacket_5000			// First/second packets received from the server
    {
        public ushort size;				// Size of this packet
        public ushort opcode;			// Opcode of this packet (0x5000)
        public byte securityCount;		// Security count byte (0 from server to client packets)
        public byte securityCRC;		// Security crc byte (0 from server to client packets)
        public byte flag;				// Internal flag
    }

    [StructLayoutAttribute(LayoutKind.Sequential, Pack = 1)]
    unsafe struct  TPacket_5000_10		// Second packet received from the server
    {
        public ushort size;				// Size of this packet (0xF)
        public ushort opcode;			// Opcode of this packet (0x5000)
        public byte securityCount;		// Security count byte (0 from server to client packets)
        public byte securityCRC;		// Security crc byte (0 from server to client packets)
        public byte flag;				// Internal flag (0x10)
        public fixed uint challenge[2];		// Challenge value to make sure everything is legit
    }

    [StructLayoutAttribute(LayoutKind.Sequential, Pack = 1)]
    unsafe struct TPacket_5000_E		// First packet received from the server
    {
        public ushort size;				// Size of this packet (0x25)
        public ushort opcode;			// Opcode of this packet (0x5000)
        public byte securityCount;		// Security count byte (0 from server to client packets)
        public byte securityCRC;		// Security crc byte (0 from server to client packets)
        public byte flag;				// Internal flag (0xE)
        public fixed byte blowfish[8];		// Initial blowfish key
        public uint seedCount;		// security count seed 
        public uint seedCRC;			// security crc seed 
        public fixed uint seedSecurity[5];	// Additional seeds used
    }
}
