using System.Runtime.InteropServices;

namespace Gee.External.Capstone {
    /// <summary>
    ///     Native ARM64 Instruction Operand.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct NativeArm64InstructionOperand {
        /// <summary>
        ///     Operand's Vector Index.
        /// </summary>
        public int VectorIndex;

        /// <summary>
        ///     Operand's Vector Arrangement Specifier.
        /// </summary>
        public int VectorArrangementSpecifier;

        /// <summary>
        ///     Operand's Vector Element Size Specifier.
        /// </summary>
        public int VectorElementSizeSpecifier;

        /// <summary>
        ///     Operand's Shift.
        /// </summary>
        public NativeArm64InstructionOperandShift Shift;

        /// <summary>
        ///     Operand's Extender.
        /// </summary>
        public int Extender;

        /// <summary>
        ///     Operand's Type.
        /// </summary>
        public int Type;

        /// <summary>
        ///     Operand's Value.
        /// </summary>
        public NativeArm64InstructionOperandValue Value;
    }
}