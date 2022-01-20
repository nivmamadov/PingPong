using PingPong.Server.BL.Converters.Abstractions;
using System.Text;

namespace PingPong.Server.BL.Converters
{
    public class StringToBytesConverter : IConverter
    {
        public byte[] Convert(object valueToConvert)
        {
            return Encoding.UTF8.GetBytes(valueToConvert.ToString());
        }
    }
}
