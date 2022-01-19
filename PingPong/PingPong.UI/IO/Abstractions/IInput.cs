using System;

namespace PingPong.UI.IO.Abstractions
{
    public interface IInput<T>
    {
        public T GetInput();
    }
}
