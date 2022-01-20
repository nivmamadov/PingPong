using PingPong.Server.BL.Communicators.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace PingPong.Server.BL.Communicators
{
    public class TcpListenerCommunicator : ICommunicator
    {
        private TcpListener _server;
        private TcpClient _client;
        private NetworkStream _clientStream;

        public TcpListenerCommunicator(TcpListener server)
        {
            _server = server;
        }

        public byte[] Recieve()
        {
            if (_client == null)
            {
                _client = _server.AcceptTcpClient();
                _clientStream = _client.GetStream();
            }

            byte[] bytes = new byte[1024];

            _clientStream.Read(bytes, 0, bytes.Length);
            return bytes;
        }

        public void Send(byte[] data)
        {
            _clientStream.Write(data, 0, data.Length);
        }
    }
}
