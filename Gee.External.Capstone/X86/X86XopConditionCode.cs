using System.Diagnostics.CodeAnalysis;

namespace Gee.External.Capstone.X86 {
    /// <summary>
    ///     X86 XOP Condition Code.
    /// </summary>
    [SuppressMessage("ReSharper", "IdentifierTypo")]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public enum X86XopConditionCode {
        /// <summary>
        ///     Indicates an invalid, or an uninitialized, XOP condition code.
        /// </summary>
        Invalid = 0,
        LT,
        LE,
        GT,
        GE,
        EQ,
        NEQ,
        FALSE,
        TRUE
    }
}