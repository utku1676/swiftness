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
using System.Net;
using System.Net.Sockets;

namespace Swiftness
{
    class socket
    {
        static IAsyncResult result;
        public static AsyncCallback pfnCallBack;
        public static Socket winSock;

        public class SocketPacket
        {
            public Socket socket;
            public byte[] dataBuffer = new byte[8024];
        }

        public static void Connect(string IP, int Port)
        {
            winSock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPAddress ip = IPAddress.Parse(IP);
            IPEndPoint IPEP = new IPEndPoint(ip, Port);
            try
            {
                winSock.Connect(IPEP);
                WaitForData();
            }
            catch (SocketException se)
            {
                Console.WriteLine("Socket Exception:{0}", se.Message);
            }
        }
        public static void Disconnect()
        {
            winSock.Shutdown(SocketShutdown.Both);
            winSock.Close();
        }
        public static void WaitForData()
        {
            try
            {
                if (pfnCallBack == null)
                {
                    pfnCallBack = new AsyncCallback(OnDataReceived);
                }
                SocketPacket SockP = new SocketPacket();
                SockP.socket = winSock;

                result = winSock.BeginReceive(SockP.dataBuffer,
                                                        0, SockP.dataBuffer.Length,
                                                        SocketFlags.None,
                                                        pfnCallBack,
                                                        SockP);
            }
            catch (SocketException se)
            {
                Console.WriteLine("Socket Exception:{0}", se.Message);
            }
        }

        public static void OnDataReceived(IAsyncResult asyn)
        {
            try
            {
                SocketPacket SockId = (SocketPacket)asyn.AsyncState;
                int size = SockId.socket.EndReceive(asyn);
                Handler.ProcessJoymaxData(SockId.dataBuffer, size);

                WaitForData();
            }
            catch (SocketException se)
            {
                Console.WriteLine("Socket Exception:{0}",se.Message);
            }
        }
    }
}
