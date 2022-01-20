using PingPong.Server.BL.Communicators.Abstractions;
using System.Net.Sockets;

namespace PingPong.Server.BL.Communicators
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
            if(_clientSocket == null)
            {
                _clientSocket = _communicatingSocket.Accept();
            }

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
