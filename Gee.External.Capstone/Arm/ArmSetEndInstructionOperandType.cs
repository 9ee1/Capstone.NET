// ReSharper disable InconsistentNaming

namespace Gee.External.Capstone.Arm {
    /// <summary>
    ///     ARM SETEND Instruction Operand Type.
    /// </summary>
    public enum ArmSetEndInstructionOperandType {
        /// <summary>
        ///     Invalid Operand Type.
        /// </summary>
        Invalid = 0,

        BE,
        LE
    }
}