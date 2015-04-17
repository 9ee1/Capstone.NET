// ReSharper disable InconsistentNaming

namespace Gee.External.Capstone {
    /// <summary>
    ///     ARM Code Condition.
    /// </summary>
    public enum ArmCodeCondition {
        /// <summary>
        ///     Invalid Code Condition.
        /// </summary>
        Invalid = 0,

        EQ,
        NE,
        HS,
        LO,
        MI,
        PL,
        VS,
        VC,
        HI,
        LS,
        GE,
        LT,
        GT,
        LE,
        AL
    }
}