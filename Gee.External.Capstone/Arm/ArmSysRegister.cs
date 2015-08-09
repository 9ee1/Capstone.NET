using System;
using System.Diagnostics.CodeAnalysis;

#pragma warning disable 1591

namespace Gee.External.Capstone.Arm {
    /// <summary>
    ///     ARM SYS Register.
    /// </summary>
    [Flags]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    [SuppressMessage("ReSharper", "IdentifierTypo")]
    public enum ArmSysRegister {
        /// <summary>
        ///     Invalid Register.
        /// </summary>
        Invalid = 0,

        // Note.
        //
        // These registers can be ORed.

        SPSR_C = 1,
        SPSR_X = 2,
        SPSR_S = 4,
        SPSR_F = 8,

        // Note.
        //
        // These registers can be ORed.

        CPSR_C = 16,
        CPSR_X = 32,
        CPSR_S = 64,
        CPSR_F = 128,

        // Note.
        //
        // Independent registers.

        APSR = 256,
        APSR_G,
        APSR_NZCVQ,
        APSR_NZCVQG,
        IAPSR,
        IAPSR_G,
        IAPSR_NZCVQG,
        EAPSR,
        EAPSR_G,
        EAPSR_NZCVQG,
        XPSR,
        XPSR_G,
        XPSR_NZCVQG,
        IPSR,
        EPSR,
        IEPSR,
        MSP,
        PSP,
        PRIMASK,
        BASEPRI,
        BASEPRI_MAX,
        FAULTMASK,
        CONTROL
    }
}