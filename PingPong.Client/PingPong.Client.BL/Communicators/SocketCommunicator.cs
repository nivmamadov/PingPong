using PingPong.Client.BL.Communicators.Abstractions;
using System.Net.Sockets;

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
