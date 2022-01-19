using System;

namespace PingPong.UI.IO.Abstractions
{
    public interface IOutput<T>
    {
        public void SendOutput(T output); 
    }
}
