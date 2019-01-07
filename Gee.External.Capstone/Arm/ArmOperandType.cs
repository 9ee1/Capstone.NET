namespace Gee.External.Capstone.Arm {
    /// <summary>
    ///     ARM Operand Type.
    /// </summary>
    public enum ArmOperandType {
        /// <summary>
        ///     Indicates an invalid, or an uninitialized, operand type.
        /// </summary>
        Invalid = 0,
        Register,
        Immediate,
        Memory,
        FloatingPoint,
        CImmediate = 64,
        PImmediate,
        SetEndOperation,
        SystemRegister
    }
}