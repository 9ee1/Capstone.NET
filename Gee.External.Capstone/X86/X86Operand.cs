using System;

namespace Gee.External.Capstone.X86 {
    /// <summary>
    ///     X86 Operand.
    /// </summary>
    public sealed class X86Operand {
        /// <summary>
        ///     Operand's Access Type.
        /// </summary>
        private readonly OperandAccessType _accessType;

        /// <summary>
        ///     Immediate Value.
        /// </summary>
        private readonly long _immediate;

        /// <summary>
        ///     Memory Value.
        /// </summary>
        private readonly X86MemoryOperandValue _memory;

        /// <summary>
        ///     Register Value.
        /// </summary>
        private readonly X86Register _register;

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
        ///     Get AVX Broadcast.
        /// </summary>
        public X86AvxBroadcast AvxBroadcast { get; }

        /// <summary>
        ///     Get AVX Zero Opmask.
        /// </summary>
        public bool AvxZeroOpMask { get; }

        /// <summary>
        ///     Get Immediate Value.
        /// </summary>
        /// <exception cref="System.InvalidOperationException">
        ///     Thrown if the operand's type is not equal to <see cref="X86OperandType.Immediate" />.
        /// </exception>
        public long Immediate {
            get {
                if (this.Type != X86OperandType.Immediate) {
                    const string valueName = nameof(X86Operand.Immediate);
                    var detailMessage = $"A value ({valueName}) is invalid when the type is ({this.Type}).";
                    throw new InvalidOperationException(detailMessage);
                }

                return this._immediate;
            }
        }

        /// <summary>
        ///     Get Memory Value.
        /// </summary>
        /// <exception cref="System.InvalidOperationException">
        ///     Thrown if the operand's type is not equal to <see cref="X86OperandType.Memory" />.
        /// </exception>
        public X86MemoryOperandValue Memory {
            get {
                if (this.Type != X86OperandType.Memory) {
                    const string valueName = nameof(X86Operand.Memory);
                    var detailMessage = $"A value ({valueName}) is invalid when the type is ({this.Type}).";
                    throw new InvalidOperationException(detailMessage);
                }

                return this._memory;
            }
        }

        /// <summary>
        ///     Get Register Value.
        /// </summary>
        /// <exception cref="System.InvalidOperationException">
        ///     Thrown if the operand's type is not equal to <see cref="X86OperandType.Register" />.
        /// </exception>
        public X86Register Register {
            get {
                if (this.Type != X86OperandType.Register) {
                    const string valueName = nameof(X86Operand.Register);
                    var detailMessage = $"A value ({valueName}) is invalid when the type is ({this.Type}).";
                    throw new InvalidOperationException(detailMessage);
                }

                return this._register;
            }
        }

        /// <summary>
        ///     Get Operand's Size.
        /// </summary>
        public byte Size { get; }

        /// <summary>
        ///     Get Operand's Type.
        /// </summary>
        public X86OperandType Type { get; }

        /// <summary>
        ///     Create X86 Operands.
        /// </summary>
        /// <param name="disassembler">
        ///     A disassembler.
        /// </param>
        /// <param name="nativeInstructionDetail">
        ///     A native X86 instruction detail.
        /// </param>
        /// <returns>
        ///     An array of X86 operands.
        /// </returns>
        internal static X86Operand[] Create(CapstoneDisassembler disassembler, ref NativeX86InstructionDetail nativeInstructionDetail) {
            var operands = new X86Operand[nativeInstructionDetail.OperandCount];
            for (var i = 0; i < operands.Length; i++) {
                ref var nativeOperand = ref nativeInstructionDetail.Operands[i];
                operands[i] = X86Operand.Create(disassembler, ref nativeOperand);
            }

            return operands;
        }

        /// <summary>
        ///     Create an X86 Operand.
        /// </summary>
        /// <param name="disassembler">
        ///     A disassembler.
        /// </param>
        /// <param name="nativeOperand">
        ///     A native X86 operand.
        /// </param>
        /// <returns>
        ///     An X86 operand.
        /// </returns>
        internal static X86Operand Create(CapstoneDisassembler disassembler, ref NativeX86Operand nativeOperand) {
            return new X86OperandBuilder().Build(disassembler, ref nativeOperand).Create();
        }

        /// <summary>
        ///     Create an X86 Operand.
        /// </summary>
        /// <param name="builder">
        ///     A builder to initialize the object with.
        /// </param>
        internal X86Operand(X86OperandBuilder builder) {
            this._accessType = builder.AccessType;
            this.AvxBroadcast = builder.AvxBroadcast;
            this.AvxZeroOpMask = builder.AvxZeroOpMask;
            this._immediate = builder.Immediate;
            this._memory = builder.Memory;
            this._register = builder.Register;
            this.Size = builder.Size;
            this.Type = builder.Type;
        }
    }
}