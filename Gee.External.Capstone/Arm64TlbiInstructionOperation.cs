// ReSharper disable InconsistentNaming

namespace Gee.External.Capstone.Arm64 {
    /// <summary>
    ///     ARM64 TLBI Instruction Operation.
    /// </summary>
    public enum Arm64TlbiInstructionOperation {
        /// <summary>
        ///     Invalid TLBI Instruction Operation.
        /// </summary>
        Invalid = 0,

        VMALLE1IS,
        VAE1IS,
        ASIDE1IS,
        VAAE1IS,
        VALE1IS,
        VAALE1IS,
        ALLE2IS,
        VAE2IS,
        ALLE1IS,
        VALE2IS,
        VMALLS12E1IS,
        ALLE3IS,
        VAE3IS,
        VALE3IS,
        IPAS2E1IS,
        IPAS2LE1IS,
        IPAS2E1,
        IPAS2LE1,
        VMALLE1,
        VAE1,
        ASIDE1,
        VAAE1,
        VALE1,
        VAALE1,
        ALLE2,
        VAE2,
        ALLE1,
        VALE2,
        VMALLS12E1,
        ALLE3,
        VAE3,
        VALE3
    }
}