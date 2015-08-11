// ReSharper disable InconsistentNaming

namespace Gee.External.Capstone.X86 {
    /// <summary>
    ///     X86 Prefix.
    /// </summary>
    public enum X86Prefix {
        /// <summary>
        ///     Irrelevant Prefix.
        /// </summary>
        Irrelevant = 0,

        // Note.
        //
        // First Byte. 

        LOCK = 0xF0,
        REP = 0xF3,
        REPNE = 0xF2,

        // Note.
        //
        // Second Byte.

        CS = 0x2E,
        SS = 0x36,
        DS = 0x3E,
        ES = 0x26,
        FS = 0x64,
        GS = 0x65,

        // Note.
        //
        // Third Byte.

        OPERANDSIZE = 0x66,

        // Note.
        //
        // Fourth Byte.

        ADDRESSSIZE = 0x67
    }
}