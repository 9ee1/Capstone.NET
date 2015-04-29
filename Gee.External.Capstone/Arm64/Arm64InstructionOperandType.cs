namespace Gee.External.Capstone.Arm64 {
    /// <summary>
    ///     ARM64 Instruction Operand Type.
    /// </summary>
    public enum Arm64InstructionOperandType {
        /// <summary>
        ///     Invalid Instruction Operand Type.
        /// </summary>
        Invalid = 0,

        Register,
        Immediate,
        Memory,
        FloatingPoint,
        CImmediate = 64,
        MrsRegister,
        MsrRegister,
        PState,
        SysOperation,
        PrefetchOperation,
        MemoryBarrierOperation
    }
}