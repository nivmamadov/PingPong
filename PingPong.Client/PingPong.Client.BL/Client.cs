using PingPong.Client.UI.Abstractions;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace PingPong.Client.BL
{
    public class Client<T>
    {
        private IPHostEntry _ipHostEntry;
        private IPAddress _ipAddress;
        private IPEndPoint _ipEndPoint;

        private Socket _socket;

        private IOutput<string> _output;

        private string _hostname;
        private int _port;

        public Client(string hostname, int port, IOutput<string> output)
        {
            _hostname = hostname;
            _port = port;
            _output = output;

            _ipHostEntry = Dns.GetHostEntry(hostname);
            _ipAddress = _ipHostEntry.AddressList[0];
            _ipEndPoint = new IPEndPoint(_ipAddress, _port);

            _socket = new Socket(_ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                ConnectSocket();
                SendMessageToServer("Test message.");
            }
            catch (Exception ex)
            {
                _output.SendOutput(ex.StackTrace);
            }
        }

        public void ConnectSocket()
        {

            _socket.Connect(_ipEndPoint);
            _output.SendOutput($"Connection has been successfully made to {_socket.RemoteEndPoint}.");
        }

        public void SendMessageToServer(string message)
        {
            byte[] messageSent = Encoding.ASCII.GetBytes(message);
            _socket.Send(messageSent);

            GetMessageFromServer();

            _socket.Shutdown(SocketShutdown.Both);
            _socket.Close();
        }

        public void GetMessageFromServer()
        {
            byte[] messageReceived = new byte[1024];

            int byteRecv = _socket.Receive(messageReceived);

            Console.WriteLine($"Server has sent {Encoding.ASCII.GetString(messageReceived, 0, byteRecv)}.");
        }
    }
}
