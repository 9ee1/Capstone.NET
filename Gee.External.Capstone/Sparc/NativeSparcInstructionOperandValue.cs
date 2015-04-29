using System.Runtime.InteropServices;

namespace Gee.External.Capstone.Sparc {
    /// <summary>
    ///     Native ARM64 Instruction Operand Value.
    /// </summary>
    [StructLayout(LayoutKind.Explicit)]
    public struct NativeSparcInstructionOperandValue {
        /// <summary>
        ///     Operand Value's Register Value.
        /// </summary>
        [FieldOffset(0)] public uint Register;

        /// <summary>
        ///     Operand Value's Immediate Value.
        /// </summary>
        [FieldOffset(0)] public int Immediate;

        /// <summary>
        ///     Operand Value's Memory Value.
        /// </summary>
        [FieldOffset(0)] public NativeSparcInstructionMemoryOperandValue Memory;
    }
}