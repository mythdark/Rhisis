﻿using Ether.Network;
using Ether.Network.Packets;
using Rhisis.Core.ISC;
using Rhisis.Core.ISC.Packets;

namespace Rhisis.Cluster.ISC
{
    public static class ISCPackets
    {
        /// <summary>
        /// Send an authentication request to the IPCServer
        /// </summary>
        /// <param name="client">client connection</param>
        /// <param name="id">Server Id</param>
        /// <param name="host">Server Host</param>
        /// <param name="name">Server name</param>
        public static void SendAuthentication(INetClient client, int id, string host, string name)
        {
            using (var packet = new NetPacket())
            {
                packet.Write((uint)InterPacketType.Authentication);
                packet.Write(id);
                packet.Write(host);
                packet.Write(name);
                packet.Write((byte)InterServerType.Cluster);

                client.Send(packet);
            }
        }
    }
}
