namespace Gee.External.Capstone.X86 {
    /// <summary>
    ///     X86 Instruction Operand.
    /// </summary>
    public sealed class X86InstructionOperand {
        /// <summary>
        ///     Get Operand's AVX Broadcast.
        /// </summary>
        public X86AvxBroadcast AvxBroadcast { get; internal set; }

        /// <summary>
        ///     Get Operand's AVX Zero Operation Mask Flag.
        /// </summary>
        public bool AvxZeroOperationMask { get; internal set; }

        /// <summary>
        ///     Get Operand's Floating Point Value.
        /// </summary>
        /// <value>
        ///     Retrieves the operand's floating point value if, and only if, the operand's type is
        ///     <c>X86InstructionOperandType.FloatingPoint</c>. In other words, <c>X86InstructionOperand.Type</c> is
        ///     <c>X86InstructionOperandType.FloatingPoint</c>. A null reference otherwise.
        /// </value>
        public double? FloatingPointValue { get; internal set; }

        /// <summary>
        ///     Get Operand's Immediate Value.
        /// </summary>
        /// <value>
        ///     Retrieves the operand's immediate value if, and only if, the operand's type is
        ///     <c>X86InstructionOperandType.Immediate</c>. In other words, <c>X86InstructionOperand.Type</c> is
        ///     <c>X86InstructionOperandType.Immediate</c>. A null reference otherwise.
        /// </value>
        public long? ImmediateValue { get; internal set; }

        /// <summary>
        ///     Get Operand's Memory Value.
        /// </summary>
        /// <value>
        ///     Retrieves the operand's memory value if, and only if, the operand's type is
        ///     <c>X86InstructionOperandType.Memory</c>. In other words, <c>X86InstructionOperand.Type</c> is
        ///     <c>X86InstructionOperandType.Memory</c>. A null reference otherwise.
        /// </value>
        public X86InstructionMemoryOperandValue MemoryValue { get; internal set; }

        /// <summary>
        ///     Get Operand's Register Value.
        /// </summary>
        /// <value>
        ///     Retrieves the operand's register value if, and only if, the operand's type is
        ///     <c>X86InstructionOperandType.Register</c>. In other words, <c>X86InstructionOperand.Type</c> is
        ///     <c>X86InstructionOperandType.Register</c>. A null reference otherwise.
        /// </value>
        public X86Register? RegisterValue { get; internal set; }

        /// <summary>
        ///     Get Operand's Type.
        /// </summary>
        public X86InstructionOperandType Type { get; internal set; }

        /// <summary>
        ///     Create an X86 Instruction Operand.
        /// </summary>
        internal X86InstructionOperand() {}
    }
}