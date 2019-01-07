using System.Diagnostics.CodeAnalysis;

namespace Gee.External.Capstone.X86 {
    /// <summary>
    ///     X86 Prefix.
    /// </summary>
    [SuppressMessage("ReSharper", "IdentifierTypo")]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public enum X86Prefix : byte {
        /// <summary>
        ///     Indicates an invalid, or an uninitialized, prefix.
        /// </summary>
        Invalid = 0,
        LOCK = 0xF0,
        REP = 0xF3,
        REPE = 0xF3,
        REPNE = 0xF2,
        CS = 0x2e,
        SS = 0x36,
        DS = 0x3e,
        ES = 0x26,
        FS = 0x64,
        GS = 0x65,
        OPSIZE = 0x66,
        ADDRSIZE = 0x67
    }
}