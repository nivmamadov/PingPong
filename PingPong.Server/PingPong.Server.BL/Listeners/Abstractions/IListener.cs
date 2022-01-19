using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingPong.Server.BL.Listeners.Abstractions
{
    public interface IListener
    {
        public void Bind();
        public void Listen();
    }
}
