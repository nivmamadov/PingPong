namespace PingPong.Server.BL.Communicator.Abstractions
{
    public interface ICommunicator
    {
        public byte[] Recieve();
        public void Send(byte[] data);

    }
}
