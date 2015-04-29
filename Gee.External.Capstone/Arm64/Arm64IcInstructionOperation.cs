// ReSharper disable InconsistentNaming

namespace Gee.External.Capstone.Arm64 {
    /// <summary>
    ///     ARM64 IC Instruction Operation.
    /// </summary>
    public enum Arm64IcInstructionOperation {
        /// <summary>
        ///     Invalid IC Instruction Operation.
        /// </summary>
        Invalid = 0,

        IALLUIS,
        IALLU,
        IVAU
    }
}