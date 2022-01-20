using System.Threading.Tasks;

namespace PingPong.Client.BL.Communicators.Abstractions
{
    public interface ICommunicator
    {
        public Task<byte[]> Recieve();
        public Task Send(byte[] data);
    }
}
