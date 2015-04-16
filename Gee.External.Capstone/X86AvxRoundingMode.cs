namespace Gee.External.Capstone {
    /// <summary>
    ///     X86 AVX Rounding Mode.
    /// </summary>
    public enum X86AvxRoundingMode {
        /// <summary>
        ///     Invalid AVX Rounding Mode.
        /// </summary>
        Invalid = 0,

        RoundNearest,
        RoundDown,
        RoundUp,
        RoundTowardZero
    }
}