#pragma warning disable 1591

namespace Gee.External.Capstone.Arm {
    /// <summary>
    ///     ARM Instruction Operand Type.
    /// </summary>
    public enum ArmInstructionOperandType {
        /// <summary>
        ///     Invalid Instruction Operand Type.
        /// </summary>
        Invalid = 0,

        Register,
        Immediate,
        Memory,
        FloatingPoint,
        CImmediate = 64,
        PImmediate,
        SetEnd,
        SysRegister
    }
}