using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingPong.Server.BL.Communicator.Abstractions
{
    public interface ICommunicator
    {
        public byte[] Recieve();
        public void Send(byte[] data);

    }
}
