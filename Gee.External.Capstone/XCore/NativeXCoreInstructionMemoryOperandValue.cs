using System.Runtime.InteropServices;

namespace Gee.External.Capstone.XCore {
    /// <summary>
    ///     Native XCore Instruction Memory Operand Value.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct NativeXCoreInstructionMemoryOperandValue {
        /// <summary>
        ///     Operand Value's Base Register.
        /// </summary>
        public byte BaseRegister;

        /// <summary>
        ///     Operand Value's Index Register.
        /// </summary>
        public byte IndexRegister;

        /// <summary>
        ///     Operand Value's Displacement Value.
        /// </summary>
        public int Displacement;

        /// <summary>
        ///     Operand Value's Direction Value.
        /// </summary>
        public int Direction;
    }
}