// ReSharper disable InconsistentNaming

namespace Gee.External.Capstone.Arm {
    /// <summary>
    ///     ARM Instruction Operand Shift Type.
    /// </summary>
    public enum ArmInstructionOperandShiftType {
        /// <summary>
        ///     Invalid Shift Type.
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