// ReSharper disable InconsistentNaming

namespace Gee.External.Capstone.Arm64 {
    /// <summary>
    ///     ARM64 Extender.
    /// </summary>
    public enum Arm64Extender {
        /// <summary>
        ///     Invalid Extender.
        /// </summary>
        Invalid = 0,

        UXTB = 1,
        UXTH = 2,
        UXTW = 3,
        UXTX = 4,
        SXTB = 5,
        SXTH = 6,
        SXTW = 7,
        SXTX = 8
    }
}