﻿//HintName: T.ValueItem_Generated.cs
// <auto-generated />

using System;
using System.Buffers.Binary;

namespace T
{
    readonly ref partial struct ValueItem
    {
        private readonly Span<byte> _span;

        /// <summary>
        /// Defines the minimum possible size of this packet, given all
        /// known fixed sizes.
        /// </summary>
        public const int MinimumSize = 0;

        /// <summary>
        /// Create a new instance of <see cref="ValueItem"/>.
        /// </summary>
        public ValueItem(Span<byte> packetData)
        {
            _span = packetData;
        }

        /// <summary>
        /// Gets the raw underlying buffer for this packet.
        /// </summary>
        public Span<byte> GetRawData() => _span;
        
        
        public System.Span<byte> Value
        {
           get => _span.Slice(0, T.PacketDefinition.ValueFunc(_span, 0));
        }
        
        
        public System.Span<byte> Value2
        {
           get => _span.Slice(0 + T.PacketDefinition.ValueFunc(_span, 0), T.PacketDefinition.Value2Func(_span));
        }
        
        
        public System.Span<byte> Remaining
        {
           get => _span.Slice(0 + T.PacketDefinition.ValueFunc(_span, 0) + T.PacketDefinition.Value2Func(_span));
        }
        
        /// <summary>
        /// Get a string representation of this packet.
        /// </summary>
        public override string ToString()
        {
            return $"Value: {Value.Length} bytes; Value2: {Value2.Length} bytes; Remaining: {Remaining.Length} bytes";
        }
        
        /// <summary>
        /// Get the computed total size of this packet, including any dynamically-sized fields and trailing payloads.
        /// </summary>
        public int GetTotalSize()
        {
            return 0 + T.PacketDefinition.ValueFunc(_span, 0) + T.PacketDefinition.Value2Func(_span) + _span.Slice(0 + T.PacketDefinition.ValueFunc(_span, 0) + T.PacketDefinition.Value2Func(_span)).Length;
        }
    }
}
