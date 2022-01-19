using PingPong.UI.IO.Abstractions;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace PingPong.Client
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
        }
    }
}
