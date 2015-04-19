using System.Runtime.InteropServices;

namespace Gee.External.Capstone {
    /// <summary>
    ///     Native ARM64 Instruction Operand Value.
    /// </summary>
    [StructLayout(LayoutKind.Explicit)]
    public struct NativeArm64InstructionOperandValue {
        /// <summary>
        ///     Operand Value's Register Value.
        /// </summary>
        [FieldOffset(0)] public uint Register;

        /// <summary>
        ///     Operand Value's Immediate Value.
        /// </summary>
        [FieldOffset(0)] public long Immediate;

        /// <summary>
        ///     Operand Value's Floating Point Value.
        /// </summary>
        [FieldOffset(0)] public double FloatingPoint;

        /// <summary>
        ///     Operand Value's Memory Value.
        /// </summary>
        [FieldOffset(0)] public NativeArm64InstructionMemoryOperandValue Memory;

        /// <summary>
        ///     Operand Value's PState Value.
        /// </summary>
        [FieldOffset(0)] public int PState;

        /// <summary>
        ///     Operand Value's System Value.
        /// </summary>
        [FieldOffset(0)] public uint System;

        /// <summary>
        ///     Operand Value's Prefetch Value.
        /// </summary>
        [FieldOffset(0)] public int Prefetch;

        /// <summary>
        ///     Operand Value's Memory Barrier Value.
        /// </summary>
        [FieldOffset(0)] public int MemoryBarrier;
    }
}