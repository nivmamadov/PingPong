using PingPong.Server.BL.Listeners.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace PingPong.Server.BL.Listeners
{
    public class TcpListenerListener : IListener
    {
        private TcpListener _tcpListener;

        public TcpListenerListener(TcpListener tcpListenr)
        {
            _tcpListener = tcpListenr;
        }

        public void Bind()
        {
            
        }

        public void Listen()
        {
            _tcpListener.Start();
        }
    }
}
