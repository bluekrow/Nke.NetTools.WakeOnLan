using System.Net;
using System.Net.NetworkInformation;

namespace Nke.NetTools.WakeOnLan
{
    public record Host
    {
        public Host(IPAddress address)
        {
            Address = address;
        }

        public bool IsAwake()
        {
            var pingSender = new Ping ();
            var reply = pingSender.Send (Address);
            if (reply == null)
                return false;
            return reply.Status == IPStatus.Success;
        }
        public IPAddress Address { get; }
    }
}