namespace PingPong.Server.UI.IO.Abstractions
{
    public interface IInput<T>
    {
        public T GetInput();
    }
}
