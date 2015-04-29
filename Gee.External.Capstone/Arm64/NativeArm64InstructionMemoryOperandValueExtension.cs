namespace Gee.External.Capstone.Arm64 {
    /// <summary>
    ///     Native ARM64 Instruction Memory Operand Value Extension.
    /// </summary>
    public static class NativeArm64InstructionMemoryOperandValueExtension {
        /// <summary>
        ///     Convert a Native ARM64 Instruction Memory Operand Value to an ARM64 Instruction Memory Operand Value.
        /// </summary>
        /// <param name="this">
        ///     A native ARM64 instruction memory operand value.
        /// </param>
        /// <returns>
        ///     An ARM64 instruction memory operand value.
        /// </returns>
        public static Arm64InstructionMemoryOperandValue AsArm64InstructionMemoryOperandValue(this NativeArm64InstructionMemoryOperandValue @this) {
            var @object = new Arm64InstructionMemoryOperandValue();
            @object.BaseRegister = (Arm64Register) @this.BaseRegister;
            @object.Displacement = @this.Displacement;
            @object.IndexRegister = (Arm64Register) @this.IndexRegister;

            return @object;
        }
    }
}