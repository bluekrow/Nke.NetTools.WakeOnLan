using System.Net;
using System.Threading.Tasks;

namespace Nke.NetTools.WakeOnLan
{
    internal static class Program
    {
        private static async Task Main(string[] args)
        {
            var wakeOnLanService = new WakeOnLanService();
            var ipString = "192.168.10.60";
            var macAddressString = "E8:F4:08:02:78:6C";
            await wakeOnLanService.WakeUp(new Host(IPAddress.Parse(ipString),macAddressString));
        }
    }
}