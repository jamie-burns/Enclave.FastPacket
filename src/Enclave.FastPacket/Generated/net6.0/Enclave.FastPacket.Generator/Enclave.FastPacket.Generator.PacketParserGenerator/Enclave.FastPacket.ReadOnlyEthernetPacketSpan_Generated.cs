﻿// <auto-generated />

using System;
using System.Buffers.Binary;

namespace Enclave.FastPacket
{
    readonly ref partial struct ReadOnlyEthernetPacketSpan
    {
        private readonly ReadOnlySpan<byte> _span;

        /// <summary>
        /// Defines the minimum possible size of this packet, given all
        /// known fixed sizes.
        /// </summary>
        public const int MinimumSize = Enclave.FastPacket.HardwareAddress.Size + Enclave.FastPacket.HardwareAddress.Size + sizeof(ushort);

        public ReadOnlyEthernetPacketSpan(ReadOnlySpan<byte> packetData)
        {
            _span = packetData;
        }

        public ReadOnlySpan<byte> GetRawData() => _span;

        
        
        /// <summary>
        /// The destination hardware (MAC) address.
        /// </summary>
        public Enclave.FastPacket.HardwareAddress Destination
        {
           get => new Enclave.FastPacket.HardwareAddress(_span.Slice(0, Enclave.FastPacket.HardwareAddress.Size));
        }
        
        
        /// <summary>
        /// The source hardware (MAC) address.
        /// </summary>
        public Enclave.FastPacket.HardwareAddress Source
        {
           get => new Enclave.FastPacket.HardwareAddress(_span.Slice(0 + Enclave.FastPacket.HardwareAddress.Size, Enclave.FastPacket.HardwareAddress.Size));
        }
        
        
        /// <summary>
        /// The EtherType field.
        /// </summary>
        public Enclave.FastPacket.EthernetType Type
        {
           get => (Enclave.FastPacket.EthernetType)(BinaryPrimitives.ReadUInt16BigEndian(_span.Slice(0 + Enclave.FastPacket.HardwareAddress.Size + Enclave.FastPacket.HardwareAddress.Size)));
        }
        
        
        /// <summary>
        /// The Ethernet Payload.
        /// </summary>
        public System.ReadOnlySpan<byte> Payload
        {
           get => _span.Slice(0 + Enclave.FastPacket.HardwareAddress.Size + Enclave.FastPacket.HardwareAddress.Size + sizeof(ushort));
        }
        
    }
}
