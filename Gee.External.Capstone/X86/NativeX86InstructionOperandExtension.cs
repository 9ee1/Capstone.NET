namespace Gee.External.Capstone.X86 {
    /// <summary>
    ///     Native X86 Instruction Operand Extension.
    /// </summary>
    public static class NativeX86InstructionOperandExtension {
        /// <summary>
        ///     Convert a Native X86 Instruction Operand to an X86 Instruction Operand.
        /// </summary>
        /// <param name="this">
        ///     A native X86 instruction operand.
        /// </param>
        /// <returns>
        ///     An X86 instruction operand.
        /// </returns>
        public static X86InstructionOperand AsX86InstructionOperand(this NativeX86InstructionOperand @this) {
            var @object = new X86InstructionOperand();
            @object.AvxBroadcast = @this.ManagedAvxBroadcast;
            @object.AvxZeroOperationMask = @this.AvxZeroOperationMask;
            @object.Type = @this.ManagedType;
            switch (@object.Type) {
                case X86InstructionOperandType.FloatingPoint:
                    @object.FloatingPointValue = @this.Value.FloatingPoint;
                    @object.ImmediateValue = null;
                    @object.MemoryValue = null;
                    @object.RegisterValue = null;

                    break;
                case X86InstructionOperandType.Immediate:
                    @object.FloatingPointValue = null;
                    @object.ImmediateValue = @this.Value.Immediate;
                    @object.MemoryValue = null;
                    @object.RegisterValue = null;

                    break;
                case X86InstructionOperandType.Memory:
                    @object.FloatingPointValue = null;
                    @object.ImmediateValue = null;
                    @object.MemoryValue = @this.Value.Memory.AsX86InstructionMemoryOperandValue();
                    @object.RegisterValue = null;

                    break;
                case X86InstructionOperandType.Register:
                    @object.FloatingPointValue = null;
                    @object.ImmediateValue = null;
                    @object.MemoryValue = null;
                    @object.RegisterValue = (X86Register) @this.Value.Register;

                    break;
            }

            return @object;
        }
    }
}