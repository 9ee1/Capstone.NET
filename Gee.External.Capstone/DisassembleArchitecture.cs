namespace Gee.External.Capstone {
    /// <summary>
    ///     Disassemble Architecture.
    /// </summary>
    public enum DisassembleArchitecture {
        /// <summary>
        ///     ARM Architecture.
        /// </summary>
        Arm = 0,

        /// <summary>
        ///     ARM-64 Architecture.
        /// </summary>
        Arm64 = 1,

        /// <summary>
        ///     MIPS Architecture.
        /// </summary>
        Mips = 2,

        /// <summary>
        ///     Intel X86 Architecture.
        /// </summary>
        X86 = 3,

        /// <summary>
        ///     PowerPC Architecture.
        /// </summary>
        PowerPc = 4,

        /// <summary>
        ///     SPARC Architecture.
        /// </summary>
        Sparc = 5,

        /// <summary>
        ///     SystemZ Architecture.
        /// </summary>
        SystemZ = 6,

        /// <summary>
        ///     XCore Architecture.
        /// </summary>
        XCore = 7
    }
}