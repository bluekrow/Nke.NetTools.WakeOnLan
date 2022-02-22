using System.Net;
using FluentAssertions;
using Xunit;

namespace Nke.NetTools.WakeOnLan.Tests
{
    public class HostShould
    {
        [Fact]
        public void DetectIfAHostIsNotRdpReady()
        {
            var testIpAddress = IPAddress.Parse("192.168.5.5");
            var destinationHost = new Host(testIpAddress, "TODO");
            destinationHost.IsRdpReady().Should().BeFalse();
        }
        
        [Fact]
        public void DetectIfAHostIsRdpReady()
        {
            var testIpAddress = IPAddress.Parse("127.0.0.1");
            var destinationHost = new Host(testIpAddress, "TODO");
            destinationHost.IsRdpReady().Should().BeTrue();
        }

    }
}