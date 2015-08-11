using System.Diagnostics.CodeAnalysis;

#pragma warning disable 1591

namespace Gee.External.Capstone.Arm {
    /// <summary>
    ///     ARM Memory Barrier.
    /// </summary>
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    [SuppressMessage("ReSharper", "IdentifierTypo")]
    public enum ArmMemoryBarrier {
        /// <summary>
        ///     Invalid Memory Barrier.
        /// </summary>
        Invalid = 0,

        RESERVED_0,
        OSHLD,
        OSHST,
        OSH,
        RESERVED_4,
        NSHLD,
        NSHST,
        NSH,
        RESERVED_8,
        ISHLD,
        ISHST,
        ISH,
        RESERVED_12,
        LD,
        ST,
        SY
    }
}