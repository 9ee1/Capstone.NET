namespace Gee.External.Capstone.Arm {
    /// <summary>
    ///     Native ARM Instruction Operand Extension.
    /// </summary>
    public static class NativeArmInstructionOperandExtension {
        /// <summary>
        ///     Create an ARM Instruction Operand.
        /// </summary>
        /// <param name="this">
        ///     A native ARM instruction operand.
        /// </param>
        /// <returns>
        ///     An ARM instruction operand.
        /// </returns>
        public static ArmInstructionOperand AsArmInstructionOperand(this NativeArmInstructionOperand @this) {
            var @object = new ArmInstructionOperand();
            @object.IsSubtracted = @this.IsSubtracted;
            @object.Shifter = @this.Shifter.AsArmShifter();
            @object.Type = (ArmInstructionOperandType) @this.Type;
            @object.VectorIndex = @this.VectorIndex;

            // Set Values.
            //
            // ...
            switch (@object.Type) {
                case ArmInstructionOperandType.CImmediate:
                    @object.ImmediateValue = @this.Value.Immediate;

                    break;
                case ArmInstructionOperandType.FloatingPoint:
                    @object.FloatingPointValue = @this.Value.FloatingPoint;
                    break;
                case ArmInstructionOperandType.Immediate:
                    @object.ImmediateValue = @this.Value.Immediate;

                    break;
                case ArmInstructionOperandType.Memory:
                    @object.MemoryValue = @this.Value.Memory.AsArmInstructionMemoryOperandValue();

                    break;
                case ArmInstructionOperandType.PImmediate:
                    @object.ImmediateValue = @this.Value.Immediate;

                    break;
                case ArmInstructionOperandType.Register:
                    @object.RegisterValue = (ArmRegister) @this.Value.Register;

                    break;
                case ArmInstructionOperandType.SetEnd:
                    @object.SetEndValue = (ArmSetEndInstructionOperandType) @this.Value.SetEnd;

                    break;
                case ArmInstructionOperandType.SysRegister:
                    @object.SysRegisterValue = (ArmSysRegister) @this.Value.Register;

                    break;
            }

            return @object;
        }
    }
}