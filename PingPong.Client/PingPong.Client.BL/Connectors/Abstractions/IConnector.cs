using PingPong.Client.BL.Communicators.Abstractions;

namespace PingPong.Client.BL.Connectors.Abstractions
{
    public interface IConnector
    {
        public void Connect();
        public void TerminateConnection();
        public ICommunicator GetConnectionCommunicator();
    }

}
