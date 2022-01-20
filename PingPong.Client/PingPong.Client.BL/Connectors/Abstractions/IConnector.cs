using PingPong.Client.BL.Communicators.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingPong.Client.BL.Connectors.Abstractions
{
    public interface IConnector
    {
        public void Connect();
        public void TerminateConnection();
        public ICommunicator GetConnectionCommunicator();
    }

}
