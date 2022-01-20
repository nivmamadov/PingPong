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
        public async Task<byte[]> Recieve()
        {
            byte[] response = new byte[1024];
            int responseBytes = await ClientStream.ReadAsync(response, 0, response.Length);
            return response[..responseBytes];
        }

        public async Task Send(byte[] data)
        {
            await ClientStream.WriteAsync(data, 0, data.Length);
        }
    }
}
