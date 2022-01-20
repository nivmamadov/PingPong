﻿using PingPong.Server.BL.Communicators.Abstractions;
using PingPong.Server.BL.Connectors.Abstractions;
using PingPong.Server.BL.Converters.Abstractions;
using PingPong.Server.BL.Listeners.Abstractions;
using PingPong.Server.UI.Abstractions;

namespace PingPong.Server.BL
{
    public class ServerOperator<K>
    {
        private IListener _serverListener;
        private IConnector _serverConnector;
        private ICommunicator _serverCommunicator;
        private IConverter _serverConverter;
        private IOutput<K> _serverOutput;

        public ServerOperator(IConnector connector, IOutput<K> output, IConverter converter)
        {
            _serverOutput = output;

            _serverConverter = converter; 

            _serverConnector = connector;
            _serverConnector.Connect();

            _serverCommunicator = _serverConnector.GetConnectionCommunicator();
            _serverListener = _serverConnector.GetConnectionListener();

            _serverListener.Bind();
            _serverListener.Listen();
        }

        public void Send(object obj, bool needsConversion, IConverter optionalConverter)
        {
            if (needsConversion)
            {
                if (optionalConverter == null)
                {
                    _serverCommunicator.Send(_serverConverter.Convert(obj));

                }
                else
                {
                    _serverCommunicator.Send(optionalConverter.Convert(obj));
                }
            }
            else
            {
                _serverCommunicator.Send((byte[])obj);
            }
        }

        public byte[] Recieve()
        {
            byte[] clientMessage = _serverCommunicator.Recieve();
            return clientMessage;
        }

        public void CloseServer()
        {
            _serverConnector.TerminateConnection();
        }
    }
}
