namespace Gee.External.Capstone {
    /// <summary>
    ///     Dissembled Instruction.
    /// </summary>
    public sealed class Instruction<TArchitectureInstruction, TArchitectureRegister, TArchitectureGroup, TArchitectureDetail> {
        /// <summary>
        ///     Get Instruction's Address (EIP).
        /// </summary>
        public long Address { get; internal set; }

        /// <summary>
        ///     Get Instruction's Architecture Dependent Detail.
        /// </summary>
        public TArchitectureDetail ArchitectureDetail { get; internal set; }

        /// <summary>
        ///     Get Instruction's Machine Bytes.
        /// </summary>
        public byte[] Bytes { get; internal set; }

        /// <summary>
        ///     Get Instruction's Unique Identifier.
        /// </summary>
        public TArchitectureInstruction Id { get; internal set; }

        /// <summary>
        ///     Get Instruction's Architecture Independent Detail.
        /// </summary>
        public IndependentInstructionDetail<TArchitectureRegister, TArchitectureGroup> IndependentDetail { get; internal set; }

        /// <summary>
        ///     Get Instruction's Mnemonic Text.
        /// </summary>
        public string Mnemonic { get; internal set; }

        /// <summary>
        ///     Get Instruction's Operand Text.
        /// </summary>
        public string Operand { get; internal set; }

        /// <summary>
        ///     Create a Dissembled Instruction.
        /// </summary>
        internal Instruction() {}
    }
}