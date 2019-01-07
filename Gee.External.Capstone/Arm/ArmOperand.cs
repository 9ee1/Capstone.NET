using System;

namespace Gee.External.Capstone.Arm {
    /// <summary>
    ///     ARM Operand.
    /// </summary>
    public sealed class ArmOperand {
        /// <summary>
        ///     Operand's Access Type.
        /// </summary>
        private readonly OperandAccessType _accessType;

        /// <summary>
        ///     Floating Point Value.
        /// </summary>
        private readonly double _floatingPoint;

        /// <summary>
        ///     Immediate Value.
        /// </summary>
        private readonly int _immediate;

        /// <summary>
        ///     Memory Value.
        /// </summary>
        private readonly ArmMemoryOperandValue _memory;

        /// <summary>
        ///     Register Value.
        /// </summary>
        private readonly ArmRegister _register;

        /// <summary>
        ///     SETEND Operation.
        /// </summary>
        private readonly ArmSetEndOperation _setEndOperation;

        /// <summary>
        ///     Shift Constant.
        /// </summary>
        private readonly int _shiftConstant;

        /// <summary>
        ///     Shift Register.
        /// </summary>
        private readonly ArmRegister _shiftRegister;

        /// <summary>
        ///     System Register Value.
        /// </summary>
        private readonly ArmSystemRegister _systemRegister;

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
        ///     Get Floating Point Value.
        /// </summary>
        /// <exception cref="System.InvalidOperationException">
        ///     Thrown if the operand's type is not equal to <see cref="ArmOperandType.FloatingPoint" />.
        /// </exception>
        public double FloatingPoint {
            get {
                if (this.Type != ArmOperandType.FloatingPoint) {
                    const string valueName = nameof(ArmOperand.FloatingPoint);
                    var detailMessage = $"A value ({valueName}) is invalid when the type is ({this.Type}).";
                    throw new InvalidOperationException(detailMessage);
                }

                return this._floatingPoint;
            }
        }

        /// <summary>
        ///     Get Immediate Value.
        /// </summary>
        /// <exception cref="System.InvalidOperationException">
        ///     Thrown if the operand's type is not equal to <see cref="ArmOperandType.Immediate" /> or, if the
        ///     operand's type is not equal to <see cref="ArmOperandType.CImmediate" />, or if the operand's type is
        ///     not equal to <see cref="ArmOperandType.PImmediate" />.
        /// </exception>
        public int Immediate {
            get {
                var isTypeImmediate = this.Type == ArmOperandType.Immediate;
                isTypeImmediate = isTypeImmediate || this.Type == ArmOperandType.CImmediate;
                isTypeImmediate = isTypeImmediate || this.Type == ArmOperandType.PImmediate;
                if (!isTypeImmediate) {
                    const string valueName = nameof(ArmOperand.Immediate);
                    var detailMessage = $"A value ({valueName}) is invalid when the type is ({this.Type}).";
                    throw new InvalidOperationException(detailMessage);
                }

                return this._immediate;
            }
        }

        /// <summary>
        ///     Get Operand's Subtracted Flag.
        /// </summary>
        public bool IsSubtracted { get; }

        /// <summary>
        ///     Get Memory Value.
        /// </summary>
        /// <exception cref="System.InvalidOperationException">
        ///     Thrown if the operand's type is not equal to <see cref="ArmOperandType.Memory" />.
        /// </exception>
        public ArmMemoryOperandValue Memory {
            get {
                if (this.Type != ArmOperandType.Memory) {
                    const string valueName = nameof(ArmOperand.Memory);
                    var detailMessage = $"A value ({valueName}) is invalid when the type is ({this.Type}).";
                    throw new InvalidOperationException(detailMessage);
                }

                return this._memory;
            }
        }

        /// <summary>
        ///     Get Neon Lane Value.
        /// </summary>
        public sbyte NeonLane { get; }

        /// <summary>
        ///     Get Register Value.
        /// </summary>
        /// <exception cref="System.InvalidOperationException">
        ///     Thrown if the operand's type is not equal to <see cref="ArmOperandType.Register" />.
        /// </exception>
        public ArmRegister Register {
            get {
                if (this.Type != ArmOperandType.Register) {
                    const string valueName = nameof(ArmOperand.Register);
                    var detailMessage = $"A value ({valueName}) is invalid when the type is ({this.Type}).";
                    throw new InvalidOperationException(detailMessage);
                }

                return this._register;
            }
        }

        /// <summary>
        ///     Get SETEND Operation.
        /// </summary>
        /// <exception cref="System.InvalidOperationException">
        ///     Thrown if the operand's type is not equal to <see cref="ArmOperandType.SetEndOperation" />.
        /// </exception>
        public ArmSetEndOperation SetEndOperation {
            get {
                if (this.Type != ArmOperandType.SetEndOperation) {
                    const string valueName = nameof(ArmOperand.SetEndOperation);
                    var detailMessage = $"A value ({valueName}) is invalid when the type is ({this.Type}).";
                    throw new InvalidOperationException(detailMessage);
                }

                return this._setEndOperation;
            }
        }

