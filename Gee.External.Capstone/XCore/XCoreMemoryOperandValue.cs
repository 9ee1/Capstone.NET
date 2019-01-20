namespace Gee.External.Capstone.XCore {
    /// <summary>
    ///     XCore Memory Operand Value.
    /// </summary>
    public sealed class XCoreMemoryOperandValue {
        /// <summary>
        ///     Get Base Register.
        /// </summary>
        internal XCoreRegister Base { get; }

        /// <summary>
        ///     Get Direct Value.
        /// </summary>
        internal int Direct { get; }

        /// <summary>
        ///     Get Displacement Value.
        /// </summary>
        internal int Displacement { get; }

        /// <summary>
        ///     Get Index Register.
        /// </summary>
        internal XCoreRegister Index { get; }

        /// <summary>
        ///     Create an XCore Memory Operand Value.
        /// </summary>
        /// <param name="disassembler">
        ///     A disassembler.
        /// </param>
        /// <param name="nativeMemoryOperandValue">
        ///     A native XCore memory operand value.
        /// </param>
        /// <returns>
        ///     An XCore memory operand value.
        /// </returns>
        internal static XCoreMemoryOperandValue Create(CapstoneDisassembler disassembler, ref NativeXCoreMemoryOperandValue nativeMemoryOperandValue) {
            return new XCoreMemoryOperandValueBuilder().Build(disassembler, ref nativeMemoryOperandValue).Create();
        }

        /// <summary>
        ///     Create an XCore Memory Operand Value.
        /// </summary>
        /// <param name="builder">
        ///     A builder to initialize the object with.
        /// </param>
        internal XCoreMemoryOperandValue(XCoreMemoryOperandValueBuilder builder) {
            this.Base = builder.Base;
            this.Direct = builder.Direct;
            this.Displacement = builder.Displacement;
            this.Index = builder.Index;
        }
    }
}