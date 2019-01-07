using System;

namespace Gee.External.Capstone.Arm64 {
    /// <summary>
    ///     ARM64 Operand.
    /// </summary>
    public sealed class Arm64Operand {
        /// <summary>
        ///     Operand's Access Type.
        /// </summary>
        private readonly OperandAccessType _accessType;

        /// <summary>
        ///     Address Translation (AT) Operation.
        /// </summary>
        private readonly Arm64AtOperation _atOperation;

        /// <summary>
        ///     Data Cache (DC) Operation.
        /// </summary>
        private readonly Arm64DcOperation _dcOperation;

        /// <summary>
        ///     Floating Point Value.
        /// </summary>
        private readonly double _floatingPoint;

        /// <summary>
        ///     Instruction Cache (IC) Operation.
        /// </summary>
        private readonly Arm64IcOperation _icOperation;

        /// <summary>
        ///     Immediate Value.
        /// </summary>
        private readonly long _immediate;

        /// <summary>
        ///     Memory Value.
        /// </summary>
        private readonly Arm64MemoryOperandValue _memory;

        /// <summary>
        ///     MRS Register Value.
        /// </summary>
        private readonly Arm64MrsSystemRegister _mrsRegister;

        /// <summary>
        ///     MSR Register Value.
        /// </summary>
        private readonly Arm64MsrSystemRegister _msrRegister;

        /// <summary>
        ///     Prefetch Operation.
        /// </summary>
        private readonly Arm64PrefetchOperation _prefetchOperation;

        /// <summary>
        ///     Processor State (PSTATE) Field.
        /// </summary>
        private readonly Arm64PStateField _pStateField;

        /// <summary>
        ///     Register Value.
        /// </summary>
        private readonly Arm64Register _register;

        /// <summary>
        ///     Shift Value.
        /// </summary>
        private readonly int _shiftValue;

        /// <summary>
        ///     Translation Lookaside Buffer (TLBI) Operation.
        /// </summary>
        private readonly Arm64TlbiOperation _tlbiOperation;

        /// <summary>
        ///     Get Operand's Access Type.
        /// </summary>
        /// <exception cref="System.NotSupportedException">
        ///     Thrown if diet mode is enabled.
        /// </exception>
        public OperandAccessType AccessType {
            get {
                CapstoneDisassembler.ThrowIfDietModeIsEnabled();
                return this._accessType;
            }
        }

        /// <summary>
        ///     Get Address Translation (AT) Operation.
        /// </summary>
        /// <exception cref="System.InvalidOperationException">
        ///     Thrown if the operand's type is not equal to <see cref="Arm64OperandType.AtOperation" />.
        /// </exception>
        public Arm64AtOperation AtOperation {
            get {
                if (this.Type != Arm64OperandType.AtOperation) {
                    const string valueName = nameof(Arm64Operand.AtOperation);
                    var detailMessage = $"A value ({valueName}) is invalid when the type is ({this.Type}).";
                    throw new InvalidOperationException(detailMessage);
                }

                return this._atOperation;
            }
        }

        /// <summary>
        ///     Get Barrier Operation.
        /// </summary>
        public Arm64BarrierOperation BarrierOperation { get; }

        /// <summary>
        ///     Get Data Cache (DC) Operation.
        /// </summary>
        /// <exception cref="System.InvalidOperationException">
        ///     Thrown if the operand's type is not equal to <see cref="Arm64OperandType.DcOperation" />.
        /// </exception>
        public Arm64DcOperation DcOperation {
            get {
                if (this.Type != Arm64OperandType.DcOperation) {
                    const string valueName = nameof(Arm64Operand.DcOperation);
                    var detailMessage = $"A value ({valueName}) is invalid when the type is ({this.Type}).";
                    throw new InvalidOperationException(detailMessage);
                }

                return this._dcOperation;
            }
        }

        /// <summary>
        ///     Get Extend Operation.
        /// </summary>
        public Arm64ExtendOperation ExtendOperation { get; }

        /// <summary>
        ///     Get Floating Point Value.
        /// </summary>
        /// <exception cref="System.InvalidOperationException">
        ///     Thrown if the operand's type is not equal to <see cref="Arm64OperandType.FloatingPoint" />.
        /// </exception>
        public double FloatingPoint {
            get {
                if (this.Type != Arm64OperandType.FloatingPoint) {
                    const string valueName = nameof(Arm64Operand.FloatingPoint);
                    var detailMessage = $"A value ({valueName}) is invalid when the type is ({this.Type}).";
                    throw new InvalidOperationException(detailMessage);
                }

                return this._floatingPoint;
            }
        }

