namespace Gee.External.Capstone.Arm64 {
    /// <summary>
    ///     ARM64 Capstone Disassembler.
    /// </summary>
    public sealed class CapstoneArm64Disassembler : CapstoneDisassembler<Arm64DisassembleMode, Arm64Instruction, Arm64InstructionDetail, Arm64InstructionGroup, Arm64InstructionGroupId, Arm64InstructionId, Arm64Register, Arm64RegisterId> {
        /// <summary>
        ///     Create an ARM64 Disassembler.
        /// </summary>
        /// <param name="disassembleMode"></param>
        public CapstoneArm64Disassembler(Arm64DisassembleMode disassembleMode) : base(DisassembleArchitecture.Arm64, disassembleMode) { }

        private protected override Arm64Instruction CreateInstruction(NativeInstructionHandle hInstruction) {
            // ...
            //
            // Throws an exception if the operation fails.
            var instruction = Arm64Instruction.Create(this, hInstruction);
            return instruction;
        }
    }
}