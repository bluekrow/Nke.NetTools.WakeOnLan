using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Nke.NetTools.WakeOnLan
{
    internal class ConfiguredHost
    {
        public string Ip { get; }
        public string MacAddress { get; }

        public ConfiguredHost(string ipString, string macAddressString)
        {
            Ip = ipString;
            MacAddress = macAddressString;
        }
    }

    internal static class Program
    {
        private static async Task Main()
        {
            var wakeOnLanService = new WakeOnLanService();
            var ipString = "192.168.10.60";
            var macAddressString = "E8:F4:08:02:78:6C";
            var configuredHosts = new List<ConfiguredHost> { new ConfiguredHost(ipString,macAddressString)};
            var configuredHost = configuredHosts[0];

            var selectedHost = new Host(IPAddress.Parse(configuredHost.Ip), configuredHost.MacAddress);
            await wakeOnLanService.WakeUp(selectedHost);

            if (selectedHost.IsRdpReady())
            {
                Console.WriteLine($"Host {selectedHost.Address} is ready for RDP connections.");
            }
        }
    }
}