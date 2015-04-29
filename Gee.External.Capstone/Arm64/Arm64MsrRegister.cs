// ReSharper disable InconsistentNaming

namespace Gee.External.Capstone.Arm64 {
    /// <summary>
    ///     ARM64 MSR Register.
    /// </summary>
    public enum Arm64MsrRegister {
        DBGDTRTX_EL0 = 0x9828,
        OSLAR_EL1 = 0x8084,
        PMSWINC_EL0 = 0xdce4,

        // Note.
        //
        // Trace Registers.

        TRCOSLAR = 0x8884,
        TRCLAR = 0x8be6,

        // Note.
        //
        // GIC V3 Registers.

        ICC_EOIR1_EL1 = 0xC661,
        ICC_EOIR0_EL1 = 0xC641,
        ICC_DIR_EL1 = 0xC659,
        ICC_SGI1R_EL1 = 0xC65D,
        ICC_ASGI1R_EL1 = 0xC65E,
        ICC_SGI0R_EL1 = 0xC65F
    }
}