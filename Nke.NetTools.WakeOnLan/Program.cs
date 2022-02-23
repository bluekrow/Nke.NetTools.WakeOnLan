using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace Nke.NetTools.WakeOnLan
{
    internal static class Program
    {
        private static async Task Main()
        {
            var configuredHostsSettings = await File.ReadAllTextAsync(Path.Combine(Directory.GetCurrentDirectory(),"ConfiguredHosts.json"));
            var configuredHostsFromSettings = new List<ConfiguredHost>();
             configuredHostsFromSettings =  JsonSerializer.Deserialize<IEnumerable<ConfiguredHost>>(configuredHostsSettings);

            if (configuredHostsSettings?.Length == 0)
            {
                Console.WriteLine($"There is no Host configured!");
            }
                
            foreach (var savedHost in configuredHostsFromSettings)
            {
                Console.WriteLine($"IP:{savedHost.Ip}, MacAddress:{savedHost.MacAddress}");
            }

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