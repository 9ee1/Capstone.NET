namespace Gee.External.Capstone {
    /// <summary>
    ///     Native X86 Instruction Memory Operand Value Extension.
    /// </summary>
    public static class NativeX86InstructionMemoryOperandValueExtension {
        /// <summary>
        ///     Convert a Native X86 Instruction Memory Operand Value to an X86 Instruction Memory Operand Value.
        /// </summary>
        /// <param name="this">
        ///     A native X86 instruction memory operand value.
        /// </param>
        /// <returns>
        ///     An X86 instruction memory operand value.
        /// </returns>
        public static X86InstructionMemoryOperandValue AsX86InstructionMemoryOperandValue(this NativeX86InstructionMemoryOperandValue @this) {
            var @object = new X86InstructionMemoryOperandValue();
            @object.BaseRegister = (X86Register) @this.BaseRegister;
            @object.Displacement = @this.Displacement;
            @object.IndexRegister = (X86Register) @this.IndexRegister;
            @object.IndexRegisterScale = @this.IndexRegisterScale;
            @object.SegmentRegister = (X86Register) @this.SegmentRegister;

            return @object;
        }
    }
}