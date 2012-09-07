/*  This Source ist just the translation of the C++ Code by Drew Benton to show how it works in C#.Translated by Shadowz75
 
	HandShakeApi Proof-of-Concept Demonstration
	Drew Benton

	This program will effectively show using the basics of the HandShakeApi to accomplish a
	clientless Silkroad program. In this example, the program will connect to the Silkroad server,
	handshake, and then ask for the server stats. The additional logic to keep connected to the
	server is NOT implemented. This code is designed to work on Silkroad verison 1.142 only, if
	there is an update, you will have to update a packet or two. Which ones those are, is a task
	up to you :)
*/

using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Threading;

namespace Swiftness
{
    unsafe class Handler
    {
        
        private static HandshakeApi api = new HandshakeApi();

        public static void Connect()
        {
            socket.Connect("176.9.30.142", 15779);
            Console.Read();
        }

        public static void ProcessJoymaxData(byte[] buffer, int size)
        {
            TPacket* packet;
            fixed (byte* tmpPtr = buffer)
                packet = (TPacket*)tmpPtr;            


            Console.WriteLine("Packet received:\nSize:{0}\nOpCode:{1:X}\nSecurityCount:{2}\nSecurityCRC:{3}\n",
                             packet->size,
                             packet->opcode,
                             packet->securityCount,
                             packet->securityCRC);

            int packet_size = 0;
            bool encrypted = false;

            if ((packet->size & 0x8000) != 0)
            {
                packet_size = (int)api.blowfish.GetOutputLength((ushort)((packet->size & 0x7FFF) + 4)) + 2;
                encrypted = true;
            }

            if (packet->opcode == 0x5000)
                api.OnPacketRecv(buffer, true);

            if (encrypted)
            {
                packet->size &= 0x7FFF;
                api.blowfish.Decode(buffer, 2, buffer, 2, packet_size - 2);
            }

            if (packet->opcode == 0x600D)
            {
                byte[] response = { 0, 0, 1, 97, 0, 0 };
                api.InjectClientToServer(response, false);
            }
            else if (packet->opcode == 0xA101)
            {
              //  Console.Clear();
                Console.WriteLine("Clientless sucess");
                byte* stream = packet->data;
                stream += 2;
                ushort len = *((ushort*)stream);
                stream += 2;
                for (int x = 0; x < len; ++x)
                {
                    Console.Write("{0}", (char)(*((byte*)stream)));
                    stream++;
                }
                Console.WriteLine();
                stream++;
                while (*stream == 1)
                {
                    stream++;
                    ushort id = *((ushort*)stream);
                    stream += 2;
                    len = *((ushort*)stream);
                    stream += 2;
                    byte[] name = new byte[len];
                    for (int x = 0; x < len; ++x)
                    {
                        name[x] = *((byte*)stream);
                        stream++;
                    }
                    ushort curPlayers = *((ushort*)stream);
                    stream += 2;
                    ushort maxPlayers = *((ushort*)stream);
                    stream += 2;
                    byte state = *stream;
                    stream++;
                    Console.WriteLine("{0} - [{1} / {2}]", Encoding.ASCII.GetString(name), curPlayers, maxPlayers);
                }
            }
        }
    }
}