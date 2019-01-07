namespace Gee.External.Capstone.Arm64 {
    /// <summary>
    ///     ARM64 Operand Builder.
    /// </summary>
    internal sealed class Arm64OperandBuilder {
        /// <summary>
        ///     Get and Set Operand's Access Type.
        /// </summary>
        internal OperandAccessType AccessType { get; private set; }

        /// <summary>
        ///     Get and Set Address Translation (AT) Operation.
        /// </summary>
        internal Arm64AtOperation AtOperation { get; private set; }

        /// <summary>
        ///     Get and Set Barrier Operation.
        /// </summary>
        internal Arm64BarrierOperation BarrierOperation { get; private set; }

        /// <summary>
        ///     Get and Set Data Cache (DC) Operation.
        /// </summary>
        internal Arm64DcOperation DcOperation { get; private set; }

        /// <summary>
        ///     Get and Set Extend Operation.
        /// </summary>
        internal Arm64ExtendOperation ExtendOperation { get; private set; }

        /// <summary>
        ///     Get and Set Floating Point Value.
        /// </summary>
        internal double FloatingPoint { get; private set; }

        /// <summary>
        ///     Get and Set Instruction Cache (IC) Operation.
        /// </summary>
        internal Arm64IcOperation IcOperation { get; private set; }

        /// <summary>
        ///     Get and Set Immediate Value.
        /// </summary>
        internal long Immediate { get; private set; }

        /// <summary>
        ///     Get and Set Memory Value.
        /// </summary>
        internal Arm64MemoryOperandValue Memory { get; private set; }

        /// <summary>
        ///     Get and Set MRS Register Value.
        /// </summary>
        internal Arm64MrsSystemRegister MrsRegister { get; private set; }

        /// <summary>
        ///     Get and Set MSR Register Value.
        /// </summary>
        internal Arm64MsrSystemRegister MsrRegister { get; private set; }

        /// <summary>
        ///     Get and Set Prefetch Operation.
        /// </summary>
        internal Arm64PrefetchOperation PrefetchOperation { get; private set; }

        /// <summary>
        ///     Get and Set Processor State (PSTATE) Field.
        /// </summary>
        internal Arm64PStateField PStateField { get; private set; }

        /// <summary>
        ///     Get and Set Register Value.
        /// </summary>
        internal Arm64Register Register { get; private set; }

        /// <summary>
        ///     Get and Set Shift Operation.
        /// </summary>
        internal Arm64ShiftOperation ShiftOperation { get; private set; }

        /// <summary>
        ///     Get and Set Shift Value.
        /// </summary>
        internal int ShiftValue { get; private set; }

        /// <summary>
        ///     Get and Set Translation Lookaside Buffer (TLBI) Operation.
        /// </summary>
        internal Arm64TlbiOperation TlbiOperation { get; private set; }

        /// <summary>
        ///     Get and Set Operand's Type.
        /// </summary>
        internal Arm64OperandType Type { get; private set; }

        /// <summary>
        ///     Get and Set Vector Arrangement Specifier.
        /// </summary>
        internal Arm64VectorArrangementSpecifier VectorArrangementSpecifier { get; private set; }

        /// <summary>
        ///     Get and Set Vector Element Size Specifier.
        /// </summary>
        internal Arm64VectorElementSizeSpecifier VectorElementSizeSpecifier { get; private set; }

        /// <summary>
        ///     Get and Set Vector Index.
        /// </summary>
        internal int VectorIndex { get; private set; }

        /// <summary>
        ///     Build an ARM64 Operand.
        /// </summary>
        /// <param name="disassembler">
        ///     A disassembler.
        /// </param>
        /// <param name="instructionId">
        ///     An instruction's unique identifier.
        /// </param>
        /// <param name="nativeOperand">
        ///     A native ARM64 operand.
        /// </param>
        /// <returns>
        ///     This builder.
        /// </returns>
        internal Arm64OperandBuilder Build(CapstoneDisassembler disassembler, Arm64InstructionId instructionId, ref NativeArm64Operand nativeOperand) {
            this.AccessType = nativeOperand.AccessType;
            this.ExtendOperation = nativeOperand.ExtendOperation;
            this.ShiftOperation = nativeOperand.Shift.Operation;
            this.ShiftValue = nativeOperand.Shift.Value;
            this.Type = nativeOperand.Type;
            this.VectorArrangementSpecifier = nativeOperand.VectorArrangementSpecifier;
            this.VectorElementSizeSpecifier = nativeOperand.VectorElementSizeSpecifier;
            this.VectorIndex = nativeOperand.VectorIndex;
            // ...
            //
            // ...
            switch (this.Type) {
                case Arm64OperandType.BarrierOperation:
                    this.BarrierOperation = nativeOperand.Value.BarrierOperation;
                    break;
                case Arm64OperandType.CImmediate:
                    this.Immediate = nativeOperand.Value.Immediate;
                    break;
                case Arm64OperandType.FloatingPoint:
                    this.FloatingPoint = nativeOperand.Value.FloatingPoint;
                    break;
                case Arm64OperandType.Immediate:
                    this.Immediate = nativeOperand.Value.Immediate;
                    break;
                case Arm64OperandType.Memory:
                    this.Memory = Arm64MemoryOperandValue.Create(disassembler, ref nativeOperand.Value.Memory);
                    break;
                case Arm64OperandType.MrsRegister:
                    this.MrsRegister = (Arm64MrsSystemRegister) nativeOperand.Value.Register;
                    break;
                case Arm64OperandType.MsrRegister:
                    this.MsrRegister = (Arm64MsrSystemRegister) nativeOperand.Value.Register;
                    break;
                case Arm64OperandType.PrefetchOperation:
                    this.PrefetchOperation = nativeOperand.Value.PrefetchOperation;
                    break;
                case Arm64OperandType.PStateField:
                    this.PStateField = nativeOperand.Value.PStateField;
                    break;
                case Arm64OperandType.Register:
                    this.Register = Arm64Register.TryCreate(disassembler, nativeOperand.Value.Register);
                    break;
                case Arm64OperandType.System:
                    switch (instructionId) {
                        case Arm64InstructionId.ARM64_INS_AT:
                            this.AtOperation = (Arm64AtOperation) nativeOperand.Value.SystemOperation;
                            this.Type = Arm64OperandType.AtOperation;
                            break;
                        case Arm64InstructionId.ARM64_INS_DC:
                            this.DcOperation = (Arm64DcOperation) nativeOperand.Value.SystemOperation;
                            this.Type = Arm64OperandType.DcOperation;
                            break;
                        case Arm64InstructionId.ARM64_INS_IC:
                            this.IcOperation = (Arm64IcOperation) nativeOperand.Value.SystemOperation;
                            this.Type = Arm64OperandType.IcOperation;
                            break;
                        case Arm64InstructionId.ARM64_INS_TLBI:
                            this.TlbiOperation = (Arm64TlbiOperation) nativeOperand.Value.SystemOperation;
                            this.Type = Arm64OperandType.TlbiOperation;
                            break;
                    }

                    break;
            }

            return this;
        }

        /// <summary>
        ///     Create an ARM64 Operand.
        /// </summary>
        /// <returns>
        ///     An ARM64 operand.
        /// </returns>
        internal Arm64Operand Create() {
            return new Arm64Operand(this);
        }
    }
}