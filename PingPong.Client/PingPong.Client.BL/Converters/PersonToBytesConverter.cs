using PingPong.Client.BL.Converters.Abstractions;
using System;
using System.Text;
using System.Text.Json;

namespace PingPong.Client.BL.Converters
{
    public class PersonToBytesConverter : IConverter
    {
        public byte[] Convert(object valueToConvert)
        {
            return Encoding.UTF8.GetBytes(JsonSerializer.Serialize((Person)valueToConvert));
        }
    }
}