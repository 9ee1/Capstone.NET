namespace Gee.External.Capstone.Arm64 {
    /// <summary>
    ///     ARM64 Memory Operand Value.
    /// </summary>
    public sealed class Arm64MemoryOperandValue {
        /// <summary>
        ///     Get Base Register.
        /// </summary>
        public Arm64Register Base { get; }

        /// <summary>
        ///     Get Displacement Value.
        /// </summary>
        public int Displacement { get; }

        /// <summary>
        ///     Get Index Register.
        /// </summary>
        public Arm64Register Index { get; }

        /// <summary>
        ///     Create an ARM64 Memory Operand Value.
        /// </summary>
        /// <param name="disassembler">
        ///     A disassembler.
        /// </param>
        /// <param name="nativeMemoryOperandValue">
        ///     A native ARM64 memory operand value.
        /// </param>
        /// <returns>
        ///     An ARM64 memory operand value.
        /// </returns>
        internal static Arm64MemoryOperandValue Create(CapstoneDisassembler disassembler, ref NativeArm64MemoryOperandValue nativeMemoryOperandValue) {
            return new Arm64MemoryOperandValueBuilder().Build(disassembler, ref nativeMemoryOperandValue).Create();
        }

        /// <summary>
        ///     Create an ARM64 Memory Operand Value.
        /// </summary>
        /// <param name="builder">
        ///     A builder to initialize the object with.
        /// </param>
        internal Arm64MemoryOperandValue(Arm64MemoryOperandValueBuilder builder) {
            this.Base = builder.Base;
            this.Displacement = builder.Displacement;
            this.Index = builder.Index;
        }
    }
}