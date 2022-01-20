using PingPong.Server.UI.Abstractions;
using System;

namespace PingPong.Server.ConsoleUI.IO
{
    public class ConsoleOutput : IOutput<string>
    {
        public void SendOutput(string output)
        {
            Console.WriteLine(output);
        }
    }
}
