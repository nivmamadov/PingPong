namespace PingPong.Client.BL.Communicators.Abstractions
{
    public interface ICommunicator
    {
        public byte[] Recieve();
        public void Send(byte[] data);
    }
}
