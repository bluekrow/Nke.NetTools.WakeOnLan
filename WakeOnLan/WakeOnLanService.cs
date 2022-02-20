using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace WakeOnLan
{
    public class WakeOnLanService
    {
        public async Task WakeUp(Host destinationHost)
        {
            if (destinationHost.IsAwake())
                return;
            await SendWakeOnLanPacket(destinationHost.Address);
        }
        private async Task SendWakeOnLanPacket(IPAddress localIpAddress)
        {
            IPAddress multicastIpAddress = null;
            byte[] magicPacket = null;
            using UdpClient client = new UdpClient(new IPEndPoint(localIpAddress, 0));
              await client.SendAsync(magicPacket, magicPacket.Length, multicastIpAddress.ToString(), 9);
        }
    }
}