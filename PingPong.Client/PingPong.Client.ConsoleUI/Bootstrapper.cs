using PingPong.Client.BL;
using PingPong.Client.BL.Connectors;
using PingPong.Client.BL.Converters;
using PingPong.ConsoleUI.IO;
using System.Text;

namespace PingPong.Client.ConsoleUI
{
    public class Bootstrapper
    {
        public void Activate()
        {
            var clientConnector = new TCPClientConnector("192.168.56.1", 3000);
            var stringToBytesConverter = new StringToBytesConverter();
            var consoleOutput = new ConsoleOutput();
            var consoleInput = new ConsoleInput();

            var client = new ClientOperator<string>(clientConnector, stringToBytesConverter, consoleOutput);

            while(true)
            {
                consoleOutput.SendOutput("Enter your message to the server:");
                client.Send(consoleInput.GetInput(), true, null);
                consoleOutput.SendOutput(Encoding.ASCII.GetString(client.Recieve()));
            }
        }
    }
}
