using System.Net;
using System.Net.Sockets;

namespace Nke.NetTools.WakeOnLan
{
    public class Host
    {
        public IPAddress Address { get; }
        public string MacAddress { get; }
        
        public Host(IPAddress address, string macAddress)
        {
            Address = address;
            MacAddress = macAddress;
        }

        public bool IsRdpReady()
        {
            using var tcpClient = new TcpClient();
            const int RDP_PORT = 3389;
            const int RDP_SOCKET_TIMEOUT = 500;
            try
            {
                tcpClient.ConnectAsync(Address.ToString(), RDP_PORT).Wait(RDP_SOCKET_TIMEOUT);
                return tcpClient.Connected;
            }
            catch (SocketException) { }
            finally
            {
                tcpClient.Close();
            }
            return false;
        }
    }
}