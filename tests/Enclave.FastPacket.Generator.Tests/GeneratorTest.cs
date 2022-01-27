using Enclave.FastPacket.Generator.Tests.Helpers;

namespace Enclave.FastPacket.Generator.Tests;

[UsesVerify]
public class GeneratorTest
{
    [Fact]
    public Task CanGenerateDefaultType()
    {
        return CompilationVerifier.Verify(@"
            using Enclave.FastPacket.Generator;

            namespace T
            {
                internal interface IPacketDefinition
                {
                    ushort Value { get; set; }
                }

                [PacketImplementation(typeof(IPacketDefinition))]
                public readonly ref partial struct ValueItem
                {   
                }
            }");
    }

    [Fact]
    public Task CanGenerateTypeWithPositionFunction()
    {
        return CompilationVerifier.Verify(@"

using System;
using Enclave.FastPacket.Generator;

namespace T
{
    internal class PacketDefinition
    {
        [PacketField(Position = 6)]
        ushort Value { get; set; }

        [PacketField(PositionFunction = nameof(GetNextValuePosition))]
        ushort NextValue { get; set; }

        public static int GetNextValuePosition(ReadOnlySpan<byte> packetData, int defaultPosition)
        {
            return defaultPosition;
        }
    }

    [PacketImplementation(typeof(PacketDefinition))]
    public readonly ref partial struct ValueItem
    {   
    }
}
            ");
    }


    [Fact]
    public Task CanGenerateTypeWithEnumValue()
    {
        return CompilationVerifier.Verify(@"

using System;
using Enclave.FastPacket.Generator;

namespace T
{
    [Flags]
    public enum TcpFlags
    {
        Syn = 0x01,
    }

    internal class PacketDefinition
    {
        [PacketField]
        TcpFlags Value { get; set; }
    }

    [PacketImplementation(typeof(PacketDefinition))]
    public readonly ref partial struct ValueItem
    {   
    }
}
            ");
    }

    [Fact]
    public Task CanGenerateTypeWithEnumCustomBackingTypeValue()
    {
        return CompilationVerifier.Verify(@"

using System;
using Enclave.FastPacket.Generator;

namespace T
{
    [Flags]
    public enum TcpFlags
    {
        Syn = 0x01,
    }

    internal class PacketDefinition
    {
        [PacketField(EnumBackingType = typeof(byte))]
        TcpFlags Value { get; set; }
    }

    [PacketImplementation(typeof(PacketDefinition))]
    public readonly ref partial struct ValueItem
    {   
    }
}
            ");
    }


    [Fact]
    public Task CanGenerateTypeWithCustomTypeSizeConstant()
    {
        return CompilationVerifier.Verify(@"

using System;
using Enclave.FastPacket.Generator;

namespace T
{
    public struct HardwareAddress
    {
        public const int Size = 6;

        public HardwareAddress(ReadOnlySpan<byte> span)
        {
        }

        public void CopyTo(Span<byte> destination)
        {
        }
    }

    internal class PacketDefinition
    {
        /// <summary> This is value 1 </summary>
        /// <remarks>
        /// Some extra stuff
        /// </remarks>
        int Value1 { get; set; }

        HardwareAddress Source { get; set; }

        HardwareAddress Destination { get; set; }

        ushort Value2 { get; set; }
    }

    [PacketImplementation(typeof(PacketDefinition), IsReadOnly = true)]
    public readonly ref partial struct PacketParser
    {   
    }
}
            ");
    }

    [Fact]
    public Task CanGenerateTypeWithExternalSize()
    {
        return CompilationVerifier.Verify(@"

using System;
using Enclave.FastPacket.Generator;

namespace T
{
    public struct HardwareAddress
    {
        public HardwareAddress(ReadOnlySpan<byte> span)
        {
        }

        public void CopyTo(Span<byte> destination)
        {
        }
    }

    internal class PacketDefinition
    {
        /// <summary> This is value 1 </summary>
        /// <remarks>
        /// Some extra stuff
        /// </remarks>
        int Value1 { get; set; }

        [PacketField(Size = 6)]
        HardwareAddress Source { get; set; }

        [PacketField(Size = 6)]
        HardwareAddress Destination { get; set; }

        ushort Value2 { get; set; }
    }

    [PacketImplementation(typeof(PacketDefinition))]
    public readonly ref partial struct PacketParser
    {   
    }
}
            ");
    }

    [Fact]
    public Task CanGenerateTypeWithPayload()
    {
        return CompilationVerifier.Verify(@"

using System;
using Enclave.FastPacket.Generator;

namespace T
{
    internal class PacketDefinition
    {
        int Value1 { get; set; }

        ReadOnlySpan<byte> Payload { get; set; }
    }

    [PacketImplementation(typeof(PacketDefinition))]
    public readonly ref partial struct PacketParser
    {   
    }
}
            ");
    }

    [Fact]
    public Task CanGenerateTypeWithLongerNamespace()
    {
        return CompilationVerifier.Verify(@"

using System;
using Enclave.FastPacket.Generator;

namespace Enclave.FastPacket
{
    internal class PacketDefinition
    {
        int Value1 { get; set; }
    }

    [PacketImplementation(typeof(PacketDefinition))]
    public readonly ref partial struct PacketParser
    {   
    }
}
            ");
    }
}