        /// <summary>
        ///     Get Instruction Cache (IC) Operation.
        /// </summary>
        /// <exception cref="System.InvalidOperationException">
        ///     Thrown if the operand's type is not equal to <see cref="Arm64OperandType.IcOperation" />.
        /// </exception>
        public Arm64IcOperation IcOperation {
            get {
                if (this.Type != Arm64OperandType.IcOperation) {
                    const string valueName = nameof(Arm64Operand.IcOperation);
                    var detailMessage = $"A value ({valueName}) is invalid when the type is ({this.Type}).";
                    throw new InvalidOperationException(detailMessage);
                }

                return this._icOperation;
            }
        }

        /// <summary>
        ///     Get Immediate Value.
        /// </summary>
        /// <exception cref="System.InvalidOperationException">
        ///     Thrown if the operand's type is not equal to <see cref="Arm64OperandType.Immediate" />.
        /// </exception>
        public long Immediate {
            get {
                if (this.Type != Arm64OperandType.CImmediate && this.Type != Arm64OperandType.Immediate) {
                    const string valueName = nameof(Arm64Operand.Immediate);
                    var detailMessage = $"A value ({valueName}) is invalid when the type is ({this.Type}).";
                    throw new InvalidOperationException(detailMessage);
                }

                return this._immediate;
            }
        }

        /// <summary>
        ///     Determine if Diet Mode is Enabled.
        /// </summary>
        /// <value>
        ///     A boolean true if diet mode is enabled. A boolean false otherwise.
        /// </value>
        public bool IsDietModeEnabled => CapstoneDisassembler.IsDietModeEnabled;

        /// <summary>
        ///     Get Memory Value.
        /// </summary>
        /// <exception cref="System.InvalidOperationException">
        ///     Thrown if the operand's type is not equal to <see cref="Arm64OperandType.Memory" />.
        /// </exception>
        public Arm64MemoryOperandValue Memory {
            get {
                if (this.Type != Arm64OperandType.Memory) {
                    const string valueName = nameof(Arm64Operand.Memory);
                    var detailMessage = $"A value ({valueName}) is invalid when the type is ({this.Type}).";
                    throw new InvalidOperationException(detailMessage);
                }

                return this._memory;
            }
        }

        /// <summary>
        ///     Get MRS Register Value.
        /// </summary>
        /// <exception cref="System.InvalidOperationException">
        ///     Thrown if the operand's type is not equal to <see cref="Arm64OperandType.MrsRegister" />.
        /// </exception>
        public Arm64MrsSystemRegister MrsRegister {
            get {
                if (this.Type != Arm64OperandType.MrsRegister) {
                    const string valueName = nameof(Arm64Operand.MrsRegister);
                    var detailMessage = $"A value ({valueName}) is invalid when the type is ({this.Type}).";
                    throw new InvalidOperationException(detailMessage);
                }

                return this._mrsRegister;
            }
        }

        /// <summary>
        ///     Get MSR Register Value.
        /// </summary>
        /// <exception cref="System.InvalidOperationException">
        ///     Thrown if the operand's type is not equal to <see cref="Arm64OperandType.MrsRegister" />.
        /// </exception>
        public Arm64MsrSystemRegister MsrRegister {
            get {
                if (this.Type != Arm64OperandType.MsrRegister) {
                    const string valueName = nameof(Arm64Operand.MsrRegister);
                    var detailMessage = $"A value ({valueName}) is invalid when the type is ({this.Type}).";
                    throw new InvalidOperationException(detailMessage);
                }

                return this._msrRegister;
            }
        }

        /// <summary>
        ///     Get Prefetch Operation.
        /// </summary>
        /// <exception cref="System.InvalidOperationException">
        ///     Thrown if the operand's type is not equal to <see cref="Arm64OperandType.PrefetchOperation" />.
        /// </exception>
        public Arm64PrefetchOperation PrefetchOperation {
            get {
                if (this.Type != Arm64OperandType.PrefetchOperation) {
                    const string valueName = nameof(Arm64Operand.PrefetchOperation);
                    var detailMessage = $"A value ({valueName}) is invalid when the type is ({this.Type}).";
                    throw new InvalidOperationException(detailMessage);
                }

                return this._prefetchOperation;
            }
        }

        /// <summary>
        ///     Get Processor State (PSTATE) Field.
        /// </summary>
        /// <exception cref="System.InvalidOperationException">
        ///     Thrown if the operand's type is not equal to <see cref="Arm64OperandType.PStateField" />.
        /// </exception>
        public Arm64PStateField PStateField {
            get {
                if (this.Type != Arm64OperandType.PStateField) {
                    const string valueName = nameof(Arm64Operand.PStateField);
                    var detailMessage = $"A value ({valueName}) is invalid when the type is ({this.Type}).";
                    throw new InvalidOperationException(detailMessage);
                }

                return this._pStateField;
            }
        }

