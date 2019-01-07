namespace Gee.External.Capstone.X86 {
    /// <summary>
    ///     X86 Memory Operand Value.
    /// </summary>
    public sealed class X86MemoryOperandValue {
        /// <summary>
        ///     Get Base Register.
        /// </summary>
        public X86Register Base { get; }

        /// <summary>
        ///     Get Displacement Value.
        /// </summary>
        public long Displacement { get; }

        /// <summary>
        ///     Get Index Register.
        /// </summary>
        public X86Register Index { get; }

        /// <summary>
        ///     Get Index Register's Scale.
        /// </summary>
        public int Scale { get; }

        /// <summary>
        ///     Get Segment Register.
        /// </summary>
        public X86Register Segment { get; }

        /// <summary>
        ///     Create an X86 Memory Operand Value.
        /// </summary>
        /// <param name="disassembler">
        ///     A disassembler.
        /// </param>
        /// <param name="nativeMemoryOperandValue">
        ///     A native X86 memory operand value.
        /// </param>
        /// <returns>
        ///     An X86 memory operand value.
        /// </returns>
        internal static X86MemoryOperandValue Create(CapstoneDisassembler disassembler, ref NativeX86MemoryOperandValue nativeMemoryOperandValue) {
            return new X86MemoryOperandValueBuilder().Build(disassembler, ref nativeMemoryOperandValue).Create();
        }

        /// <summary>
        ///     Create an X86 Memory Operand Value.
        /// </summary>
        /// <param name="builder">
        ///     A builder to initialize the object with.
        /// </param>
        internal X86MemoryOperandValue(X86MemoryOperandValueBuilder builder) {
            this.Base = builder.Base;
            this.Displacement = builder.Displacement;
            this.Index = builder.Index;
            this.Scale = builder.Scale;
            this.Segment = builder.Segment;
        }
    }
}