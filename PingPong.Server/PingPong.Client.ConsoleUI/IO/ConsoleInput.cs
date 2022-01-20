using PingPong.Server.UI.Abstractions;
using System;

namespace PingPong.Server.ConsoleUI.IO
{
    public class ConsoleInput : IInput<string>
    {
        public string GetInput()
        {
            return Console.ReadLine();
        }
    }
}
