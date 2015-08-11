﻿using System.Runtime.InteropServices;

namespace Gee.External.Capstone.X86 {
    /// <summary>
    ///     Native X86 Instruction Memory Operand Value.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct NativeX86InstructionMemoryOperandValue {
        /// <summary>
        ///     Operand Value's Segment Register.
        /// </summary>
        public uint SegmentRegister;

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
        public long Displacement;
    }
}