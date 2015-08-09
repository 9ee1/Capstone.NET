namespace Gee.External.Capstone.X86 {
    /// <summary>
    ///     X86 Instruction Detail.
    /// </summary>
    public sealed class X86InstructionDetail {
        /// <summary>
        ///     Get Instruction's Prefix.
        /// </summary>
        public X86Prefix[] Prefix { get; internal set; }

        /// <summary>
        ///     Get Instruction's Operation Code.
        /// </summary>
        public byte[] OperationCode { get; internal set; }

        /// <summary>
        ///     Get Instruction's REX Prefix.
        /// </summary>
        public byte Rex { get; internal set; }

        /// <summary>
        ///     Get Instruction's Address Size.
        /// </summary>
        public byte AddressSize { get; internal set; }

        /// <summary>
        ///     Get Instruction's ModR/M Byte.
        /// </summary>
        public byte ModRm { get; internal set; }

        /// <summary>
        ///     Get Instruction's SIB Value.
        /// </summary>
        public byte Sib { get; internal set; }

        /// <summary>
        ///     Get Instruction's Displacement Value.
        /// </summary>
        public int Displacement { get; internal set; }

        /// <summary>
        ///     Get Instruction's SIB Index Register.
        /// </summary>
        public X86Register SibIndexRegister { get; internal set; }

        /// <summary>
        ///     Instruction's SIB Scale.
        /// </summary>
        public byte SibScale { get; internal set; }

        /// <summary>
        ///     Get Instruction's SIB Base Register.
        /// </summary>
        public X86Register SibBaseRegister { get; internal set; }

        /// <summary>
        ///     Get Instruction's SSE Code Condition.
        /// </summary>
        public X86SSECodeCondition SseCodeCondition { get; internal set; }

        /// <summary>
        ///     Get Instruction's Managed AVX Code Condition.
        /// </summary>
        public X86AvxCodeCondition AvxCodeCondition { get; internal set; }

        /// <summary>
        ///     Instruction's Suppress All AVX Exceptions Flag.
        /// </summary>
        public bool SuppressAllAvxExceptions { get; internal set; }

        /// <summary>
        ///     Get Instruction's Managed AVX Rounding Mode.
        /// </summary>
        public X86AvxRoundingMode AvxRoundingMode { get; internal set; }

        public X86InstructionOperand[] Operands { get; internal set; }

        /// <summary>
        ///     Create an X86 Instruction Detail.
        /// </summary>
        internal X86InstructionDetail() {}
    }
}