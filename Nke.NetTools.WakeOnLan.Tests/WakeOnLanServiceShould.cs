using System.Net;
using FluentAssertions;
using Xunit;

namespace Nke.NetTools.WakeOnLan.Tests
{
    public class WakeOnLanServiceShould
    {
        [Fact]
        public void WakeUpHost()
        {
            var testIpAddress = IPAddress.Parse("192.168.10.60");
            var destinationHost = new Host(testIpAddress);
            var wakOnLanService = new WakeOnLanService();
            //destinationHost.IsAwake().Should().BeFalse();
            
            wakOnLanService.WakeUp(destinationHost);
            
            destinationHost.IsAwake().Should().BeTrue();
        }
    }
}