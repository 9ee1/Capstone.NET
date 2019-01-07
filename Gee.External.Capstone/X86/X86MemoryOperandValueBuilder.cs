namespace Gee.External.Capstone.X86 {
    /// <summary>
    ///     X86 Memory Operand Value Builder.
    /// </summary>
    internal sealed class X86MemoryOperandValueBuilder {
        /// <summary>
        ///     Get and Set Base Register.
        /// </summary>
        internal X86Register Base { get; private set; }

        /// <summary>
        ///     Get and Set Displacement Value.
        /// </summary>
        internal long Displacement { get; private set; }

        /// <summary>
        ///     Get and Set Index Register.
        /// </summary>
        internal X86Register Index { get; private set; }

        /// <summary>
        ///     Get and Set Index Register's Scale.
        /// </summary>
        internal int Scale { get; private set; }

        /// <summary>
        ///     Get and Set Segment Register.
        /// </summary>
        internal X86Register Segment { get; private set; }

        /// <summary>
        ///     Build an X86 Memory Operand Value Builder.
        /// </summary>
        /// <param name="disassembler">
        ///     A disassembler.
        /// </param>
        /// <param name="nativeMemoryOperandValue">
        ///     A native X86 memory operand value.
        /// </param>
        /// <returns>
        ///     This builder.
        /// </returns>
        internal X86MemoryOperandValueBuilder Build(CapstoneDisassembler disassembler, ref NativeX86MemoryOperandValue nativeMemoryOperandValue) {
            this.Base = X86Register.TryCreate(disassembler, nativeMemoryOperandValue.Base);
            this.Displacement = nativeMemoryOperandValue.Displacement;
            this.Index = X86Register.TryCreate(disassembler, nativeMemoryOperandValue.Index);
            this.Scale = nativeMemoryOperandValue.Scale;
            this.Segment = X86Register.TryCreate(disassembler, nativeMemoryOperandValue.Segment);

            return this;
        }

        /// <summary>
        ///     Create an X86 Memory Operand Value.
        /// </summary>
        /// <returns>
        ///     An X86 memory operand value.
        /// </returns>
        internal X86MemoryOperandValue Create() {
            return new X86MemoryOperandValue(this);
        }
    }
}