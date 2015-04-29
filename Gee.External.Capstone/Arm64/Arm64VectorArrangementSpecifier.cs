// ReSharper disable InconsistentNaming

namespace Gee.External.Capstone.Arm64 {
    /// <summary>
    ///     ARM64 Vector Arrangement Specifier.
    /// </summary>
    public enum Arm64VectorArrangementSpecifier {
        /// <summary>
        ///     Invalid Vector Arrangement Specifier.
        /// </summary>
        Invalid = 0,

        VAS8B,
        VAS16B,
        VAS4H,
        VAS8H,
        VAS2S,
        VAS4S,
        VAS1D,
        VAS2D,
        VAS1Q
    }
}