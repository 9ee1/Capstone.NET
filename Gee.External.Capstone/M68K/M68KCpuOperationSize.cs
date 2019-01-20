namespace Gee.External.Capstone.M68K {
    /// <summary>
    ///     M68K CPU Operation Size.
    /// </summary>
    public enum M68KCpuOperationSize {
        /// <summary>
        ///     Indicates an invalid, or an uninitialized, CPU operation size.
        /// </summary>
        Invalid = 0,

        /// <summary>
        ///     Indicates a signed 8-bit CPU operation size.
        /// </summary>
        Byte = 1,

        /// <summary>
        ///     Indicates a signed 16-bit CPU operation size.
        /// </summary>
        Word = 2,

        /// <summary>
        ///     Indicates a signed 32-bit CPU operation size.
        /// </summary>
        Long = 4
    }
}