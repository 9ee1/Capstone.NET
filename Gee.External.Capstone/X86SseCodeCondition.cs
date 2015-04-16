// ReSharper disable InconsistentNaming

namespace Gee.External.Capstone {
    /// <summary>
    ///     X86 SSE Code Condition.
    /// </summary>
    public enum X86SSECodeCondition {
        /// <summary>
        ///     Invalid SSE Code Condition.
        /// </summary>
        Invalid = 0,

        EQ,
        LT,
        LE,
        UNORD,
        NEQ,
        NLT,
        NLE,
        ORD,
        EQ_UQ,
        NGE,
        NGT,
        FALSE,
        NEQ_OQ,
        GE,
        GT,
        TRUE
    }
}