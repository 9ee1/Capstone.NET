namespace Gee.External.Capstone.Arm64 {
    /// <summary>
    ///     ARM64 Instruction Detail.
    /// </summary>
    public sealed class Arm64InstructionDetail {
        /// <summary>
        ///     Get Instruction's Code Condition.
        /// </summary>
        public Arm64CodeCondition CodeCondition { get; internal set; }

        /// <summary>
        ///     Get Instruction's Operands.
        /// </summary>
        public Arm64InstructionOperand[] Operands { get; internal set; }

        /// <summary>
        ///     Get Instruction's Update Flags Flag.
        /// </summary>
        public bool UpdateFlags { get; internal set; }

        /// <summary>
        ///     Get Instruction's Write Back Flag.
        /// </summary>
        public bool WriteBack { get; internal set; }

        /// <summary>
        ///     Create an ARM64 Instruction Detail.
        /// </summary>
        internal Arm64InstructionDetail() {}
    }
}