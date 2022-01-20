using PingPong.Client.BL.Communicators.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace PingPong.Client.BL.Communicators
{
    public class TCPClientCommunicator : ICommunicator
    {
        public NetworkStream ClientStream { get; set; }
        private TcpClient _tcpClient;
        public TCPClientCommunicator(TcpClient tcpClient)
        {
            _tcpClient = tcpClient; 
            ClientStream = tcpClient.GetStream();
        }
        public byte[] Recieve()
        {
            byte[] response = new byte[1024];
            ClientStream.Read(response, 0, response.Length);
            return response;
        }

        public void Send(byte[] data)
        {
            ClientStream.Write(data, 0, data.Length);
        }
    }
}
