namespace Gee.External.Capstone {
    /// <summary>
    ///     Capstone X86 Disassembler.
    /// </summary>
    internal sealed class CapstoneX86Disassembler : CapstoneDisassembler<X86Instruction, X86Register, X86InstructionGroup, X86InstructionDetail> {
        /// <summary>
        ///     Create a Capstone X86 Disassembler.
        /// </summary>
        /// <param name="mode">
        ///     The disassembler's mode.
        /// </param>
        internal CapstoneX86Disassembler(DisassembleMode mode) : base(DisassembleArchitecture.X86, mode) {}

        /// <summary>
        ///     Create a Dissembled Instruction.
        /// </summary>
        /// <param name="nativeInstruction">
        ///     A native instruction.
        /// </param>
        /// <returns>
        ///     A dissembled instruction.
        /// </returns>
        protected override Instruction<X86Instruction, X86Register, X86InstructionGroup, X86InstructionDetail> CreateInstruction(NativeInstruction nativeInstruction) {
            var @object = nativeInstruction.AsX86Instruction();

            // Get Native Instruction's Managed Independent Detail.
            //
            // Retrieves the native instruction's managed independent detail once to avoid having to allocate
            // new memory every time it is retrieved.
            var nativeIndependentInstructionDetail = nativeInstruction.ManagedIndependentDetail;
            if (nativeIndependentInstructionDetail != null) {
                @object.ArchitectureDetail = nativeInstruction.NativeX86Detail.AsX86InstructionDetail();
                @object.IndependentDetail = nativeIndependentInstructionDetail.Value.AsX86IndependentInstructionDetail();
            }

            return @object;
        }
    }
}