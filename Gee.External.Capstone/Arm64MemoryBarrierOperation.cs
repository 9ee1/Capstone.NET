// ReSharper disable InconsistentNaming

namespace Gee.External.Capstone.Arm64 {
    /// <summary>
    ///     ARM64 Memory Barrier Operation.
    /// </summary>
    public enum Arm64MemoryBarrierOperation {
        /// <summary>
        ///     Invalid Memory Barrier Operation.
        /// </summary>
        Invalid = 0,

        OSHLD = 0x1,
        OSHST = 0x2,
        OSH = 0x3,
        NSHLD = 0x5,
        NSHST = 0x6,
        NSH = 0x7,
        ISHLD = 0x9,
        ISHST = 0xa,
        ISH = 0xB,
        LD = 0xD,
        ST = 0xE,
        SY = 0xF
    }
}