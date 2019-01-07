namespace Gee.External.Capstone.Arm64 {
    /// <summary>
    ///     ARM64 Operand Type.
    /// </summary>
    public enum Arm64OperandType {
        /// <summary>
        ///     Indicates an invalid, or an uninitialized, operand type.
        /// </summary>
        Invalid = 0,
        Register,
        Immediate,
        Memory,
        FloatingPoint,
        CImmediate = 64,
        MrsRegister,
        MsrRegister,
        PStateField,
        System,
        PrefetchOperation,
        BarrierOperation,

        /// <summary>
        ///     Indicates an Address Translation (AT) operation.
        /// </summary>
        AtOperation = int.MaxValue * -1,

        /// <summary>
        ///     Indicates a Data Cache (DC) operation.
        /// </summary>
        DcOperation = (int.MaxValue - 1) * -1,

        /// <summary>
        ///     Indicates an Instruction Cache (IC) operation.
        /// </summary>
        IcOperation = (int.MaxValue - 2) * -1,

        /// <summary>
        ///     Indicates a Translation Lookaside Buffer (TLBI) operation.
        /// </summary>
        TlbiOperation = (int.MaxValue - 3) * -1
    }
}