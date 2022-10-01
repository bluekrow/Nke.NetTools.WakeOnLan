using System.Net;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace Nke.NetTools.WakeOnLan.Tests
{
    public class WakeOnLanServiceShould
    {
        [Fact]
        public async Task WakeUpHostAsync()
        {
            var testIpAddress = IPAddress.Parse("192.168.10.60");
            var destinationHost = new Host(testIpAddress, "E8:F4:08:02:78:6C");
            var wakOnLanService = new WakeOnLanService();
            //destinationHost.IsRdpReady().Should().BeFalse();
            
            await wakOnLanService.WakeUp(destinationHost);
            
            destinationHost.IsRdpReady().Should().BeTrue();
        }
    }
}