        /// <summary>
        ///     Get Shift Constant.
        /// </summary>
        /// <exception cref="System.InvalidOperationException">
        ///     Thrown if the shift operation is equal to <see cref="ArmShiftOperation.Invalid" />, or if the shift
        ///     operation is not less than <see cref="ArmShiftOperation.ARM_SFT_ASR_REG" />.
        /// </exception>
        public int ShiftConstant {
            get {
                if (this.ShiftOperation == ArmShiftOperation.Invalid) {
                    const string valueName = nameof(ArmOperand.ShiftConstant);
                    var detailMessage = $"A value ({valueName}) is invalid when the type is ({this.ShiftOperation}).";
                    throw new InvalidOperationException(detailMessage);
                }

                if (!(this.ShiftOperation < ArmShiftOperation.ARM_SFT_ASR_REG)) {
                    const string valueName = nameof(ArmOperand.ShiftConstant);
                    var detailMessage = $"A value ({valueName}) is invalid when the type is ({this.ShiftOperation}).";
                    throw new InvalidOperationException(detailMessage);
                }

                return this._shiftConstant;
            }
        }

        /// <summary>
        ///     Get Shift Operation.
        /// </summary>
        public ArmShiftOperation ShiftOperation { get; }

        /// <summary>
        ///     Get Shift Register.
        /// </summary>
        /// <exception cref="System.InvalidOperationException">
        ///     Thrown if the shift operation is equal to <see cref="ArmShiftOperation.Invalid" />, or if the shift
        ///     operation is less than <see cref="ArmShiftOperation.ARM_SFT_ASR_REG" />.
        /// </exception>
        public ArmRegister ShiftRegister {
            get {
                if (this.ShiftOperation == ArmShiftOperation.Invalid) {
                    const string valueName = nameof(ArmOperand.ShiftRegister);
                    var detailMessage = $"A value ({valueName}) is invalid when the type is ({this.ShiftOperation}).";
                    throw new InvalidOperationException(detailMessage);
                }

                if (this.ShiftOperation < ArmShiftOperation.ARM_SFT_ASR_REG) {
                    const string valueName = nameof(ArmOperand.ShiftRegister);
                    var detailMessage = $"A value ({valueName}) is invalid when the type is ({this.ShiftOperation}).";
                    throw new InvalidOperationException(detailMessage);
                }

                return this._shiftRegister;
            }
        }

        /// <summary>
        ///     Get System Register.
        /// </summary>
        /// <exception cref="System.InvalidOperationException">
        ///     Thrown if the operand's type is not equal to <see cref="ArmOperandType.SystemRegister" />.
        /// </exception>
        public ArmSystemRegister SystemRegister {
            get {
                if (this.Type != ArmOperandType.SystemRegister) {
                    const string valueName = nameof(ArmOperand.SystemRegister);
                    var detailMessage = $"A value ({valueName}) is invalid when the type is ({this.Type}).";
                    throw new InvalidOperationException(detailMessage);
                }

                return this._systemRegister;
            }
        }

        /// <summary>
        ///     Get Operand's Type.
        /// </summary>
        public ArmOperandType Type { get; }

        /// <summary>
        ///     Get Vector Index.
        /// </summary>
        public int VectorIndex { get; }

        /// <summary>
        ///     Create ARM Operands.
        /// </summary>
        /// <param name="disassembler">
        ///     A disassembler.
        /// </param>
        /// <param name="nativeInstructionDetail">
        ///     A native ARM instruction detail.
        /// </param>
        /// <returns>
        ///     An array of ARM operands.
        /// </returns>
        internal static ArmOperand[] Create(CapstoneDisassembler disassembler, ref NativeArmInstructionDetail nativeInstructionDetail) {
            var operands = new ArmOperand[nativeInstructionDetail.OperandCount];
            for (var i = 0; i < operands.Length; i++) {
                ref var nativeOperand = ref nativeInstructionDetail.Operands[i];
                operands[i] = ArmOperand.Create(disassembler, ref nativeOperand);
            }

            return operands;
        }

        /// <summary>
        ///     Create an ARM Operand.
        /// </summary>
        /// <param name="disassembler">
        ///     A disassembler.
        /// </param>
        /// <param name="nativeOperand">
        ///     A native ARM operand.
        /// </param>
        /// <returns>
        ///     An ARM operand.
        /// </returns>
        internal static ArmOperand Create(CapstoneDisassembler disassembler, ref NativeArmOperand nativeOperand) {
            return new ArmOperandBuilder().Build(disassembler, ref nativeOperand).Create();
        }

        /// <summary>
        ///     Create an ARM Operand.
        /// </summary>
        /// <param name="builder">
        ///     A builder to initialize the object with.
        /// </param>
        internal ArmOperand(ArmOperandBuilder builder) {
            this._accessType = builder.AccessType;
            this._floatingPoint = builder.FloatingPoint;
            this._immediate = builder.Immediate;
            this.IsSubtracted = builder.IsSubtracted;
            this._memory = builder.Memory;
            this.NeonLane = builder.NeonLane;
            this._register = builder.Register;
            this._setEndOperation = builder.SetEndOperation;
            this._shiftConstant = builder.ShiftConstant;
            this.ShiftOperation = builder.ShiftOperation;
            this._shiftRegister = builder.ShiftRegister;
            this._systemRegister = builder.SystemRegister;
            this.Type = builder.Type;
            this.VectorIndex = builder.VectorIndex;
        }
    }
}