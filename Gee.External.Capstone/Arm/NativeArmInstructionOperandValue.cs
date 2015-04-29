using System.Runtime.InteropServices;

namespace Gee.External.Capstone.Arm {
    /// <summary>
    ///     Native ARM Instruction Operand Value.
    /// </summary>
    [StructLayout(LayoutKind.Explicit)]
    public struct NativeArmInstructionOperandValue {
        /// <summary>
        ///     Operand Value's Register Value.
        /// </summary>
        [FieldOffset(0)] public uint Register;

        /// <summary>
        ///     Operand Value's Immediate Value.
        /// </summary>
        [FieldOffset(0)] public int Immediate;

        /// <summary>
        ///     Operand Value's Floating Point Value.
        /// </summary>
        [FieldOffset(0)] public double FloatingPoint;

        /// <summary>
        ///     Operand Value's Memory Value.
        /// </summary>
        [FieldOffset(0)] public NativeArmInstructionMemoryOperandValue Memory;

        /// <summary>
        ///     Operand Value's SETEND Instruction Operand Type Value.
        /// </summary>
        [FieldOffset(0)] public int SetEnd;
    }
}