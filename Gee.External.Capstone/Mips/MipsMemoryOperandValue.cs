namespace Gee.External.Capstone.Mips {
    /// <summary>
    ///     MIPS Memory Operand Value.
    /// </summary>
    public sealed class MipsMemoryOperandValue {
        /// <summary>
        ///     Get Base Register.
        /// </summary>
        public MipsRegister Base { get; }

        /// <summary>
        ///     Get Displacement.
        /// </summary>
        public long Displacement { get; }

        /// <summary>
        ///     Create a MIPS Memory Operand Value.
        /// </summary>
        /// <param name="disassembler">
        ///     A disassembler.
        /// </param>
        /// <param name="nativeMemoryOperandValue">
        ///     A native MIPS memory operand value.
        /// </param>
        /// <returns>
        ///     A MIPS memory operand value.
        /// </returns>
        internal static MipsMemoryOperandValue Create(CapstoneDisassembler disassembler, ref NativeMipsMemoryOperandValue nativeMemoryOperandValue) {
            return new MipsMemoryOperandValueBuilder().Build(disassembler, ref nativeMemoryOperandValue).Create();
        }

        /// <summary>
        ///     Create a MIPS Memory Operand Value.
        /// </summary>
        /// <param name="builder">
        ///     A builder to initialize the object with.
        /// </param>
        internal MipsMemoryOperandValue(MipsMemoryOperandValueBuilder builder) {
            this.Base = builder.Base;
            this.Displacement = builder.Displacement;
        }
    }
}