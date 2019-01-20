using System;

namespace Gee.External.Capstone.XCore {
    /// <summary>
    ///     XCore Operand.
    /// </summary>
    public sealed class XCoreOperand {
        /// <summary>
        ///     Immediate Value.
        /// </summary>
        private readonly int _immediate;

        /// <summary>
        ///     Memory Value.
        /// </summary>
        private readonly XCoreMemoryOperandValue _memory;

        /// <summary>
        ///     Register Value.
        /// </summary>
        private readonly XCoreRegister _register;

        /// <summary>
        ///     Get Immediate Value.
        /// </summary>
        /// <exception cref="System.InvalidOperationException">
        ///     Thrown if the operand's type is not equal to <see cref="XCoreOperandType.Immediate" />.
        /// </exception>
        public long Immediate {
            get {
                if (this.Type != XCoreOperandType.Immediate) {
                    const string valueName = nameof(XCoreOperand.Immediate);
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
        ///     Thrown if the operand's type is not equal to <see cref="XCoreOperandType.Memory" />.
        /// </exception>
        public XCoreMemoryOperandValue Memory {
            get {
                if (this.Type != XCoreOperandType.Memory) {
                    const string valueName = nameof(XCoreOperand.Memory);
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
        ///     Thrown if the operand's type is not equal to <see cref="XCoreOperandType.Register" />.
        /// </exception>
        public XCoreRegister Register {
            get {
                if (this.Type != XCoreOperandType.Register) {
                    const string valueName = nameof(XCoreOperand.Register);
                    var detailMessage = $"A value ({valueName}) is invalid when the type is ({this.Type}).";
                    throw new InvalidOperationException(detailMessage);
                }

                return this._register;
            }
        }

        /// <summary>
        ///     Get and Set Operand's Type.
        /// </summary>
        public XCoreOperandType Type { get; }

        /// <summary>
        ///     Create XCore Operands.
        /// </summary>
        /// <param name="disassembler">
        ///     A disassembler.
        /// </param>
        /// <param name="nativeInstructionDetail">
        ///     A native XCore instruction detail.
        /// </param>
        /// <returns>
        ///     An array of XCore operands.
        /// </returns>
        internal static XCoreOperand[] Create(CapstoneDisassembler disassembler, ref NativeXCoreInstructionDetail nativeInstructionDetail) {
            var operands = new XCoreOperand[nativeInstructionDetail.OperandCount];
            for (var i = 0; i < operands.Length; i++) {
                ref var nativeOperand = ref nativeInstructionDetail.Operands[i];
                operands[i] = XCoreOperand.Create(disassembler, ref nativeOperand);
            }

            return operands;
        }

        /// <summary>
        ///     Create an XCore Operand.
        /// </summary>
        /// <param name="disassembler">
        ///     A disassembler.
        /// </param>
        /// <param name="nativeOperand">
        ///     A native XCore operand.
        /// </param>
        /// <returns>
        ///     An XCore operand.
        /// </returns>
        internal static XCoreOperand Create(CapstoneDisassembler disassembler, ref NativeXCoreOperand nativeOperand) {
            return new XCoreOperandBuilder().Build(disassembler, ref nativeOperand).Create();
        }

        /// <summary>
        ///     Create an XCore Operand.
        /// </summary>
        /// <param name="builder">
        ///     A builder to initialize the object with.
        /// </param>
        internal XCoreOperand(XCoreOperandBuilder builder) {
            this._immediate = builder.Immediate;
            this._memory = builder.Memory;
            this._register = builder.Register;
            this.Type = builder.Type;
        }
    }
}