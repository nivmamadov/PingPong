using PingPong.Client.BL;
using PingPong.Client.BL.Connectors;
using PingPong.Client.BL.Converters;
using PingPong.ConsoleUI.IO;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PingPong.Client.ConsoleUI
{
    public class Bootstrapper
    {
        public async Task Activate(string fullAddress)
        {
            var clientConnector = new TCPClientConnector(fullAddress.Split(":")[0], int.Parse(fullAddress.Split(":")[1]));
            var stringToBytesConverter = new StringToBytesConverter();
            var personToBytesConverter = new PersonToBytesConverter();
            var consoleOutput = new ConsoleOutput();
            var consoleInput = new ConsoleInput();

            var client = new ClientOperator<string>(clientConnector, stringToBytesConverter, consoleOutput);

            consoleOutput.SendOutput("Enter person name:");
            var personName = consoleInput.GetInput();

            consoleOutput.SendOutput("Enter person age:");
            var personAge = int.Parse(consoleInput.GetInput());

            var person = new Person(personName, personAge);
            await client.Send(person, true, personToBytesConverter);

            var serverResponse = await client.Recieve();

            var jsonString = Encoding.UTF8.GetString(serverResponse);
            consoleOutput.SendOutput(jsonString);

            var returnedPerson = JsonSerializer.Deserialize(jsonString, typeof(Person));
            consoleOutput.SendOutput(returnedPerson.ToString());

            client.ShutdownClient();

        }
    }
}