        /// <summary>
        ///     Get Register Value.
        /// </summary>
        /// <exception cref="System.InvalidOperationException">
        ///     Thrown if the operand's type is not equal to <see cref="Arm64OperandType.Register" />.
        /// </exception>
        public Arm64Register Register {
            get {
                if (this.Type != Arm64OperandType.Register) {
                    const string valueName = nameof(Arm64Operand.Register);
                    var detailMessage = $"A value ({valueName}) is invalid when the type is ({this.Type}).";
                    throw new InvalidOperationException(detailMessage);
                }

                return this._register;
            }
        }

        /// <summary>
        ///     Get Shift Operation.
        /// </summary>
        public Arm64ShiftOperation ShiftOperation { get; }

        /// <summary>
        ///     Get Shift Value.
        /// </summary>
        /// <exception cref="System.InvalidOperationException">
        ///     Thrown if the shift operation is equal to <see cref="Arm64ShiftOperation.Invalid" />.
        /// </exception>
        public int ShiftValue {
            get {
                if (this.ShiftOperation == Arm64ShiftOperation.Invalid) {
                    const string valueName = nameof(Arm64Operand.ShiftValue);
                    var detailMessage = $"A value ({valueName}) is invalid when the type is ({this.ShiftOperation}).";
                    throw new InvalidOperationException(detailMessage);
                }

                return this._shiftValue;
            }
        }

        /// <summary>
        ///     Get Translation Lookaside Buffer (TLBI) Operation.
        /// </summary>
        public Arm64TlbiOperation TlbiOperation {
            get {
                if (this.Type != Arm64OperandType.TlbiOperation) {
                    const string valueName = nameof(Arm64Operand.TlbiOperation);
                    var detailMessage = $"A value ({valueName}) is invalid when the type is ({this.Type}).";
                    throw new InvalidOperationException(detailMessage);
                }

                return this._tlbiOperation;
            }
        }

        /// <summary>
        ///     Get Operand's Type.
        /// </summary>
        public Arm64OperandType Type { get; }

        /// <summary>
        ///     Get Vector Arrangement Specifier.
        /// </summary>
        public Arm64VectorArrangementSpecifier VectorArrangementSpecifier { get; }

        /// <summary>
        ///     Get Vector Element Size Specifier.
        /// </summary>
        public Arm64VectorElementSizeSpecifier VectorElementSizeSpecifier { get; }

        /// <summary>
        ///     Get Vector Index.
        /// </summary>
        public int VectorIndex { get; }

        /// <summary>
        ///     Create ARM64 Operands.
        /// </summary>
        /// <param name="disassembler">
        ///     A disassembler.
        /// </param>
        /// <param name="instructionId">
        ///     An instruction's unique identifier.
        /// </param>
        /// <param name="nativeInstructionDetail">
        ///     A native ARM64 instruction detail.
        /// </param>
        /// <returns>
        ///     An array of ARM64 operands.
        /// </returns>
        internal static Arm64Operand[] Create(CapstoneDisassembler disassembler, Arm64InstructionId instructionId, ref NativeArm64InstructionDetail nativeInstructionDetail) {
            var operands = new Arm64Operand[nativeInstructionDetail.OperandCount];
            for (var i = 0; i < operands.Length; i++) {
                ref var nativeOperand = ref nativeInstructionDetail.Operands[i];
                operands[i] = Arm64Operand.Create(disassembler, instructionId, ref nativeOperand);
            }

            return operands;
        }

        /// <summary>
        ///     Create an ARM64 Operand.
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
        ///     An ARM64 operand.
        /// </returns>
        internal static Arm64Operand Create(CapstoneDisassembler disassembler, Arm64InstructionId instructionId, ref NativeArm64Operand nativeOperand) {
            return new Arm64OperandBuilder().Build(disassembler, instructionId, ref nativeOperand).Create();
        }

        /// <summary>
        ///     Create an ARM64 Operand.
        /// </summary>
        /// <param name="builder">
        ///     A builder to initialize the object with.
        /// </param>
        internal Arm64Operand(Arm64OperandBuilder builder) {
            this._accessType = builder.AccessType;
            this._atOperation = builder.AtOperation;
            this.BarrierOperation = builder.BarrierOperation;
            this._dcOperation = builder.DcOperation;
            this.ExtendOperation = builder.ExtendOperation;
            this._floatingPoint = builder.FloatingPoint;
            this._icOperation = builder.IcOperation;
            this._immediate = builder.Immediate;
            this._memory = builder.Memory;
            this._mrsRegister = builder.MrsRegister;
            this._msrRegister = builder.MsrRegister;
            this._prefetchOperation = builder.PrefetchOperation;
            this._pStateField = builder.PStateField;
            this._register = builder.Register;
            this.ShiftOperation = builder.ShiftOperation;
            this._shiftValue = builder.ShiftValue;
            this._tlbiOperation = builder.TlbiOperation;
            this.Type = builder.Type;
            this.VectorArrangementSpecifier = builder.VectorArrangementSpecifier;
            this.VectorElementSizeSpecifier = builder.VectorElementSizeSpecifier;
            this.VectorIndex = builder.VectorIndex;
        }
    }
}