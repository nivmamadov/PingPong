using PingPong.Client.BL.Communicators.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace PingPong.Client.BL.Communicators
{
    public class SocketCommunicator : ICommunicator
    {
        private Socket _clientSocket;

        public SocketCommunicator(Socket clientSocket)
        {
            _clientSocket = clientSocket;
        }

        public byte[] Recieve()
        {
            byte[] messageReceived = new byte[1024];
            _clientSocket.Receive(messageReceived);

            return messageReceived;
        }

        public void Send(byte[] data)
        {
            _clientSocket.Send(data);
        }
    }
}
