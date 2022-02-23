namespace Nke.NetTools.WakeOnLan
{
    public class ConfiguredHost
    {
        public string Ip { get; }
        public string MacAddress { get; }

        public ConfiguredHost(string ip, string macAddress)
        {
            Ip = ip;
            MacAddress = macAddress;
        }
    }
}