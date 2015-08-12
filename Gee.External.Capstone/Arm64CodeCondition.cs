// ReSharper disable InconsistentNaming

namespace Gee.External.Capstone.Arm64 {
    /// <summary>
    ///     ARM64 Code Condition.
    /// </summary>
    public enum Arm64CodeCondition {
        /// <summary>
        ///     Invalid Code Condition.
        /// </summary>
        Invalid = 0,

        EQ = 1,
        NE = 2,
        HS = 3,
        LO = 4,
        MI = 5,
        PL = 6,
        VS = 7,
        VC = 8,
        HI = 9,
        LS = 10,
        GE = 11,
        LT = 12,
        GT = 13,
        LE = 14,
        AL = 15,
        NV = 16
    }
}