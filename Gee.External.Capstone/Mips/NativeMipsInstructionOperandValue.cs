using System.Runtime.InteropServices;

namespace Gee.External.Capstone.Mips {
    /// <summary>
    ///     Native MIPS Instruction Operand Value.
    /// </summary>
    [StructLayout(LayoutKind.Explicit)]
    public struct NativeMipsInstructionOperandValue {
        /// <summary>
        ///     Operand Value's Register Value.
        /// </summary>
        [FieldOffset(0)] public uint Register;

        /// <summary>
        ///     Operand Value's Immediate Value.
        /// </summary>
        [FieldOffset(0)] public long Immediate;

        /// <summary>
        ///     Operand Value's Memory Value.
        /// </summary>
        [FieldOffset(0)] public NativeMipsInstructionMemoryOperandValue Memory;
    }
}