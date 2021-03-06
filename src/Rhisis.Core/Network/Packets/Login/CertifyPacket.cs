﻿using Ether.Network.Packets;
using Rhisis.Core.Cryptography;
using System;
using System.Linq;
using System.Text;

namespace Rhisis.Core.Network.Packets.Login
{
    public struct CertifyPacket : IEquatable<CertifyPacket>
    {
        public string BuildVersion { get; private set; }

        public string Username { get; private set; }

        public string Password { get; private set; }

        public CertifyPacket(NetPacketBase packet, bool encryptPassword, string encryptionKey)
        {
            var ffPacket = packet as FFPacket;
            this.BuildVersion = packet.Read<string>();
            this.Username = packet.Read<string>();

            if (encryptPassword)
            {
                byte[] passwordData = ffPacket.ReadBytes(16 * 42);
                var key = Encoding.ASCII.GetBytes(encryptionKey).Concat(Enumerable.Repeat((byte)0, 5).ToArray()).ToArray();

                this.Password = Rijndael.DecryptData(passwordData, key).Trim('\0');
            }
            else
                this.Password = packet.Read<string>();
        }

        public bool Equals(CertifyPacket other)
        {
            return this.BuildVersion == other.BuildVersion &&
                this.Username == other.Username &&
                this.Password == other.Password;
        }
    }
}
