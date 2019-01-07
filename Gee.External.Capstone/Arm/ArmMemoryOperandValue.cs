namespace Gee.External.Capstone.Arm {
    /// <summary>
    ///     ARM Memory Operand Value.
    /// </summary>
    public sealed class ArmMemoryOperandValue {
        /// <summary>
        ///     Get Base Register.
        /// </summary>
        public ArmRegister Base { get; }

        /// <summary>
        ///     Get Displacement Value.
        /// </summary>
        public int Displacement { get; }

        /// <summary>
        ///     Get Index Register.
        /// </summary>
        public ArmRegister Index { get; }

        /// <summary>
        ///     Get Index Register's Left Shift Value.
        /// </summary>
        public int LeftShit { get; }

        /// <summary>
        ///     Get Index Register's Scale.
        /// </summary>
        public int Scale { get; }

        /// <summary>
        ///     Create an ARM Memory Operand Value.
        /// </summary>
        /// <param name="disassembler">
        ///     A disassembler.
        /// </param>
        /// <param name="nativeMemoryOperandValue">
        ///     A native ARM memory operand value.
        /// </param>
        /// <returns>
        ///     An ARM memory operand value.
        /// </returns>
        internal static ArmMemoryOperandValue Create(CapstoneDisassembler disassembler, ref NativeArmMemoryOperandValue nativeMemoryOperandValue) {
            return new ArmMemoryOperandValueBuilder().Build(disassembler, ref nativeMemoryOperandValue).Create();
        }

        /// <summary>
        ///     Create an ARM Memory Operand Value.
        /// </summary>
        /// <param name="builder">
        ///     A builder to initialize the object with.
        /// </param>
        internal ArmMemoryOperandValue(ArmMemoryOperandValueBuilder builder) {
            this.Base = builder.Base;
            this.Displacement = builder.Displacement;
            this.Index = builder.Index;
            this.LeftShit = builder.LeftShit;
            this.Scale = builder.Scale;
        }
    }
}