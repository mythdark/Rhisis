﻿using Ether.Network.Packets;
using System;

namespace Rhisis.Core.Network.Packets.Cluster
{
    public struct PreJoinPacket : IEquatable<PreJoinPacket>
    {
        public string Username { get; private set; }

        public int CharacterId { get; private set; }

        public string CharacterName { get; private set; }

        public int BankCode { get; private set; }

        public PreJoinPacket(NetPacketBase packet)
        {
            this.Username = packet.Read<string>();
            this.CharacterId = packet.Read<int>();
            this.CharacterName = packet.Read<string>();
            this.BankCode = packet.Read<int>();
        }

        public bool Equals(PreJoinPacket other)
        {
            return this.Username.Equals(other.Username) &&
                this.CharacterId == other.CharacterId &&
                this.CharacterName.Equals(other.CharacterName) &&
                this.BankCode == other.BankCode;
        }
    }
}
