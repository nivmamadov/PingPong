using PingPong.Server.BL.Communicator.Abstractions;
using PingPong.Server.BL.Connectors.Abstractions;
using PingPong.Server.BL.Converters.Abstractions;
using PingPong.Server.BL.Listeners.Abstractions;
using PingPong.Server.UI.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingPong.Server.BL
{
    public class ServerOperator<T, K>
    {
        private IListener _serverListener;
        private IConnector _serverConnector;
        private ICommunicator _serverCommunicator;
        private IConverter<T> _serverConverter;
        private IOutput<K> _serverOutput;

        public ServerOperator(IConnector connector, IConverter<T> converter, IOutput<K> output)
        {
            _serverConnector = connector;

            _serverConnector.Connect();

            _serverCommunicator = _serverConnector.GetConnectionCommunicator();
            _serverListener = _serverConnector.GetConnectionListener();

            _serverListener.Bind();

            _serverConverter = converter;
            _serverOutput = output;

            _serverListener.Listen();
        }

        public void Send(T obj)
        {
            _serverCommunicator.Send(_serverConverter.Convert(obj)); 
        }

        public byte[] Recieve()
        {
            return _serverCommunicator.Recieve();
        }

        public void Output(K output)
        {
            _serverOutput.SendOutput(output);
        }

        public void CloseServer()
        {
            _serverConnector.TerminateConnection();
        }
    }
}
