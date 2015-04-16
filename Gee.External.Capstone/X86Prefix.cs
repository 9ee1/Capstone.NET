// ReSharper disable InconsistentNaming

namespace Gee.External.Capstone {
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

        LOCK = 0xf0,
        REP = 0xf3,
        REPNE = 0xf2,

        // Note.
        //
        // Second Byte.

        CS = 0x2e,
        SS = 0x36,
        DS = 0x3e,
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