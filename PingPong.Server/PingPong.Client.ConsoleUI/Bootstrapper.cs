using PingPong.Server.BL;
using PingPong.Server.BL.Connectors;
using PingPong.Server.BL.Converters;
using PingPong.Server.BL.Listeners;
using PingPong.Server.ConsoleUI.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            ServerOperator<string, string> serverOperator = new ServerOperator<string, string>(SocketConnection, stringToBytesConverter, consoleOutput);
            serverOperator.Send("Noob");
            serverOperator.CloseServer();
        }
    }
}
