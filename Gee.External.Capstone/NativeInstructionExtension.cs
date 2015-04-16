namespace Gee.External.Capstone {
    /// <summary>
    ///     Native Instruction Extension.
    /// </summary>
    public static class NativeInstructionExtension {
        /// <summary>
        ///     Convert a Native Instruction to a Dissembled Instruction.
        /// </summary>
        /// <param name="this">
        ///     A native instruction.
        /// </param>
        /// <returns>
        ///     A dissembled instruction.
        /// </returns>
        public static Instruction<TArchitectureInstruction, TArchitectureRegister, TArchitectureGroup, TArchitectureDetail> AsInstruction<TArchitectureInstruction, TArchitectureRegister, TArchitectureGroup, TArchitectureDetail>(this NativeInstruction @this) {
            var @object = new Instruction<TArchitectureInstruction, TArchitectureRegister, TArchitectureGroup, TArchitectureDetail>();
            @object.Address = (long) @this.Address;
            @object.Bytes = @this.ManagedBytes;
            @object.Mnemonic = @this.ManagedMnemonic;
            @object.Operand = @this.ManagedOperand;

            return @object;
        }

        /// <summary>
        ///     Convert a Native Instruction to an X86 Dissembled Instruction.
        /// </summary>
        /// <param name="this">
        ///     A native instruction.
        /// </param>
        /// <returns>
        ///     A dissembled instruction.
        /// </returns>
        public static Instruction<X86Instruction, X86Register, X86InstructionGroup, X86InstructionDetail> AsX86Instruction(this NativeInstruction @this) {
            var @object = @this.AsInstruction<X86Instruction, X86Register, X86InstructionGroup, X86InstructionDetail>();
            @object.Id = (X86Instruction) @this.Id;

            return @object;
        }
    }
}