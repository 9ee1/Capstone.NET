using System.Diagnostics.CodeAnalysis;

namespace Gee.External.Capstone.X86 {
    /// <summary>
    ///     X86 SSE Condition Code.
    /// </summary>
    [SuppressMessage("ReSharper", "IdentifierTypo")]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public enum X86SseConditionCode {
        /// <summary>
        ///     Indicates an invalid, or an uninitialized, SSE condition code.
        /// </summary>
        Invalid = 0,
        EQ,
        LT,
        LE,
        UNORD,
        NEQ,
        NLT,
        NLE,
        ORD
    }
}