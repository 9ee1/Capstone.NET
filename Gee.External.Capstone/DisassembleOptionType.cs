namespace Gee.External.Capstone {
    /// <summary>
    ///     Disassemble Option Type.
    /// </summary>
    public enum DisassembleOptionType {
        /// <summary>
        ///     Set Disassemble Syntax Option.
        /// </summary>
        Syntax = 1,

        /// <summary>
        ///     Set Disassemble Detail Option.
        /// </summary>
        Detail = 2,

        /// <summary>
        ///     Set Disassemble Mode Option.
        /// </summary>
        Mode = 3,

        /// <summary>
        ///     Set Disassemble User Defined Dynamic Memory Management Option.
        /// </summary>
        DynamicMemoryManagement = 4,

        /// <summary>
        ///     Set Disassemble Skip Data Option.
        /// </summary>
        SkipData = 5,

        /// <summary>
        ///     Set Disassemble Setup Skip Data Option.
        /// </summary>
        SetupSkipData = 6
    }
}