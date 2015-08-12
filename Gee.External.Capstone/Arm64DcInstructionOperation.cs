// ReSharper disable InconsistentNaming

namespace Gee.External.Capstone.Arm64 {
    /// <summary>
    ///     ARM64 DC Instruction Operation.
    /// </summary>
    public enum Arm64DcInstructionOperation {
        /// <summary>
        ///     Invalid DC Instruction Operation.
        /// </summary>
        Invalid = 0,

        ZVA,
        IVAC,
        ISW,
        CVAC,
        CSW,
        CVAU,
        CIVAC,
        CISW
    }
}