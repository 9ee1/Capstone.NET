namespace Gee.External.Capstone.Mips {
    /// <summary>
    ///     MIPS Operand Builder.
    /// </summary>
    internal sealed class MipsOperandBuilder {
        /// <summary>
        ///     Get and Set Operand's Immediate Value.
        /// </summary>
        internal long Immediate { get; private set; }

        /// <summary>
        ///     Get and Set Operand's Memory Value.
        /// </summary>
        internal MipsMemoryOperandValue Memory { get; private set; }

        /// <summary>
        ///     Get and Set Operand's Register Value.
        /// </summary>
        internal MipsRegister Register { get; private set; }

        /// <summary>
        ///     Get and Set Operand's Type.
        /// </summary>
        internal MipsOperandType Type { get; private set; }

        /// <summary>
        ///     Build a MIPS Operand.
        /// </summary>
        /// <param name="disassembler">
        ///     A disassembler.
        /// </param>
        /// <param name="nativeOperand">
        ///     A native MIPS operand.
        /// </param>
        /// <returns>
        ///     This builder.
        /// </returns>
        internal MipsOperandBuilder Build(CapstoneDisassembler disassembler, ref NativeMipsOperand nativeOperand) {
            this.Type = nativeOperand.Type;
            // ...
            //
            // ...
            switch (this.Type) {
                case MipsOperandType.Immediate:
                    this.Immediate = nativeOperand.Value.Immediate;
                    break;
                case MipsOperandType.Memory:
                    this.Memory = MipsMemoryOperandValue.Create(disassembler, ref nativeOperand.Value.Memory);
                    break;
                case MipsOperandType.Register:
                    this.Register = MipsRegister.TryCreate(disassembler, nativeOperand.Value.Register);
                    break;
            }

            return this;
        }

        /// <summary>
        ///     Create a MIPS Operand.
        /// </summary>
        /// <returns>
        ///     A MIPS operand.
        /// </returns>
        internal MipsOperand Create() {
            return new MipsOperand(this);
        }
    }
}