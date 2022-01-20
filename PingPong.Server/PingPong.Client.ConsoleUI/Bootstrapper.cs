using PingPong.Server.BL;
using PingPong.Server.BL.Connectors;
using PingPong.Server.BL.Converters;
using PingPong.Server.ConsoleUI.IO;
using System.Text;
using System.Threading.Tasks;

namespace PingPong.Server.ConsoleUI
{
    public class Bootstrapper
    {
        public async Task Activate()
        {
            var consoleInput = new ConsoleInput();
            var consoleOutput = new ConsoleOutput();
            var SocketConnection = new TcpListenerConnector("192.168.56.1", 3000);
            var stringToBytesConverter = new StringToBytesConverter();

            ServerOperator serverOperator = new ServerOperator(SocketConnection, stringToBytesConverter);

            await Task.Run(() =>
            {
                while (true)
                {
                    var clientMessageByteArr = serverOperator.Recieve();

                    var clientMessage = Encoding.UTF8.GetString(clientMessageByteArr);

                    consoleOutput.SendOutput(clientMessage);

                    serverOperator.Send(clientMessage, true);

                    serverOperator.ServerCommunicator.CloseCommunication();
                }
            });
        }
    }
}
