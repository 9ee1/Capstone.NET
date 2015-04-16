namespace Gee.External.Capstone {
    /// <summary>
    ///     X86 Instruction Memory Operand Value.
    /// </summary>
    public sealed class X86InstructionMemoryOperandValue {
        /// <summary>
        ///     Operand Value's Segment Register.
        /// </summary>
        public X86Register SegmentRegister { get; internal set; }

        /// <summary>
        ///     Operand Value's Base Register.
        /// </summary>
        public X86Register BaseRegister { get; internal set; }

        /// <summary>
        ///     Operand Value's Index Register.
        /// </summary>
        public X86Register IndexRegister { get; internal set; }

        /// <summary>
        ///     Operand Value's Index Register Scale.
        /// </summary>
        public int IndexRegisterScale { get; internal set; }

        /// <summary>
        ///     Operand Value's Displacement Value.
        /// </summary>
        public long Displacement { get; internal set; }

        /// <summary>
        ///     Create an X86 Instruction Memory Operand Value.
        /// </summary>
        internal X86InstructionMemoryOperandValue() {}
    }
}