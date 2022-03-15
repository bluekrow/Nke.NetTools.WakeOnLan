using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Nke.NetTools.WakeOnLan
{
    internal static class Program
    {
        private static async Task Main()
        {
            var configuredHosts = new ConfiguredHosts("ConfiguredHosts.json");
            var configuredHostsFromSettings = await configuredHosts.List();

            if (configuredHosts.IsEmpty)
            {
                configuredHostsFromSettings = new List<ConfiguredHost>();
                Console.WriteLine($"There is no Host configured!");
            }
                
            foreach (var savedHost in configuredHostsFromSettings)
            {
                Console.WriteLine($"IP:{savedHost.Ip}, MacAddress:{savedHost.MacAddress}");
            }

            var wakeOnLanService = new WakeOnLanService();
            var configuredHost = (await configuredHosts.List())[0];

            var selectedHost = new Host(IPAddress.Parse(configuredHost.Ip), configuredHost.MacAddress);
            await wakeOnLanService.WakeUp(selectedHost);

            if (selectedHost.IsRdpReady())
            {
                Console.WriteLine($"Host {selectedHost.Address} is ready for RDP connections.");
            }
        }
    }
}