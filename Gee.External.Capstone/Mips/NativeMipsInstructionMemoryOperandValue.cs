using System.Runtime.InteropServices;

namespace Gee.External.Capstone.Mips {
    /// <summary>
    ///     Native MIPS Instruction Memory Operand Value.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct NativeMipsInstructionMemoryOperandValue {
        /// <summary>
        ///     Operand Value's Base Register.
        /// </summary>
        public uint BaseRegister;

        /// <summary>
        ///     Operand Value's Displacement Value.
        /// </summary>
        public long Displacement;
    }
}