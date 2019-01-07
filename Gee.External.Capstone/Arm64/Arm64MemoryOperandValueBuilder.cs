namespace Gee.External.Capstone.Arm64 {
    /// <summary>
    ///     ARM64 Memory Operand Value Builder.
    /// </summary>
    internal sealed class Arm64MemoryOperandValueBuilder {
        /// <summary>
        ///     Get and Set Base Register.
        /// </summary>
        internal Arm64Register Base { get; private set; }

        /// <summary>
        ///     Get and Set Displacement Value.
        /// </summary>
        internal int Displacement { get; private set; }

        /// <summary>
        ///     Get and Set Index Register.
        /// </summary>
        internal Arm64Register Index { get; private set; }

        /// <summary>
        ///     Build an X86 Memory Operand Value Builder.
        /// </summary>
        /// <param name="disassembler">
        ///     A disassembler.
        /// </param>
        /// <param name="nativeMemoryOperandValue">
        ///     A native ARM64 memory operand value.
        /// </param>
        /// <returns>
        ///     This builder.
        /// </returns>
        internal Arm64MemoryOperandValueBuilder Build(CapstoneDisassembler disassembler, ref NativeArm64MemoryOperandValue nativeMemoryOperandValue) {
            this.Base = Arm64Register.TryCreate(disassembler, nativeMemoryOperandValue.Base);
            this.Displacement = nativeMemoryOperandValue.Displacement;
            this.Index = Arm64Register.TryCreate(disassembler, nativeMemoryOperandValue.Index);

            return this;
        }

        /// <summary>
        ///     Create an ARM64 Memory Operand Value.
        /// </summary>
        /// <returns>
        ///     An ARM64 memory operand value.
        /// </returns>
        internal Arm64MemoryOperandValue Create() {
            return new Arm64MemoryOperandValue(this);
        }
    }
}