using PingPong.Server.BL.Communicator.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace PingPong.Server.BL.Communicator
{
    public class SocketCommunicator : ICommunicator
    {
        private Socket _communicatingSocket;
        private Socket _clientSocket;

        public SocketCommunicator(Socket communicatingSocket)
        {
            _communicatingSocket = communicatingSocket;
        }
        public byte[] Recieve()
        {
            _clientSocket = _communicatingSocket.Accept();

            byte[] bytes = new byte[1024];
            _clientSocket.Receive(bytes);

            return bytes;
        }

        public void Send(byte[] data)
        {
            _clientSocket.Send(data);
        }
    }
}
