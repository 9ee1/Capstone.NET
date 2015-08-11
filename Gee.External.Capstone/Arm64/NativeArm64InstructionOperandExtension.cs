namespace Gee.External.Capstone.Arm64 {
    /// <summary>
    ///     Native ARM64 Instruction Operand Extension.
    /// </summary>
    public static class NativeArm64InstructionOperandExtension {
        /// <summary>
        ///     Convert a Native ARM64 Instruction Operand to an ARM64 Instruction Operand.
        /// </summary>
        /// <param name="this">
        ///     A native ARM64 instruction operand.
        /// </param>
        /// <param name="instruction">
        ///     The instruction the operand belongs to.
        /// </param>
        /// <returns>
        ///     An ARM64 instruction operand.
        /// </returns>
        public static Arm64InstructionOperand AsArm64InstructionOperand(this NativeArm64InstructionOperand @this, Arm64Instruction instruction) {
            var @object = new Arm64InstructionOperand();
            @object.Extender = @this.ManagedExtender;
            @object.Shifter = @this.Shifter.AsArm64Shifter();
            @object.Type = @this.ManagedType;
            @object.VectorArrangementSpecifier = @this.ManagedVectorArrangementSpecifier;
            @object.VectorElementSizeSpecifier = @this.ManagedVectorElementSizeSpecifier;
            @object.VectorIndex = @this.VectorIndex;
            switch (@object.Type) {
                case Arm64InstructionOperandType.CImmediate:
                    @object.ImmediateValue = @this.Value.Immediate;

                    break;
                case Arm64InstructionOperandType.FloatingPoint:
                    @object.FloatingPointValue = @this.Value.FloatingPoint;
                    break;
                case Arm64InstructionOperandType.Immediate:
                    @object.ImmediateValue = @this.Value.Immediate;

                    break;
                case Arm64InstructionOperandType.MemoryBarrierOperation:
                    @object.MemoryBarrierOperation = @this.Value.ManagedMemoryBarrierOperation;

                    break;
                case Arm64InstructionOperandType.Memory:
                    @object.MemoryValue = @this.Value.Memory.AsArm64InstructionMemoryOperandValue();

                    break;
                case Arm64InstructionOperandType.MrsRegister:
                    @object.MrsRegisterValue = (Arm64MrsRegister) @this.Value.Register;

                    break;
                case Arm64InstructionOperandType.MsrRegister:
                    @object.MsrRegisterValue = (Arm64MsrRegister) @this.Value.Register;

                    break;
                case Arm64InstructionOperandType.PState:
                    @object.PState = @this.Value.ManagedPState;

                    break;
                case Arm64InstructionOperandType.PrefetchOperation:
                    @object.PrefetchOperation = @this.Value.ManagedPrefetchOperation;

                    break;
                case Arm64InstructionOperandType.Register:
                    @object.RegisterValue = @this.Value.ManagedRegister;

                    break;
                case Arm64InstructionOperandType.SysOperation:
                    switch (instruction) {
                        case Arm64Instruction.AT:
                            @object.AtInstructionOperation = (Arm64AtInstructionOperation) @this.Value.SysOperation;

                            break;
                        case Arm64Instruction.DC:
                            @object.DcInstructionOperation = (Arm64DcInstructionOperation) @this.Value.SysOperation;

                            break;
                        case Arm64Instruction.IC:
                            @object.IcInstructionOperation = (Arm64IcInstructionOperation) @this.Value.SysOperation;

                            break;
                        case Arm64Instruction.TLBI:
                            @object.TlbiInstructionOperation = (Arm64TlbiInstructionOperation) @this.Value.SysOperation;

                            break;
                    }

                    break;
            }

            return @object;
        }
    }
}