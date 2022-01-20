using PingPong.Server.BL.Communicators.Abstractions;
using System.Net.Sockets;
using System.Threading.Tasks;

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

        public void CloseCommunication()
        {
            _clientSocket.Close();
        }

        public byte[] Recieve()
        {
            byte[] bytes = new byte[1024];
            _clientSocket = _communicatingSocket.Accept();
            _clientSocket.Receive(bytes);

            return bytes;
        }

        public void Send(byte[] data)
        {
            _clientSocket.Send(data);
        }
    }
}
