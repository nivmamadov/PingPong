namespace PingPong.Server.UI.Abstractions
{
    public interface IOutput<T>
    {
        public void SendOutput(T output);
    }
}
