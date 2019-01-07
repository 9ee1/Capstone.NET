using System;

namespace Gee.External.Capstone {
    /// <summary>
    ///     Instruction Builder.
    /// </summary>
    /// <typeparam name="TDetail">
    ///     The type of the instruction's details.
    /// </typeparam>
    /// <typeparam name="TGroup">
    ///     The type of the instruction's architecture specific instruction groups.
    /// </typeparam>
    /// <typeparam name="TGroupId">
    ///     The type of the instruction's architecture specific instruction group unique identifiers.
    /// </typeparam>
    /// <typeparam name="TInstruction">
    ///     The type of the instruction.
    /// </typeparam>
    /// <typeparam name="TId">
    ///     The type of the instruction's unique identifier.
    /// </typeparam>
    /// <typeparam name="TRegister">
    ///     The type of the instruction's architecture specific registers.
    /// </typeparam>
    /// <typeparam name="TRegisterId">
    ///     The type of the instruction's architecture specific register unique identifiers.
    /// </typeparam>
    internal abstract class InstructionBuilder<TDetail, TGroup, TGroupId, TInstruction, TId, TRegister, TRegisterId>
        where TDetail : InstructionDetail<TDetail, TGroup, TGroupId, TInstruction, TId, TRegister, TRegisterId>
        where TGroup : InstructionGroup<TGroupId>
        where TGroupId : Enum
        where TInstruction : Instruction<TInstruction, TDetail, TGroup, TGroupId, TId, TRegister, TRegisterId>
        where TId : Enum
        where TRegister : Register<TRegisterId>
        where TRegisterId : Enum {
        /// <summary>
        ///     Get and Set Instruction's Address.
        /// </summary>
        internal long Address { get; private set; }

        /// <summary>
        ///     Get and Set Instruction's Machine Bytes.
        /// </summary>
        internal byte[] Bytes { get; private set; }

        /// <summary>
        ///     Get and Set Instruction's Details.
        /// </summary>
        internal TDetail Details { get; private set; }

        /// <summary>
        ///     Get and Set Instruction's Unique Identifier.
        /// </summary>
        internal TId Id { get; private set; }

        /// <summary>
        ///     Get and Set Instruction's Mnemonic Text.
        /// </summary>
        internal string Mnemonic { get; private set; }

        /// <summary>
        ///     Get and Set Instruction's Operand Text.
        /// </summary>
        internal string Operand { get; private set; }

        /// <summary>
        ///     Create an Instruction Builder.
        /// </summary>
        internal InstructionBuilder() {
            this.Address = 0;
            this.Bytes = new byte[0];
            this.Details = null;
            this.Id = default;
            this.Mnemonic = null;
            this.Operand = null;
        }

        /// <summary>
        ///     Build an Instruction.
        /// </summary>
        /// <param name="disassembler">
        ///     A disassembler.
        /// </param>
        /// <param name="hInstruction">
        ///     An instruction handle.
        /// </param>
        internal virtual void Build(CapstoneDisassembler disassembler, NativeInstructionHandle hInstruction) {
            // ...
            //
            // Throws an exception if the operation fails.
            var nativeInstruction = NativeCapstone.GetInstruction(hInstruction);

            this.Address = nativeInstruction.Address;
            this.Id = this.CreateId(nativeInstruction.Id);
            this.Mnemonic = !CapstoneDisassembler.IsDietModeEnabled ? nativeInstruction.Mnemonic : null;
            this.Operand = !CapstoneDisassembler.IsDietModeEnabled ? nativeInstruction.Operand : null;
            // ...
            //
            // ...
            SetBytes(this, ref nativeInstruction);
            SetDetails(this, disassembler, hInstruction, ref nativeInstruction);

            // <summary>
            //      Set Instruction's Machine Bytes.
            // </summary>
            void SetBytes(InstructionBuilder<TDetail, TGroup, TGroupId, TInstruction, TId, TRegister, TRegisterId> @this, ref NativeInstruction cNativeInstruction) {
                @this.Bytes = new byte[0];
                if (cNativeInstruction.Id >= 0) {
                    @this.Bytes = new byte[cNativeInstruction.Size];
                    for (var cI = 0; cI < @this.Bytes.Length; cI++) {
                        @this.Bytes[cI] = cNativeInstruction.Bytes[cI];
                    }
                }
            }

            // <summary>
            //      Set Instruction's Details.
            // </summary>
            void SetDetails(InstructionBuilder<TDetail, TGroup, TGroupId, TInstruction, TId, TRegister, TRegisterId> @this, CapstoneDisassembler cDisassembler, NativeInstructionHandle cHInstruction, ref NativeInstruction cNativeInstruction) {
                @this.Details = null;
                if (cDisassembler.EnableInstructionDetails && cNativeInstruction.Id > 0) {
                    @this.Details = @this.CreateDetails(cDisassembler, cHInstruction);
                }
            }
        }

        internal virtual void BuildInvalid(CapstoneDisassembler disassembler) {
            this.Address = 0;
            this.Id = this.CreateId(0);
            this.Mnemonic = disassembler.InvalidInstructionMnemonic;
            this.Operand = "0x";
        }

        /// <summary>
        ///     Create Instruction's Details.
        /// </summary>
        /// <param name="disassembler">
        ///     A disassembler.
        /// </param>
        /// <param name="hInstruction">
        ///     An instruction handle.
        /// </param>
        /// <returns>
        ///     The instruction's details.
        /// </returns>
        private protected abstract TDetail CreateDetails(CapstoneDisassembler disassembler, NativeInstructionHandle hInstruction);

        /// <summary>
        ///     Create Instruction's Unique Identifier.
        /// </summary>
        /// <param name="id">
        ///     An instruction's unique identifier.
        /// </param>
        /// <returns>
        ///     The instruction's unique identifier.
        /// </returns>
        private protected abstract TId CreateId(int id);
    }
}