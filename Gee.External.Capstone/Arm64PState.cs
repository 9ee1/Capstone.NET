 // ReSharper disable InconsistentNaming

namespace Gee.External.Capstone.Arm64 {
    /// <summary>
    ///     ARM64 PState.
    /// </summary>
    public enum Arm64PState {
        /// <summary>
        ///     Invalid PState.
        /// </summary>
        Invalid = 0,

        SPSEL = 0x05,
        DAIFSET = 0x1E,
        DAIFCLR = 0x1F
    }
}