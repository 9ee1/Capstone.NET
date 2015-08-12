namespace Gee.External.Capstone.Arm64 {
    /// <summary>
    ///     ARM64 Instruction Operand.
    /// </summary>
    public sealed class Arm64InstructionOperand {
        /// <summary>
        ///     Get Operand's AT Instruction Operation.
        /// </summary>
        /// <value>
        ///     Retrieves the operand's AT instruction operation if, and only if, the operand's type is
        ///     <c>Arm64InstructionOperandType.SysOperation</c> and the instruction the operand applies to is
        ///     <c>Arm64Instruction.AT</c>. A null reference otherwise.
        /// </value>
        public Arm64AtInstructionOperation? AtInstructionOperation { get; internal set; }

        /// <summary>
        ///     Get Operand's DC Instruction Operation.
        /// </summary>
        /// <value>
        ///     Retrieves the operand's DC instruction operation if, and only if, the operand's type is
        ///     <c>Arm64InstructionOperandType.SysOperation</c> and the instruction the operand applies to is
        ///     <c>Arm64Instruction.DC</c>. A null reference otherwise.
        /// </value>
        public Arm64DcInstructionOperation? DcInstructionOperation { get; internal set; }

        /// <summary>
        ///     Get Operand's Extender.
        /// </summary>
        public Arm64Extender Extender { get; internal set; }

        /// <summary>
        ///     Get Operand's Floating Point Value.
        /// </summary>
        /// <value>
        ///     Retrieves the operand's floating point value if, and only if, the operand's type is
        ///     <c>Arm64InstructionOperandType.FloatingPoint</c>. In other words, <c>Arm64InstructionOperand.Type</c>
        ///     is <c>Arm64InstructionOperandType.FloatingPoint</c>. A null reference otherwise.
        /// </value>
        public double? FloatingPointValue { get; internal set; }

        /// <summary>
        ///     Get Operand's IC Instruction Operation.
        /// </summary>
        /// <value>
        ///     Retrieves the operand's IC instruction operation if, and only if, the operand's type is
        ///     <c>Arm64InstructionOperandType.SysOperation</c> and the instruction the operand applies to is
        ///     <c>Arm64Instruction.IC</c>. A null reference otherwise.
        /// </value>
        public Arm64IcInstructionOperation? IcInstructionOperation { get; internal set; }

        /// <summary>
        ///     Get Operand's Immediate Value.
        /// </summary>
        /// <value>
        ///     Retrieves the operand's immediate value if, and only if, the operand's type is
        ///     <c>Arm64InstructionOperandType.Immediate</c>. In other words, <c>Arm64InstructionOperand.Type</c> is
        ///     <c>Arm64InstructionOperandType.Immediate</c>. A null reference otherwise.
        /// </value>
        public long? ImmediateValue { get; internal set; }

        /// <summary>
        ///     Get Operand's Memory Barrier Operation.
        /// </summary>
        /// <value>
        ///     Retrieves the operand's immediate value if, and only if, the operand's type is
        ///     <c>Arm64InstructionOperandType.MemoryBarrierOperation</c>. In other words,
        ///     <c>Arm64InstructionOperand.Type</c> is <c>Arm64InstructionOperandType.MemoryBarrierOperation</c>. A
        ///     null reference otherwise.
        /// </value>
        public Arm64MemoryBarrierOperation? MemoryBarrierOperation { get; internal set; }

        /// <summary>
        ///     Get Operand's Immediate Value.
        /// </summary>
        /// <value>
        ///     Retrieves the operand's immediate value if, and only if, the operand's type is
        ///     <c>Arm64InstructionOperandType.Memory</c>. In other words, <c>Arm64InstructionOperand.Type</c> is
        ///     <c>Arm64InstructionOperandType.Memory</c>. A null reference otherwise.
        /// </value>
        public Arm64InstructionMemoryOperandValue MemoryValue { get; internal set; }

        /// <summary>
        ///     Get Operand's MRS Register Value.
        /// </summary>
        /// <value>
        ///     Retrieves the operand's MRS register value if, and only if, the operand's type is
        ///     <c>Arm64InstructionOperandType.MrsRegister</c>. In other words, <c>Arm64InstructionOperand.Type</c> is
        ///     <c>Arm64InstructionOperandType.MrsRegister</c>. A null reference otherwise.
        /// </value>
        public Arm64MrsRegister? MrsRegisterValue { get; internal set; }

        /// <summary>
        ///     Get Operand's MSR Register Value.
        /// </summary>
        /// <value>
        ///     Retrieves the operand's MRS register value if, and only if, the operand's type is
        ///     <c>Arm64InstructionOperandType.MsrRegister</c>. In other words, <c>Arm64InstructionOperand.Type</c> is
        ///     <c>Arm64InstructionOperandType.MsrRegister</c>. A null reference otherwise.
        /// </value>
        public Arm64MsrRegister? MsrRegisterValue { get; internal set; }

        /// <summary>
        ///     Get Operand's PState.
        /// </summary>
        /// <value>
        ///     Retrieves the operand's immediate value if, and only if, the operand's type is
        ///     <c>Arm64InstructionOperandType.PrefetchOperation</c>. In other words,
        ///     <c>Arm64InstructionOperand.Type</c> is <c>Arm64InstructionOperandType.PrefetchOperation</c>. A null
        ///     reference otherwise.
        /// </value>
        public Arm64PrefetchOperation? PrefetchOperation { get; internal set; }

        /// <summary>
        ///     Get Operand's PState.
        /// </summary>
        /// <value>
        ///     Retrieves the operand's pstate if, and only if, the operand's type is
        ///     <c>Arm64InstructionOperandType.PState</c>. In other words, <c>Arm64InstructionOperand.Type</c> is
        ///     <c>Arm64InstructionOperandType.PState</c>. A null reference otherwise.
        /// </value>
        public Arm64PState? PState { get; internal set; }

        /// <summary>
        ///     Get Operand's Register Value.
        /// </summary>
        /// <value>
        ///     Retrieves the operand's register value if, and only if, the operand's type is
        ///     <c>Arm64InstructionOperandType.Register</c>. In other words, <c>Arm64InstructionOperand.Type</c> is
        ///     <c>Arm64InstructionOperandType.Register</c>. A null reference otherwise.
        /// </value>
        public Arm64Register? RegisterValue { get; internal set; }

        /// <summary>
        ///     Get Operand's Shifter.
        /// </summary>
        public Arm64Shifter Shifter { get; internal set; }

        /// <summary>
        ///     Get Operand's TLBI Instruction Operation.
        /// </summary>
        /// <value>
        ///     Retrieves the operand's TLBI instruction operation if, and only if, the operand's type is
        ///     <c>Arm64InstructionOperandType.SysOperation</c> and the instruction the operand applies to is
        ///     <c>Arm64Instruction.TLBI</c>. A null reference otherwise.
        /// </value>
        public Arm64TlbiInstructionOperation? TlbiInstructionOperation { get; internal set; }

        /// <summary>
        ///     Get Operand's Type.
        /// </summary>
        public Arm64InstructionOperandType Type { get; internal set; }

        /// <summary>
        ///     Operand's Vector Arrangement Specifier.
        /// </summary>
        public Arm64VectorArrangementSpecifier VectorArrangementSpecifier { get; internal set; }

        /// <summary>
        ///     Get Operand's Vector Element Size Specifier.
        /// </summary>
        public Arm64VectorElementSizeSpecifier VectorElementSizeSpecifier { get; internal set; }

        /// <summary>
        ///     Get Operand's Vector Index.
        /// </summary>
        public int VectorIndex { get; internal set; }

        /// <summary>
        ///     Create an ARM64 Instruction Operand.
        /// </summary>
        internal Arm64InstructionOperand() {}
    }
}