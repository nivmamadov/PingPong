using PingPong.Client.BL.Communicators.Abstractions;
using PingPong.Client.BL.Connectors.Abstractions;
using PingPong.Client.BL.Converters.Abstractions;
using PingPong.Client.UI.Abstractions;
using System.Threading.Tasks;

namespace PingPong.Client.BL
{
    public class ClientOperator<K>
    {
        private IConnector _clientConnector;
        private ICommunicator _clientCommunicator;
        private IConverter _clientConverter;
        private IOutput<K> _clientOutput;

        public ClientOperator(IConnector clientConnector, IConverter clientConverter, IOutput<K> clientOutput)
        {
            _clientConnector = clientConnector;
            _clientConnector.Connect();

            _clientCommunicator = _clientConnector.GetConnectionCommunicator();

            _clientConverter = clientConverter;
            _clientOutput = clientOutput;
        }

        public async Task Send(object obj, bool needsConversion, IConverter optionalConverter)
        {
            if (needsConversion)
            {
                if (optionalConverter == null)
                {
                    await _clientCommunicator.Send(_clientConverter.Convert(obj));

                }
                else
                {
                    await _clientCommunicator.Send(optionalConverter.Convert(obj));
                }
            }
            else
            {
                await _clientCommunicator.Send((byte[])obj);
            }
        }

        public async Task<byte[]> Recieve()
        {
            return await _clientCommunicator.Recieve();
        }

        public void ShutdownClient()
        {
            _clientConnector.TerminateConnection();
        }
    }
}
