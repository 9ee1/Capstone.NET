namespace Gee.External.Capstone.Mips {
    /// <summary>
    ///     MIPS Instruction Builder.
    /// </summary>
    internal sealed class MipsInstructionBuilder : InstructionBuilder<MipsInstructionDetail, MipsInstructionGroup, MipsInstructionGroupId, MipsInstruction, MipsInstructionId, MipsRegister, MipsRegisterId> {
        /// <summary>
        ///     Create a MIPS Instruction.
        /// </summary>
        /// <returns>
        ///     A MIPS instruction.
        /// </returns>
        internal MipsInstruction Create() {
            return new MipsInstruction(this);
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
        private protected override MipsInstructionDetail CreateDetails(CapstoneDisassembler disassembler, NativeInstructionHandle hInstruction) {
            return MipsInstructionDetail.Create(disassembler, hInstruction);
        }

        /// <summary>
        ///     Create Instruction's Unique Identifier.
        /// </summary>
        /// <param name="id">
        ///     An instruction's unique identifier.
        /// </param>
        /// <returns>
        ///     The instruction's unique identifier.
        /// </returns>
        private protected override MipsInstructionId CreateId(int id) {
            return (MipsInstructionId) id;
        }
    }
}