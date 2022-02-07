﻿// <auto-generated />

using System;
using System.Buffers.Binary;

namespace Enclave.FastPacket.Icmp
{
    readonly ref partial struct ReadOnlyIcmpv4AddressMaskSpan
    {
        private readonly ReadOnlySpan<byte> _span;

        /// <summary>
        /// Defines the minimum possible size of this packet, given all
        /// known fixed sizes.
        /// </summary>
        public const int MinimumSize = sizeof(byte) + sizeof(byte) + sizeof(ushort) + sizeof(ushort) + sizeof(ushort) + sizeof(uint);

        public ReadOnlyIcmpv4AddressMaskSpan(ReadOnlySpan<byte> packetData)
        {
            _span = packetData;
        }

        public ReadOnlySpan<byte> GetRawData() => _span;

        
        
        public Enclave.FastPacket.Icmpv4Types Type
        {
           get => (Enclave.FastPacket.Icmpv4Types)(_span[0]);
        }
        
        
        public byte Code
        {
           get => _span[0 + sizeof(byte)];
        }
        
        
        public ushort Checksum
        {
           get => BinaryPrimitives.ReadUInt16BigEndian(_span.Slice(0 + sizeof(byte) + sizeof(byte)));
        }
        
        
        public ushort Identifier
        {
           get => BinaryPrimitives.ReadUInt16BigEndian(_span.Slice(0 + sizeof(byte) + sizeof(byte) + sizeof(ushort)));
        }
        
        
        public ushort SequenceNumber
        {
           get => BinaryPrimitives.ReadUInt16BigEndian(_span.Slice(0 + sizeof(byte) + sizeof(byte) + sizeof(ushort) + sizeof(ushort)));
        }
        
        
        public uint AddressMask
        {
           get => BinaryPrimitives.ReadUInt32BigEndian(_span.Slice(0 + sizeof(byte) + sizeof(byte) + sizeof(ushort) + sizeof(ushort) + sizeof(ushort)));
        }
        
    }
}
