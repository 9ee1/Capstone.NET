using System.Runtime.InteropServices;

namespace Gee.External.Capstone {
    /// <summary>
    ///     Native ARM64 Instruction Operand Shift.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct NativeArm64InstructionOperandShift {
        /// <summary>
        ///     Operand's Shift Type.
        /// </summary>
        public int Type;

        /// <summary>
        ///     Operand's Shift Value.
        /// </summary>
        public uint Value;
    }
}