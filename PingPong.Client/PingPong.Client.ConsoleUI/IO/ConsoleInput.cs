using PingPong.Client.UI.IO.Abstractions;
using System;

namespace PingPong.Client.ConsoleUI
{
    public class ConsoleInput : IInput<string>
    {
        public string GetInput()
        {
            return Console.ReadLine();
        }
    }
}
