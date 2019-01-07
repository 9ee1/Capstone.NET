namespace Gee.External.Capstone.Arm {
    public sealed class CapstoneArmDisassembler : CapstoneDisassembler<ArmDisassembleMode, ArmInstruction, ArmInstructionDetail, ArmInstructionGroup, ArmInstructionGroupId, ArmInstructionId, ArmRegister, ArmRegisterId> {
        public CapstoneArmDisassembler(ArmDisassembleMode disassembleMode) : base(DisassembleArchitecture.Arm, disassembleMode) { }

        private protected override ArmInstruction CreateInstruction(NativeInstructionHandle hInstruction) {
            // ...
            //
            // Throws an exception if the operation fails.
            var instruction = ArmInstruction.Create(this, hInstruction);
            return instruction;
        }
    }
}