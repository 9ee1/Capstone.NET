namespace Gee.External.Capstone.XCore {
    /// <summary>
    ///     XCore Memory Operand Value Builder.
    /// </summary>
    internal sealed class XCoreMemoryOperandValueBuilder {
        /// <summary>
        ///     Get and Set Base Register.
        /// </summary>
        internal XCoreRegister Base { get; private set; }

        /// <summary>
        ///     Get and Set Direct Value.
        /// </summary>
        internal int Direct { get; private set; }

        /// <summary>
        ///     Get and Set Displacement Value.
        /// </summary>
        internal int Displacement { get; private set; }

        /// <summary>
        ///     Get and Set Index Register.
        /// </summary>
        internal XCoreRegister Index { get; private set; }

        /// <summary>
        ///     Build an XCore Memory Operand Value Builder.
        /// </summary>
        /// <param name="disassembler">
        ///     A disassembler.
        /// </param>
        /// <param name="nativeMemoryOperandValue">
        ///     A native XCore memory operand value.
        /// </param>
        /// <returns>
        ///     This builder.
        /// </returns>
        internal XCoreMemoryOperandValueBuilder Build(CapstoneDisassembler disassembler, ref NativeXCoreMemoryOperandValue nativeMemoryOperandValue) {
            this.Base = XCoreRegister.TryCreate(disassembler, nativeMemoryOperandValue.Base);
            this.Direct = nativeMemoryOperandValue.Direct;
            this.Displacement = nativeMemoryOperandValue.Displacement;
            this.Index = XCoreRegister.TryCreate(disassembler, nativeMemoryOperandValue.Index);

            return this;
        }

        /// <summary>
        ///     Create an XCore Memory Operand Value.
        /// </summary>
        /// <returns>
        ///     An XCore memory operand value.
        /// </returns>
        internal XCoreMemoryOperandValue Create() {
            return new XCoreMemoryOperandValue(this);
        }
    }
}