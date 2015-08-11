namespace Gee.External.Capstone.Arm {
    /// <summary>
    ///     Native ARM Instruction Memory Operand Value Extension.
    /// </summary>
    public static class NativeArmInstructionMemoryOperandValueExtension {
        /// <summary>
        ///     Create an ARM Instruction Memory Operand Value.
        /// </summary>
        /// <param name="this">
        ///     A native ARM instruction memory operand value.
        /// </param>
        /// <returns>
        ///     An ARM instruction memory operand value.
        /// </returns>
        public static ArmInstructionMemoryOperandValue AsArmInstructionMemoryOperandValue(this NativeArmInstructionMemoryOperandValue @this) {
            var @object = new ArmInstructionMemoryOperandValue();
            @object.BaseRegister = (ArmRegister) @this.BaseRegister;
            @object.Displacement = @this.Displacement;
            @object.IndexRegister = (ArmRegister) @this.IndexRegister;
            @object.IndexRegisterScale = @this.IndexRegisterScale;

            return @object;
        }
    }
}