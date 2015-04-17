using System.Runtime.InteropServices;

namespace Gee.External.Capstone {
    /// <summary>
    ///     Native ARM Instruction Memory Operand Value.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct NativeArmInstructionMemoryOperandValue {
        /// <summary>
        ///     Operand Value's Base Register.
        /// </summary>
        public uint BaseRegister;

        /// <summary>
        ///     Operand Value's Index Register.
        /// </summary>
        public uint IndexRegister;

        /// <summary>
        ///     Operand Value's Index Register Scale.
        /// </summary>
        public int IndexRegisterScale;

        /// <summary>
        ///     Operand Value's Displacement Value.
        /// </summary>
        public int Displacement;
    }
}