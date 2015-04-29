// ReSharper disable InconsistentNaming

namespace Gee.External.Capstone.Arm {
    /// <summary>
    ///     ARM Memory Barrier.
    /// </summary>
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