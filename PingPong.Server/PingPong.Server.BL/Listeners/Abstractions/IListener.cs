namespace PingPong.Server.BL.Listeners.Abstractions
{
    public interface IListener
    {
        public void Bind();
        public void Listen();
    }
}
