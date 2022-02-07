﻿// <auto-generated />

using System;
using System.Buffers.Binary;

namespace Enclave.FastPacket
{
    readonly ref partial struct ReadOnlyIpv4PacketSpan
    {
        private readonly ReadOnlySpan<byte> _span;

        /// <summary>
        /// Defines the minimum possible size of this packet, given all
        /// known fixed sizes.
        /// </summary>
        public const int MinimumSize = 1 + sizeof(byte) + sizeof(ushort) + sizeof(ushort) + 2 + sizeof(byte) + sizeof(byte) + sizeof(ushort) + 4 + 4;

        public ReadOnlyIpv4PacketSpan(ReadOnlySpan<byte> packetData)
        {
            _span = packetData;
        }

        public ReadOnlySpan<byte> GetRawData() => _span;

        
        
        /// <summary>
        /// The Version field indicates the format of the internet header.
        /// For IPv4 this will always have the value 4.
        /// </summary>
        public byte Version
        {
           get => (byte)((_span[0] & 0xF0u) >> 4);
        }
        
        
        /// <summary>
        /// Internet Header Length is the length of the internet header in 32
        /// bit words, and thus points to the beginning of the data.Note that
        /// the minimum value for a correct header is 5.
        /// </summary>
        public byte IHL
        {
           get => (byte)(_span[0] & 0xFu);
        }
        
        
        /// <summary>
        /// Differentiated services field.
        /// </summary>
        /// <remarks>See https://en.wikipedia.org/wiki/Differentiated_services.</remarks>
        public byte Dscp
        {
           get => _span[0 + 1];
        }
        
        
        /// <summary>
        /// Defines the entire packet size in bytes, including header and data.
        /// </summary>
        /// <remarks>
        /// This 16-bit field defines the entire packet size in bytes, including header and data.
        /// The minimum size is 20 bytes (header without data) and the maximum is 65,535 bytes.
        /// All hosts are required to be able to reassemble datagrams of size up to 576 bytes, but
        /// most modern hosts handle much larger packets. Links may impose further restrictions on the
        /// packet size, in which case datagrams must be fragmented. Fragmentation in IPv4 is performed in
        /// either the sending host or in routers. Reassembly is performed at the receiving host.
        /// </remarks>
        public ushort TotalLength
        {
           get => BinaryPrimitives.ReadUInt16BigEndian(_span.Slice(0 + 1 + sizeof(byte)));
        }
        
        
        /// <summary>
        /// This field is an identification field and is primarily used for uniquely identifying the
        /// group of fragments of a single IP datagram.
        /// </summary>
        public ushort Identification
        {
           get => BinaryPrimitives.ReadUInt16BigEndian(_span.Slice(0 + 1 + sizeof(byte) + sizeof(ushort)));
        }
        
        
        /// <summary>
        /// Fragmentation flags.
        /// </summary>
        public Enclave.FastPacket.FragmentFlags FragmentFlags
        {
           get => (Enclave.FastPacket.FragmentFlags)((byte)((_span[0 + 1 + sizeof(byte) + sizeof(ushort) + sizeof(ushort)] & 0xE0u) >> 5));
        }
        
        
        /// <summary>
        /// This field specifies the offset of a particular fragment relative to the beginning
        /// of the original unfragmented IP datagram in units of eight-byte blocks.
        /// </summary>
        public ushort FragmentOffset
        {
           get => (ushort)(BinaryPrimitives.ReadUInt16BigEndian(_span.Slice(0 + 1 + sizeof(byte) + sizeof(ushort) + sizeof(ushort))) & 0x1FFFu);
        }
        
        
        /// <summary>
        /// An eight-bit time to live field limits a datagram's lifetime to prevent network failure in the event of a routing loop.
        /// The field is generally used a hop count, decremented by 1 each time a packet goes through a router.
        /// </summary>
        public byte Ttl
        {
           get => _span[0 + 1 + sizeof(byte) + sizeof(ushort) + sizeof(ushort) + 2];
        }
        
        
        /// <summary>
        /// The protocol code.
        /// </summary>
        public Enclave.FastPacket.IpProtocol Protocol
        {
           get => (Enclave.FastPacket.IpProtocol)(_span[0 + 1 + sizeof(byte) + sizeof(ushort) + sizeof(ushort) + 2 + sizeof(byte)]);
        }
        
        
        /// <summary>
        /// Header checksum field used for error-checking of the header.
        /// </summary>
        public ushort HeaderChecksum
        {
           get => BinaryPrimitives.ReadUInt16BigEndian(_span.Slice(0 + 1 + sizeof(byte) + sizeof(ushort) + sizeof(ushort) + 2 + sizeof(byte) + sizeof(byte)));
        }
        
        
        /// <summary>
        /// The source IPv4 address.
        /// </summary>
        public Enclave.FastPacket.ValueIpAddress Source
        {
           get => new Enclave.FastPacket.ValueIpAddress(_span.Slice(0 + 1 + sizeof(byte) + sizeof(ushort) + sizeof(ushort) + 2 + sizeof(byte) + sizeof(byte) + sizeof(ushort), 4));
        }
        
        
        /// <summary>
        /// The destination IPv4 address.
        /// </summary>
        public Enclave.FastPacket.ValueIpAddress Destination
        {
           get => new Enclave.FastPacket.ValueIpAddress(_span.Slice(0 + 1 + sizeof(byte) + sizeof(ushort) + sizeof(ushort) + 2 + sizeof(byte) + sizeof(byte) + sizeof(ushort) + 4, 4));
        }
        
        
        /// <summary>
        /// An options block (rarely used).
        /// </summary>
        public System.ReadOnlySpan<byte> Options
        {
           get => _span.Slice(0 + 1 + sizeof(byte) + sizeof(ushort) + sizeof(ushort) + 2 + sizeof(byte) + sizeof(byte) + sizeof(ushort) + 4 + 4, Enclave.FastPacket.Ipv4Definition.GetOptionsSize(_span));
        }
        
        
        /// <summary>
        /// The IP payload.
        /// </summary>
        public System.ReadOnlySpan<byte> Payload
        {
           get => _span.Slice(0 + 1 + sizeof(byte) + sizeof(ushort) + sizeof(ushort) + 2 + sizeof(byte) + sizeof(byte) + sizeof(ushort) + 4 + 4 + Enclave.FastPacket.Ipv4Definition.GetOptionsSize(_span));
        }
        
    }
}
