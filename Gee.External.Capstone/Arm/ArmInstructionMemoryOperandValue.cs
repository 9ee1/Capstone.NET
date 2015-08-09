namespace Gee.External.Capstone.Arm {
    /// <summary>
    ///     ARM Instruction Memory Operand Value.
    /// </summary>
    public sealed class ArmInstructionMemoryOperandValue {
        /// <summary>
        ///     Get Operand Value's Base Register.
        /// </summary>
        public ArmRegister BaseRegister { get; internal set; }

        /// <summary>
        ///     Get Operand Value's Displacement Value.
        /// </summary>
        public int Displacement { get; internal set; }

        /// <summary>
        ///     Get Operand Value's Index Register.
        /// </summary>
        public ArmRegister IndexRegister { get; internal set; }

        /// <summary>
        ///     Get Operand Value's Index Register Scale.
        /// </summary>
        public int IndexRegisterScale { get; internal set; }

        /// <summary>
        ///     Create an ARM Instruction Memory Operand Value.
        /// </summary>
        internal ArmInstructionMemoryOperandValue() {}
    }
}