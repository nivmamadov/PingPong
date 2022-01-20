using PingPong.Client.UI.Abstractions;
using System;

namespace PingPong.ConsoleUI.IO
{
    public class ConsoleOutput : IOutput<string>
    {
        public void SendOutput(string output)
        {
            Console.WriteLine(output);
        }
    }
}
