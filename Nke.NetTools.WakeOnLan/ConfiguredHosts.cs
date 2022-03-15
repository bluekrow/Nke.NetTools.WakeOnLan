using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace Nke.NetTools.WakeOnLan
{
    internal class ConfiguredHosts
    {
        private readonly string configuredHostsJson;

        public bool IsEmpty { get; private set; }

        public ConfiguredHosts(string configuredHostsJson)
        {
            this.configuredHostsJson = configuredHostsJson;
        }

        public async Task<List<ConfiguredHost>> List()
        {
            var configuredHostsSettings = await File.ReadAllTextAsync(Path.Combine(Directory.GetCurrentDirectory(), configuredHostsJson));

            if (!string.IsNullOrWhiteSpace(configuredHostsSettings))
                return JsonSerializer.Deserialize<List<ConfiguredHost>>(configuredHostsSettings);
            IsEmpty = true;
            return new List<ConfiguredHost>();

        }
    }
}