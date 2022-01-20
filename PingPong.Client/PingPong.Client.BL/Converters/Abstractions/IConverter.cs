using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingPong.Client.BL.Converters.Abstractions
{
    public interface IConverter
    {
        public byte[] Convert(object valueToConvert);
    }
}
