using PingPong.Client.UI.IO.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
