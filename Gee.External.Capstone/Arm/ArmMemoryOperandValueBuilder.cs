namespace Gee.External.Capstone.Arm {
    /// <summary>
    ///     ARM Memory Operand Value Builder.
    /// </summary>
    internal sealed class ArmMemoryOperandValueBuilder {
        /// <summary>
        ///     Get and Set Base Register.
        /// </summary>
        internal ArmRegister Base { get; private set; }

        /// <summary>
        ///     Get and Set Displacement Value.
        /// </summary>
        internal int Displacement { get; private set; }

        /// <summary>
        ///     Get and Set Index Register.
        /// </summary>
        internal ArmRegister Index { get; private set; }

        /// <summary>
        ///     Get and Set Index Register's Left Shift Value.
        /// </summary>
        internal int LeftShit { get; private set; }

        /// <summary>
        ///     Get and Set Index Register's Scale.
        /// </summary>
        internal int Scale { get; private set; }

        /// <summary>
        ///     Build an ARM Memory Operand Value Builder.
        /// </summary>
        /// <param name="disassembler">
        ///     A disassembler.
        /// </param>
        /// <param name="nativeMemoryOperandValue">
        ///     A native ARM memory operand value.
        /// </param>
        /// <returns>
        ///     This builder.
        /// </returns>
        internal ArmMemoryOperandValueBuilder Build(CapstoneDisassembler disassembler, ref NativeArmMemoryOperandValue nativeMemoryOperandValue) {
            this.Base = ArmRegister.TryCreate(disassembler, nativeMemoryOperandValue.Base);
            this.Displacement = nativeMemoryOperandValue.Displacement;
            this.Index = ArmRegister.TryCreate(disassembler, nativeMemoryOperandValue.Index);
            this.LeftShit = nativeMemoryOperandValue.LeftShift;
            this.Scale = nativeMemoryOperandValue.Scale;

            return this;
        }

        /// <summary>
        ///     Create an ARM Memory Operand Value.
        /// </summary>
        /// <returns>
        ///     An ARM memory operand value.
        /// </returns>
        internal ArmMemoryOperandValue Create() {
            return new ArmMemoryOperandValue(this);
        }
    }
}