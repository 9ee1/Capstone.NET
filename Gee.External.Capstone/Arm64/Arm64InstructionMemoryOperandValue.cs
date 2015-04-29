namespace Gee.External.Capstone.Arm64 {
    /// <summary>
    ///     ARM64 Instruction Memory Operand Value.
    /// </summary>
    public sealed class Arm64InstructionMemoryOperandValue {
        /// <summary>
        ///     Get Operand Value's Base Register.
        /// </summary>
        public Arm64Register BaseRegister { get; internal set; }

        /// <summary>
        ///     Get Operand Value's Index Register.
        /// </summary>
        public Arm64Register IndexRegister { get; internal set; }

        /// <summary>
        ///     Get Operand Value's Displacement Value.
        /// </summary>
        public int Displacement { get; internal set; }

        /// <summary>
        ///     Create an ARM64 Instruction Memory Operand Value.
        /// </summary>
        internal Arm64InstructionMemoryOperandValue() {}
    }
}