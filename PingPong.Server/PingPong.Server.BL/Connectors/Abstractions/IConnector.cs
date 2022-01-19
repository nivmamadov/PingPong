using PingPong.Server.BL.Communicator.Abstractions;
using PingPong.Server.BL.Listeners.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingPong.Server.BL.Connectors.Abstractions
{
    public interface IConnector
    {
        public void Connect();
        public void TerminateConnection();

        public IListener GetConnectionListener();

        public ICommunicator GetConnectionCommunicator();
    }
}
