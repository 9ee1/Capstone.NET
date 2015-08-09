namespace Gee.External.Capstone.X86 {
    /// <summary>
    ///     X86 AVX Broadcast.
    /// </summary>
    public enum X86AvxBroadcast {
        /// <summary>
        ///     Invalid AVX Broadcast.
        /// </summary>
        Invalid = 0,

        Broadcast2,
        Broadcast4,
        Broadcast8,
        Broadcast16
    }
}