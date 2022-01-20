using PingPong.Client.BL.Communicators.Abstractions;
using PingPong.Client.BL.Connectors.Abstractions;
using PingPong.Client.BL.Converters.Abstractions;
using PingPong.Client.UI.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingPong.Client.BL
{
    public class ClientOperator<K>
    {
        private IConnector _clientConnector;
        private ICommunicator _clientCommunicator;
        private IConverter _clientConverter;
        private IOutput<K> _clientOutput;

        public ClientOperator(IConnector serverConnector, ICommunicator serverCommunicator, IConverter serverConverter, IOutput<K> serverOutput)
        {
            _clientConnector = serverConnector;
            _clientConnector.Connect();

            _clientCommunicator = _clientConnector.GetConnectionCommunicator();

            _clientConverter = serverConverter;
            _clientOutput = serverOutput;
        }

        public void Send(object obj, bool needsConversion, IConverter optionalConverter)
        {
            if (needsConversion)
            {
                if (optionalConverter == null)
                {
                    _clientCommunicator.Send(_clientConverter.Convert(obj));

                }
                else
                {
                    _clientCommunicator.Send(optionalConverter.Convert(obj));
                }
            }
            else
            {
                _clientCommunicator.Send((byte[])obj);
            }
        }

        public byte[] Recieve()
        {
            return _clientCommunicator.Recieve();
        }

        public void ShutdownClient()
        {
            _clientConnector.TerminateConnection();
        }
    }
}
