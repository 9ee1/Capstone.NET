using System.Runtime.InteropServices;

namespace Gee.External.Capstone.Sparc {
    /// <summary>
    ///     Native SPARC Instruction Memory Operand Value.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct NativeSparcInstructionMemoryOperandValue {
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
    }
}