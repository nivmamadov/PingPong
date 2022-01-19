using PingPong.Server.BL.Converters.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingPong.Server.BL.Converters
{
    public class StringToBytesConverter : IConverter<string>
    {
        public byte[] Convert(string valueToConvert)
        {
            return Encoding.ASCII.GetBytes(valueToConvert);
        }
    }
}
