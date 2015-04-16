// ReSharper disable InconsistentNaming

namespace Gee.External.Capstone {
    /// <summary>
    ///     X86 AVX Code Condition.
    /// </summary>
    public enum X86AvxCodeCondition {
        /// <summary>
        ///     Invalid AVX Code Condition.
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
        TRUE,
        EQ_OS,
        LT_OQ,
        LE_OQ,
        UNORD_S,
        NEQ_US,
        NLT_UQ,
        NLE_UQ,
        ORD_S,
        EQ_US,
        NGE_UQ,
        NGT_UQ,
        FALSE_OS,
        NEQ_OS,
        GE_OQ,
        GT_OQ,
        TRUE_US
    }
}