namespace Gee.External.Capstone.XCore {
    /// <summary>
    ///     XCore Operand Builder.
    /// </summary>
    internal sealed class XCoreOperandBuilder {
        /// <summary>
        ///     Get and Set Immediate Value.
        /// </summary>
        internal int Immediate { get; private set; }

        /// <summary>
        ///     Get and Set Memory Value.
        /// </summary>
        internal XCoreMemoryOperandValue Memory { get; private set; }

        /// <summary>
        ///     Get and Set Register Value.
        /// </summary>
        internal XCoreRegister Register { get; private set; }

        /// <summary>
        ///     Get and Set Operand's Type.
        /// </summary>
        internal XCoreOperandType Type { get; private set; }

        /// <summary>
        ///     Build an XCore Operand.
        /// </summary>
        /// <param name="disassembler">
        ///     A disassembler.
        /// </param>
        /// <param name="nativeOperand">
        ///     A native XCore operand.
        /// </param>
        /// <returns>
        ///     This builder.
        /// </returns>
        internal XCoreOperandBuilder Build(CapstoneDisassembler disassembler, ref NativeXCoreOperand nativeOperand) {
            this.Type = nativeOperand.Type;
            // ...
            //
            // ...
            switch (this.Type) {
                case XCoreOperandType.Immediate:
                    this.Immediate = nativeOperand.Value.Immediate;
                    break;
                case XCoreOperandType.Memory:
                    this.Memory = XCoreMemoryOperandValue.Create(disassembler, ref nativeOperand.Value.Memory);
                    break;
                case XCoreOperandType.Register:
                    this.Register = XCoreRegister.TryCreate(disassembler, nativeOperand.Value.Register);
                    break;
            }

            return this;
        }

        /// <summary>
        ///     Create an XCore Operand.
        /// </summary>
        /// <returns>
        ///     An XCore operand.
        /// </returns>
        internal XCoreOperand Create() {
            return new XCoreOperand(this);
        }
    }
}