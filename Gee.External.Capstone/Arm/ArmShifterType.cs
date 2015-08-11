using System.Diagnostics.CodeAnalysis;

#pragma warning disable 1591

namespace Gee.External.Capstone.Arm {
    /// <summary>
    ///     ARM Shifter Type.
    /// </summary>
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public enum ArmShifterType {
        /// <summary>
        ///     Invalid Shifter Type.
        /// </summary>
        Invalid = 0,

        ASR,
        LSL,
        LSR,
        ROR,
        RRX,
        ASR_REG,
        LSL_REG,
        LSR_REG,
        ROR_REG,
        RRX_REG
    }
}