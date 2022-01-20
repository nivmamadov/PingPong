using PingPong.Client.BL.Communicators.Abstractions;
using System.Net.Sockets;
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

        public async Task<byte[]> Recieve()
        {
            var messageReceived = new byte[1024];
            var messageRecievedLength = _clientSocket.Receive(messageReceived);

            return await Task.FromResult(messageReceived[..messageRecievedLength]);
        }

        public async Task Send(byte[] data)
        {
            _clientSocket.Send(data);
            await Task.CompletedTask;
        }
    }
}
