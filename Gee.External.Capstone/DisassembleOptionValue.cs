namespace Gee.External.Capstone {
    /// <summary>
    ///     Disassemble Option Value.
    /// </summary>
    public enum DisassembleOptionValue {
        /// <summary>
        ///     Turn off a Disassemble Option.
        /// </summary>
        /// <remarks>
        ///     Indicates that a supported disassemble option should be turned off. Please note that not all
        ///     disassemble options support this value.
        /// </remarks>
        Off = 0,

        /// <summary>
        ///     Turn on a Disassemble Option.
        /// </summary>
        /// <remarks>
        ///     Indicates that a supported disassemble option should be turned on. Please note that not all
        ///     disassemble options support this value.
        /// </remarks>
        On = 3
    }
}