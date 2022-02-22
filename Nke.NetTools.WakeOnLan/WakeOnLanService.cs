using System;
using System.Globalization;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace Nke.NetTools.WakeOnLan
{
    public class WakeOnLanService
    {
        public async Task WakeUp(Host destinationHost)
        {
            if (destinationHost.IsRdpReady())
                return;
            await SendWakeOnLanPacket(destinationHost.Address, destinationHost.MacAddress);
        }
        private async Task SendWakeOnLanPacket(IPAddress localIpAddress, string localMacAddress)
        {
            var magicPacket = new MagicPacket(localMacAddress);
            using var client = new UdpClient();
            client.Connect(IPAddress.Parse("192.168.10.255"), 9);
            await client.SendAsync(magicPacket.Datagram, magicPacket.DatagramLength);
            client.Close();
        }
    }

    internal class MagicPacket
    
    {
        public byte[] Datagram { get; }
        public int DatagramLength { get; }

        public MagicPacket(string macAddress)
        {
            Datagram = CreateDatagram(macAddress);
            DatagramLength = Datagram.Length;
        }

        private byte[] CreateDatagram(string macAddress)
        {
            var datagram = new byte[17*6];

            var test = new byte[1];
            test[0] = 0xFF;
            for (var i = 0; i < 6; i++)
            {
                datagram[i] = 255;
            }

            var macAddressBytes = new byte[6];
            for (var i = 0; i < 6; i++)
            {
                macAddressBytes[i] = byte.Parse(macAddress.Substring(3 * i, 2), NumberStyles.HexNumber);
            }

            // var macAddressBlock = datagram.AsSpan(6, 16 * 6);
            // for (var i = 0; i < 16; i++)
            // {
            //     macAddressBytes.CopyTo(macAddressBlock.Slice(6*i));
            // }
            for (int i = 1; i <= 16; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    datagram[i * 6 + j] = macAddressBytes[j];
                }
            }

            return datagram;
        }
    }
}