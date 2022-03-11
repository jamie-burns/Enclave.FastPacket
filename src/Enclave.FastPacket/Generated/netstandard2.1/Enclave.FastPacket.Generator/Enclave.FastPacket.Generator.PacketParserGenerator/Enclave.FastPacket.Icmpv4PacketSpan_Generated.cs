﻿// <auto-generated />

using System;
using System.Buffers.Binary;

namespace Enclave.FastPacket
{
    readonly ref partial struct Icmpv4PacketSpan
    {
        private readonly Span<byte> _span;

        /// <summary>
        /// Defines the minimum possible size of this packet, given all
        /// known fixed sizes.
        /// </summary>
        public const int MinimumSize = sizeof(byte) + sizeof(byte) + sizeof(ushort) + 4;

        /// <summary>
        /// Create a new instance of <see cref="Icmpv4PacketSpan"/>.
        /// </summary>
        public Icmpv4PacketSpan(Span<byte> packetData)
        {
            _span = packetData;
        }

        /// <summary>
        /// Gets the raw underlying buffer for this packet.
        /// </summary>
        public Span<byte> GetRawData() => _span;
        
        
        /// <summary>
        /// Indicates the type of the ICMP packet.
        /// </summary>
        public Enclave.FastPacket.Icmpv4Types Type
        {
           get => (Enclave.FastPacket.Icmpv4Types)(_span[0]);
           set => _span[0] = (byte)(value); 
        }
        
        
        /// <summary>
        /// Defines the ICMP Code value.
        /// </summary>
        public byte Code
        {
           get => _span[0 + sizeof(byte)];
           set => _span[0 + sizeof(byte)] = value; 
        }
        
        
        /// <summary>
        /// The ICMP packet checksum.
        /// </summary>
        public ushort Checksum
        {
           get => BinaryPrimitives.ReadUInt16BigEndian(_span.Slice(0 + sizeof(byte) + sizeof(byte)));
           set => BinaryPrimitives.WriteUInt16BigEndian(_span.Slice(0 + sizeof(byte) + sizeof(byte)), value); 
        }
        
        
        /// <summary>
        /// The rest of the header. Use the As* methods to get the typed packet.
        /// </summary>
        public System.Span<byte> RestOfHeader
        {
           get => _span.Slice(0 + sizeof(byte) + sizeof(byte) + sizeof(ushort), 4);
        }
        
        
        /// <summary>
        /// The 'Data' portion of the ICMP header.
        /// </summary>
        public System.Span<byte> Data
        {
           get => _span.Slice(0 + sizeof(byte) + sizeof(byte) + sizeof(ushort) + 4);
        }
        
        /// <summary>
        /// Get a string representation of this packet.
        /// </summary>
        public override string ToString()
        {
            return $"Type: {Type}; Code: {Code}; Checksum: {Checksum}; RestOfHeader: {RestOfHeader.Length} bytes; Data: {Data.Length} bytes";
        }
        
        /// <summary>
        /// Get the computed total size of this packet, including any dynamically-sized fields and trailing payloads.
        /// </summary>
        public int GetTotalSize()
        {
            return 0 + sizeof(byte) + sizeof(byte) + sizeof(ushort) + 4 + _span.Slice(0 + sizeof(byte) + sizeof(byte) + sizeof(ushort) + 4).Length;
        }
    }
}
