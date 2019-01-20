using System;

namespace Gee.External.Capstone.Mips {
    /// <summary>
    ///     MIPS Operand.
    /// </summary>
    public sealed class MipsOperand {
        /// <summary>
        ///     Immediate Value.
        /// </summary>
        private readonly long _immediate;

        /// <summary>
        ///     Memory Value.
        /// </summary>
        private readonly MipsMemoryOperandValue _memory;

        /// <summary>
        ///     Register Value.
        /// </summary>
        private readonly MipsRegister _register;

        /// <summary>
        ///     Get Immediate Value.
        /// </summary>
        /// <exception cref="System.InvalidOperationException">
        ///     Thrown if the operand's type is not equal to <see cref="MipsOperandType.Immediate" />.
        /// </exception>
        public long Immediate {
            get {
                if (this.Type != MipsOperandType.Immediate) {
                    const string valueName = nameof(MipsOperand.Immediate);
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
        ///     Thrown if the operand's type is not equal to <see cref="MipsOperandType.Memory" />.
        /// </exception>
        public MipsMemoryOperandValue Memory {
            get {
                if (this.Type != MipsOperandType.Memory) {
                    const string valueName = nameof(MipsOperand.Memory);
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
        ///     Thrown if the operand's type is not equal to <see cref="MipsOperandType.Register" />.
        /// </exception>
        public MipsRegister Register {
            get {
                if (this.Type != MipsOperandType.Register) {
                    const string valueName = nameof(MipsOperand.Register);
                    var detailMessage = $"A value ({valueName}) is invalid when the type is ({this.Type}).";
                    throw new InvalidOperationException(detailMessage);
                }

                return this._register;
            }
        }

        /// <summary>
        ///     Get Operand's Type.
        /// </summary>
        public MipsOperandType Type { get; }

        /// <summary>
        ///     Create MIPS Operands.
        /// </summary>
        /// <param name="disassembler">
        ///     A disassembler.
        /// </param>
        /// <param name="nativeInstructionDetail">
        ///     A native MIPS instruction detail.
        /// </param>
        /// <returns>
        ///     An array of MIPS operands.
        /// </returns>
        internal static MipsOperand[] Create(CapstoneDisassembler disassembler, ref NativeMipsInstructionDetail nativeInstructionDetail) {
            var operands = new MipsOperand[nativeInstructionDetail.OperandCount];
            for (var i = 0; i < operands.Length; i++) {
                ref var nativeOperand = ref nativeInstructionDetail.Operands[i];
                operands[i] = MipsOperand.Create(disassembler, ref nativeOperand);
            }

            return operands;
        }

        /// <summary>
        ///     Create a MIPS Operand.
        /// </summary>
        /// <param name="disassembler">
        ///     A disassembler.
        /// </param>
        /// <param name="nativeOperand">
        ///     A native MIPS operand.
        /// </param>
        /// <returns>
        ///     A MIPS operand.
        /// </returns>
        internal static MipsOperand Create(CapstoneDisassembler disassembler, ref NativeMipsOperand nativeOperand) {
            return new MipsOperandBuilder().Build(disassembler, ref nativeOperand).Create();
        }

        /// <summary>
        ///     Create a MIPS Operand.
        /// </summary>
        /// <param name="builder">
        ///     A builder to initialize the object with.
        /// </param>
        internal MipsOperand(MipsOperandBuilder builder) {
            this._immediate = builder.Immediate;
            this._memory = builder.Memory;
            this._register = builder.Register;
            this.Type = builder.Type;
        }
    }
}