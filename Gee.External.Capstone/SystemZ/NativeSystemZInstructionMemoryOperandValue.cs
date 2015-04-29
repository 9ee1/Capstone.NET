using System.Runtime.InteropServices;

namespace Gee.External.Capstone.SystemZ {
    /// <summary>
    ///     Native SystemZ Instruction Memory Operand Value.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct NativeSystemZInstructionMemoryOperandValue {
        /// <summary>
        ///     Operand Value's Base Register.
        /// </summary>
        public byte BaseRegister;

        /// <summary>
        ///     Operand Value's Index Register.
        /// </summary>
        public byte IndexRegister;

        /// <summary>
        ///     Operand Value's Length Value.
        /// </summary>
        public ulong Length;

        /// <summary>
        ///     Operand Value's Displacement Value.
        /// </summary>
        public long Displacement;
    }
}