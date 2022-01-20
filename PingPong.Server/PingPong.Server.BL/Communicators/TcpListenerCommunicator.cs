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
            _client = _server.AcceptTcpClient();

            _clientStream = _client.GetStream();

            byte[] clientInquiry = new byte[1024];
            int clientInquiryBytes = _clientStream.Read(clientInquiry, 0, clientInquiry.Length);

            return clientInquiry[..clientInquiryBytes];
        }

        public void Send(byte[] data)
        {
            _clientStream.Write(data, 0, data.Length);
        }

        public void CloseCommunication()
        {
            _clientStream.Close();
            _client.Close();
        }
    }
}
