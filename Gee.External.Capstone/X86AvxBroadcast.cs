namespace Gee.External.Capstone {
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