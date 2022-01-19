using PingPong.Client.UI.Abstractions;
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace PingPong.Server
{
    public class Server
    {
        private Socket _listeningSocket;
        private Socket _clientSocket;
        private IPHostEntry _ipHostEntry;
        private IPEndPoint _ipEndpoint;
        private IPAddress _ipAddress;

        private int _port;

        public Server(int port, IOutput<string> output)
        {
            _port = port;

            _ipHostEntry = Dns.GetHostEntry(Dns.GetHostName());
            _ipAddress = _ipHostEntry.AddressList[0];
            _ipEndpoint = new IPEndPoint(_ipAddress, _port);
            _listeningSocket = new Socket(_ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            StartListening();
        }

        public void StartListening()
        {
            _listeningSocket.Bind(_ipEndpoint);
            _listeningSocket.Listen();

            GetMessageFromClient();
        }

        public void SendMessageToClient(string message)
        {
            byte[] messageBytes = Encoding.ASCII.GetBytes(message);
            _clientSocket.Send(messageBytes);
        }

        public void GetMessageFromClient()
        {
            while (true)
            {
                _clientSocket = _listeningSocket.Accept();

                byte[] bytes = new byte[1024];
                string recievedData = null;

                int numByte = _clientSocket.Receive(bytes);
                recievedData += Encoding.ASCII.GetString(bytes, 0, numByte);

                Console.WriteLine($"Client has sent {recievedData}.");

                SendMessageToClient("test message");

                _clientSocket.Shutdown(SocketShutdown.Both);
                _clientSocket.Close();
            }
        }
    }
}
