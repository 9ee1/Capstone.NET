﻿namespace Gee.External.Capstone.X86 {
    /// <summary>
    ///     X86 Instruction Operand Type.
    /// </summary>
    public enum X86InstructionOperandType {
        /// <summary>
        ///     Invalid Operand Type.
        /// </summary>
        Invalid = 0,

        Register,
        Immediate,
        Memory,
        FloatingPoint
    }
}