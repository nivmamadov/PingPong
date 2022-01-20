using PingPong.Server.BL.Communicators.Abstractions;
using PingPong.Server.BL.Connectors.Abstractions;
using PingPong.Server.BL.Converters.Abstractions;
using PingPong.Server.BL.Listeners.Abstractions;
using PingPong.Server.UI.Abstractions;
using System.Text.Json;
using System.Threading.Tasks;

namespace PingPong.Server.BL
{
    public class ServerOperator
    {
        public ICommunicator ServerCommunicator { get; set; }
        private IListener _serverListener;
        private IConnector _serverConnector;
        private IConverter _serverConverter;

        public ServerOperator(IConnector connector, IConverter converter)
        {
            _serverConverter = converter; 

            _serverConnector = connector;
            _serverConnector.Connect();

            ServerCommunicator = _serverConnector.GetConnectionCommunicator();
            _serverListener = _serverConnector.GetConnectionListener();

            _serverListener.Bind();
            _serverListener.Listen();
        }

        public void Send(object obj, bool needsConversion, IConverter optionalConverter = null)
        {
            if (needsConversion)
            {
                if (optionalConverter == null)
                {
                    ServerCommunicator.Send(_serverConverter.Convert(obj));
                }
                else
                {
                    ServerCommunicator.Send(optionalConverter.Convert(obj));
                }
            }
            
            else
            {
                 ServerCommunicator.Send((byte[])obj);
            }
        }

        public byte[] Recieve()
        {
             return ServerCommunicator.Recieve();     
        }

        public void CloseServer()
        {
            _serverConnector.TerminateConnection();
        }
    }
}
