using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingPong.Server.BL.Converters.Abstractions
{
    public interface IConverter<T>
    {
        public byte[] Convert(T valueToConvert) ;
    }
}
