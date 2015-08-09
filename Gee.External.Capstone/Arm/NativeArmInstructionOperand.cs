using System.Runtime.InteropServices;

namespace Gee.External.Capstone.Arm {
    /// <summary>
    ///     Native ARM Instruction Operand.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct NativeArmInstructionOperand {
        /// <summary>
        ///     Operand's Vector Index.
        /// </summary>
        public int VectorIndex;

        /// <summary>
        ///     Operand's Shift.
        /// </summary>
        public NativeArmShifter Shifter;

        /// <summary>
        ///     Operand's Type.
        /// </summary>
        public int Type;

        /// <summary>
        ///     Operand's Value.
        /// </summary>
        public NativeArmInstructionOperandValue Value;

        /// <summary>
        ///     Operand's Subtracted Flag.
        /// </summary>
        public bool IsSubtracted;
    }
}