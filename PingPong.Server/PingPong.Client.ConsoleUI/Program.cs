using System.Threading.Tasks;

namespace PingPong.Server.ConsoleUI
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            Bootstrapper bootstrapper = new Bootstrapper();
            await bootstrapper.Activate();
        }
    }
}
