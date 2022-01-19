using PingPong.Server.UI.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
