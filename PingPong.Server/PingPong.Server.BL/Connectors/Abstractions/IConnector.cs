using PingPong.Server.BL.Communicators.Abstractions;
using PingPong.Server.BL.Listeners.Abstractions;

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
