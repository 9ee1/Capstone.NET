namespace Gee.External.Capstone.Arm {
    /// <summary>
    ///     Capstone ARM Disassembler.
    /// </summary>
    internal sealed class CapstoneArmDisassembler : CapstoneDisassembler<ArmInstruction, ArmRegister, ArmInstructionGroup, ArmInstructionDetail> {
        /// <summary>
        ///     Create a Capstone ARM Disassembler.
        /// </summary>
        /// <param name="mode">
        ///     The disassembler's mode.
        /// </param>
        internal CapstoneArmDisassembler(DisassembleMode mode) : base(DisassembleArchitecture.Arm, mode) {}

        /// <summary>
        ///     Create a Dissembled Instruction.
        /// </summary>
        /// <param name="nativeInstruction">
        ///     A native instruction.
        /// </param>
        /// <returns>
        ///     A dissembled instruction.
        /// </returns>
        protected override Instruction<ArmInstruction, ArmRegister, ArmInstructionGroup, ArmInstructionDetail> CreateInstruction(NativeInstruction nativeInstruction) {
            var @object = nativeInstruction.AsArmInstruction();

            // Get Native Instruction's Managed Independent Detail.
            //
            // Retrieves the native instruction's managed independent detail once to avoid having to allocate
            // new memory every time it is retrieved.
            var nativeIndependentInstructionDetail = nativeInstruction.ManagedIndependentDetail;
            if (nativeIndependentInstructionDetail != null) {
                @object.ArchitectureDetail = nativeInstruction.NativeArmDetail.AsArmInstructionDetail();
                @object.IndependentDetail = nativeIndependentInstructionDetail.Value.AsArmIndependentInstructionDetail();
            }

            return @object;
        }
    }
}