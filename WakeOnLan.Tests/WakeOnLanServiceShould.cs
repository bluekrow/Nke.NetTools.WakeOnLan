using FluentAssertions;
using Xunit;

namespace WakeOnLan.Tests
{
    public class WakeOnLanServiceShould
    {
        [Fact]
        public void WakeUpHost()
        {
            var destinationHost = new Host();
            var wakOnLanService = new WakeOnLanService();
            destinationHost.IsAwake.Should().BeFalse();
            
            wakOnLanService.WakeUp(destinationHost);
            
            destinationHost.IsAwake.Should().BeTrue();
        }
    }
}