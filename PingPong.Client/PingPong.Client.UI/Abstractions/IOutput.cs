namespace PingPong.Client.UI.Abstractions
{
    public interface IOutput<T>
    {
        public void SendOutput(T output);
    }
}
