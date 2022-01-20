using PingPong.Server.BL;
using PingPong.Server.BL.Connectors;
using PingPong.Server.BL.Converters;
using PingPong.Server.ConsoleUI.IO;

namespace PingPong.Server.ConsoleUI
{
    public class Bootstrapper
    {
        public void Activate()
        {
            var consoleInput = new ConsoleInput();
            var consoleOutput = new ConsoleOutput();
            var SocketConnection = new SocketConnector(3000);
            var stringToBytesConverter = new StringToBytesConverter();

            ServerOperator<string> serverOperator = new ServerOperator<string>(SocketConnection, consoleOutput, stringToBytesConverter);
            serverOperator.Send(serverOperator.Recieve(), false, null);
        }
    }
}
