namespace Gee.External.Capstone {
    /// <summary>
    ///     Architecture Independent Instruction Detail.
    /// </summary>
    public sealed class IndependentInstructionDetail<TArchitectureRegister, TArchitectureGroup> {
        /// <summary>
        ///     Get Implicit Registers Read by an Instruction.
        /// </summary>
        public TArchitectureRegister[] ReadRegisters { get; internal set; }

        /// <summary>
        ///     Get Implicit Registers Written by an Instruction.
        /// </summary>
        public TArchitectureRegister[] WrittenRegisters { get; internal set; }

        /// <summary>
        ///     Get Groups an Instruction Belongs to.
        /// </summary>
        public TArchitectureGroup[] Groups { get; internal set; }

        /// <summary>
        ///     Create an X86 Independent Architecture Instruction Detail.
        /// </summary>
        internal IndependentInstructionDetail() {}
    }
}