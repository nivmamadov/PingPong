using PingPong.Client.BL.Converters.Abstractions;
using System.Text;

namespace PingPong.Client.BL.Converters
{
    public class StringToBytesConverter : IConverter
    {
        public byte[] Convert(object valueToConvert)
        {
            return Encoding.ASCII.GetBytes(valueToConvert.ToString());
        }
    }
}
