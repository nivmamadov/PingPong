namespace PingPong.Server.BL.Converters.Abstractions
{
    public interface IConverter
    {
        public byte[] Convert(object valueToConvert);
    }
}
