using System.Runtime.InteropServices;

namespace Gee.External.Capstone {
    /// <summary>
    ///     Native ARM64 Instruction Memory Operand Value.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct NativeArm64InstructionMemoryOperandValue {
        /// <summary>
        ///     Operand Value's Base Register.
        /// </summary>
        public uint BaseRegister;

        /// <summary>
        ///     Operand Value's Index Register.
        /// </summary>
        public uint IndexRegister;

        /// <summary>
        ///     Operand Value's Displacement Value.
        /// </summary>
        public int Displacement;
    }
}