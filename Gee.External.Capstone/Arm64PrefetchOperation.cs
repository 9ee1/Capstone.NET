// ReSharper disable InconsistentNaming

namespace Gee.External.Capstone.Arm64 {
    /// <summary>
    ///     ARM64 Prefetch Operation.
    /// </summary>
    public enum Arm64PrefetchOperation {
        /// <summary>
        ///     Invalid Prefetch Operation.
        /// </summary>
        Invalid = 0,

        PLDL1KEEP = 0x00 + 1,
        PLDL1STRM = 0x01 + 1,
        PLDL2KEEP = 0x02 + 1,
        PLDL2STRM = 0x03 + 1,
        PLDL3KEEP = 0x04 + 1,
        PLDL3STRM = 0x05 + 1,
        PLIL1KEEP = 0x08 + 1,
        PLIL1STRM = 0x09 + 1,
        PLIL2KEEP = 0x0a + 1,
        PLIL2STRM = 0x0b + 1,
        PLIL3KEEP = 0x0c + 1,
        PLIL3STRM = 0x0d + 1,
        PSTL1KEEP = 0x10 + 1,
        PSTL1STRM = 0x11 + 1,
        PSTL2KEEP = 0x12 + 1,
        PSTL2STRM = 0x13 + 1,
        PSTL3KEEP = 0x14 + 1,
        PSTL3STRM = 0x15 + 1
    }
}