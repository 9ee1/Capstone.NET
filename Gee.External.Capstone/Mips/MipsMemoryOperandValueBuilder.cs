namespace Gee.External.Capstone.Mips {
    /// <summary>
    ///     MIPS Memory Operand Value Builder.
    /// </summary>
    internal sealed class MipsMemoryOperandValueBuilder {
        /// <summary>
        ///     Get and Set Base Register.
        /// </summary>
        internal MipsRegister Base { get; private set; }

        /// <summary>
        ///     Get and Set Displacement.
        /// </summary>
        internal long Displacement { get; private set; }

        /// <summary>
        ///     Build a MIPS Memory Operand Value Builder.
        /// </summary>
        /// <param name="disassembler">
        ///     A disassembler.
        /// </param>
        /// <param name="nativeMemoryOperandValue">
        ///     A native MIPS memory operand value.
        /// </param>
        /// <returns>
        ///     This builder.
        /// </returns>
        internal MipsMemoryOperandValueBuilder Build(CapstoneDisassembler disassembler, ref NativeMipsMemoryOperandValue nativeMemoryOperandValue) {
            this.Base = MipsRegister.TryCreate(disassembler, nativeMemoryOperandValue.Base);
            this.Displacement = nativeMemoryOperandValue.Displacement;

            return this;
        }

        /// <summary>
        ///     Create a MIPS Memory Operand Value.
        /// </summary>
        /// <returns>
        ///     A MIPS memory operand value.
        /// </returns>
        internal MipsMemoryOperandValue Create() {
            return new MipsMemoryOperandValue(this);
        }
    }
}