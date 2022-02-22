using System.Net;
using System.Net.Sockets;

namespace Nke.NetTools.WakeOnLan
{
    public record Host
    {
        public Host(IPAddress address, string macAddress)
        {
            Address = address;
            MacAddress = macAddress;
        }

        public bool IsRdpReady()
        {
            using var tcpClient = new TcpClient();
            const int RDP_PORT = 3389;
            try
            {
                tcpClient.Connect(Address.ToString(), RDP_PORT);
                return tcpClient.Connected;
            }
            catch (SocketException) { }
            return false;
        }

        public IPAddress Address { get; }
        public string MacAddress { get; }
    }
}