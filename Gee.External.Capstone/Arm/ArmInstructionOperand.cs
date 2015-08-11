namespace Gee.External.Capstone.Arm {
    /// <summary>
    ///     ARM Instruction Operand.
    /// </summary>
    public sealed class ArmInstructionOperand {
        /// <summary>
        ///     Get Operand's Floating Point Value.
        /// </summary>
        /// <value>
        ///     Retrieves the operand's floating point value if, and only if, the operand's type is
        ///     <c>ArmInstructionOperandType.FloatingPoint</c>. A null reference otherwise.
        /// </value>
        public double? FloatingPointValue { get; internal set; }

        /// <summary>
        ///     Get Operand's Immediate Value.
        /// </summary>
        /// <value>
        ///     Retrieves the operand's immediate value if, and only if, the operand's type is either
        ///     <c>ArmInstructionOperandType.CImmediate</c>, <c>ArmInstructionOperandType.Immediate</c>, or
        ///     <c>ArmInstructionOperandType.PImmediate</c>. A null reference otherwise.
        /// </value>
        public int? ImmediateValue { get; internal set; }

        /// <summary>
        ///     Get Operand's Subtracted Flag.
        /// </summary>
        public bool IsSubtracted { get; internal set; }

        /// <summary>
        ///     Get Operand's Immediate Value.
        /// </summary>
        /// <value>
        ///     Retrieves the operand's immediate value if, and only if, the operand's type is
        ///     <c>ArmInstructionOperandType.Memory</c>. A null reference otherwise.
        /// </value>
        public ArmInstructionMemoryOperandValue MemoryValue { get; internal set; }

        /// <summary>
        ///     Get Operand's Register Value.
        /// </summary>
        /// <value>
        ///     Retrieves the operand's register value if, and only if, the operand's type is
        ///     <c>ArmInstructionOperandType.Register</c>. A null reference otherwise.
        /// </value>
        public ArmRegister? RegisterValue { get; internal set; }

        /// <summary>
        ///     Get Operand's SetEnd Value.
        /// </summary>
        /// <value>
        ///     Retrieves the operand's register value if, and only if, the operand's type is
        ///     <c>ArmInstructionOperandType.SetEnd</c>. A null reference otherwise.
        /// </value>
        public ArmSetEndInstructionOperandType? SetEndValue { get; internal set; }

        /// <summary>
        ///     Get Operand's Shifter.
        /// </summary>
        public ArmShifter Shifter { get; internal set; }

        /// <summary>
        ///     Get Operand's SYS Register Value.
        /// </summary>
        /// <value>
        ///     Retrieves the operand's SYS register value if, and only if, the operand's type is
        ///     <c>ArmInstructionOperandType.SysRegister</c>. A null reference otherwise.
        /// </value>
        public ArmSysRegister? SysRegisterValue { get; internal set; }

        /// <summary>
        ///     Get Operand's Type.
        /// </summary>
        public ArmInstructionOperandType Type { get; internal set; }

        /// <summary>
        ///     Get Operand's Vector Index.
        /// </summary>
        public int VectorIndex { get; internal set; }

        /// <summary>
        ///     Create an ARM Instruction Operand.
        /// </summary>
        internal ArmInstructionOperand() {}
    }
}