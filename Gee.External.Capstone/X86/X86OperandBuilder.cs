namespace Gee.External.Capstone.X86 {
    /// <summary>
    ///     X86 Operand Builder.
    /// </summary>
    internal sealed class X86OperandBuilder {
        /// <summary>
        ///     Get and Set Operand's Access Type.
        /// </summary>
        internal OperandAccessType AccessType { get; private set; }

        /// <summary>
        ///     Get and Set AVX Broadcast.
        /// </summary>
        internal X86AvxBroadcast AvxBroadcast { get; private set; }

        /// <summary>
        ///     Get and Set AVX Zero Opmask.
        /// </summary>
        internal bool AvxZeroOpMask { get; private set; }

        /// <summary>
        ///     Get and Set Immediate Value.
        /// </summary>
        internal long Immediate { get; private set; }

        /// <summary>
        ///     Get and Set Memory Value.
        /// </summary>
        internal X86MemoryOperandValue Memory { get; private set; }

        /// <summary>
        ///     Get and Set Register Value.
        /// </summary>
        internal X86Register Register { get; private set; }

        /// <summary>
        ///     Get and Set Operand's Size.
        /// </summary>
        internal byte Size { get; private set; }

        /// <summary>
        ///     Get and Set Operand's Type.
        /// </summary>
        internal X86OperandType Type { get; private set; }

        /// <summary>
        ///     Build an X86 Operand.
        /// </summary>
        /// <param name="disassembler">
        ///     A disassembler.
        /// </param>
        /// <param name="nativeOperand">
        ///     A native X86 operand.
        /// </param>
        /// <returns>
        ///     This builder.
        /// </returns>
        internal X86OperandBuilder Build(CapstoneDisassembler disassembler, ref NativeX86Operand nativeOperand) {
            this.AccessType = !CapstoneDisassembler.IsDietModeEnabled ? nativeOperand.AccessType : OperandAccessType.Invalid;
            this.AvxBroadcast = nativeOperand.AvxBroadcast;
            this.AvxZeroOpMask = nativeOperand.AvxZeroOpMask;
            this.Size = nativeOperand.Size;
            this.Type = nativeOperand.Type;
            // ...
            //
            // ...
            switch (this.Type) {
                case X86OperandType.Immediate:
                    this.Immediate = nativeOperand.Value.Immediate;
                    break;
                case X86OperandType.Memory:
                    this.Memory = X86MemoryOperandValue.Create(disassembler, ref nativeOperand.Value.Memory);
                    break;
                case X86OperandType.Register:
                    this.Register = X86Register.TryCreate(disassembler, nativeOperand.Value.Register);
                    break;
            }

            return this;
        }

        /// <summary>
        ///     Create an X86 Operand.
        /// </summary>
        /// <returns>
        ///     An X86 operand.
        /// </returns>
        internal X86Operand Create() {
            return new X86Operand(this);
        }
    }
}