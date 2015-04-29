namespace Gee.External.Capstone.Arm64 {
    /// <summary>
    ///     Capstone ARM64 Disassembler.
    /// </summary>
    internal sealed class CapstoneArm64Disassembler : CapstoneDisassembler<Arm64Instruction, Arm64Register, Arm64InstructionGroup, Arm64InstructionDetail> {
        /// <summary>
        ///     Create a Capstone ARM64 Disassembler.
        /// </summary>
        /// <param name="mode">
        ///     The disassembler's mode.
        /// </param>
        internal CapstoneArm64Disassembler(DisassembleMode mode) : base(DisassembleArchitecture.Arm64, mode) {}

        /// <summary>
        ///     Create a Dissembled Instruction.
        /// </summary>
        /// <param name="nativeInstruction">
        ///     A native instruction.
        /// </param>
        /// <returns>
        ///     A dissembled instruction.
        /// </returns>
        protected override Instruction<Arm64Instruction, Arm64Register, Arm64InstructionGroup, Arm64InstructionDetail> CreateInstruction(NativeInstruction nativeInstruction) {
            var @object = nativeInstruction.AsArm64Instruction();

            // Get Native Instruction's Managed Independent Detail.
            //
            // Retrieves the native instruction's managed independent detail once to avoid having to allocate
            // new memory every time it is retrieved.
            var nativeIndependentInstructionDetail = nativeInstruction.ManagedIndependentDetail;
            if (nativeIndependentInstructionDetail != null) {
                @object.ArchitectureDetail = nativeInstruction.NativeArm64Detail.AsArm64InstructionDetail(@object.Id);
                @object.IndependentDetail = nativeIndependentInstructionDetail.Value.AsArm64IndependentInstructionDetail();
            }

            return @object;
        }
    }
}