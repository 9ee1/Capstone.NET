// ReSharper disable InconsistentNaming

namespace Gee.External.Capstone.Arm64 {
    /// <summary>
    ///     ARM64 MRS Register.
    /// </summary>
    public enum Arm64MrsRegister {
        /// <summary>
        ///     Invalid MRS Register.
        /// </summary>
        Invalid = 0,

        MDCCSR_EL0 = 0X9808,
        DBGDTRRX_EL0 = 0X9828,
        MDRAR_EL1 = 0X8080,
        OSLSR_EL1 = 0X808C,
        DBGAUTHSTATUS_EL1 = 0X83F6,
        PMCEID0_EL0 = 0XDCE6,
        PMCEID1_EL0 = 0XDCE7,
        MIDR_EL1 = 0XC000,
        CCSIDR_EL1 = 0XC800,
        CLIDR_EL1 = 0XC801,
        CTR_EL0 = 0XD801,
        MPIDR_EL1 = 0XC005,
        REVIDR_EL1 = 0XC006,
        AIDR_EL1 = 0XC807,
        DCZID_EL0 = 0XD807,
        ID_PFR0_EL1 = 0XC008,
        ID_PFR1_EL1 = 0XC009,
        ID_DFR0_EL1 = 0XC00A,
        ID_AFR0_EL1 = 0XC00B,
        ID_MMFR0_EL1 = 0XC00C,
        ID_MMFR1_EL1 = 0XC00D,
        ID_MMFR2_EL1 = 0XC00E,
        ID_MMFR3_EL1 = 0XC00F,
        ID_ISAR0_EL1 = 0XC010,
        ID_ISAR1_EL1 = 0XC011,
        ID_ISAR2_EL1 = 0XC012,
        ID_ISAR3_EL1 = 0XC013,
        ID_ISAR4_EL1 = 0XC014,
        ID_ISAR5_EL1 = 0XC015,
        ID_A64PFR0_EL1 = 0XC020,
        ID_A64PFR1_EL1 = 0XC021,
        ID_A64DFR0_EL1 = 0XC028,
        ID_A64DFR1_EL1 = 0XC029,
        ID_A64AFR0_EL1 = 0XC02C,
        ID_A64AFR1_EL1 = 0XC02D,
        ID_A64ISAR0_EL1 = 0XC030,
        ID_A64ISAR1_EL1 = 0XC031,
        ID_A64MMFR0_EL1 = 0XC038,
        ID_A64MMFR1_EL1 = 0XC039,
        MVFR0_EL1 = 0XC018,
        MVFR1_EL1 = 0XC019,
        MVFR2_EL1 = 0XC01A,
        RVBAR_EL1 = 0XC601,
        RVBAR_EL2 = 0XE601,
        RVBAR_EL3 = 0XF601,
        ISR_EL1 = 0XC608,
        CNTPCT_EL0 = 0XDF01,
        CNTVCT_EL0 = 0XDF02,

        // Note.
        //
        // Trace Registers.

        TRCSTATR = 0X8818,
        TRCIDR8 = 0X8806,
        TRCIDR9 = 0X880E,
        TRCIDR10 = 0X8816,
        TRCIDR11 = 0X881E,
        TRCIDR12 = 0X8826,
        TRCIDR13 = 0X882E,
        TRCIDR0 = 0X8847,
        TRCIDR1 = 0X884F,
        TRCIDR2 = 0X8857,
        TRCIDR3 = 0X885F,
        TRCIDR4 = 0X8867,
        TRCIDR5 = 0X886F,
        TRCIDR6 = 0X8877,
        TRCIDR7 = 0X887F,
        TRCOSLSR = 0X888C,
        TRCPDSR = 0X88AC,
        TRCDEVAFF0 = 0X8BD6,
        TRCDEVAFF1 = 0X8BDE,
        TRCLSR = 0X8BEE,
        TRCAUTHSTATUS = 0X8BF6,
        TRCDEVARCH = 0X8BFE,
        TRCDEVID = 0X8B97,
        TRCDEVTYPE = 0X8B9F,
        TRCPIDR4 = 0X8BA7,
        TRCPIDR5 = 0X8BAF,
        TRCPIDR6 = 0X8BB7,
        TRCPIDR7 = 0X8BBF,
        TRCPIDR0 = 0X8BC7,
        TRCPIDR1 = 0X8BCF,
        TRCPIDR2 = 0X8BD7,
        TRCPIDR3 = 0X8BDF,
        TRCCIDR0 = 0X8BE7,
        TRCCIDR1 = 0X8BEF,
        TRCCIDR2 = 0X8BF7,
        TRCCIDR3 = 0X8BFF,

        // Note.
        //
        // GIC V3 Registers.

        ICC_IAR1_EL1 = 0XC660,
        ICC_IAR0_EL1 = 0XC640,
        ICC_HPPIR1_EL1 = 0XC662,
        ICC_HPPIR0_EL1 = 0XC642,
        ICC_RPR_EL1 = 0XC65B,
        ICH_VTR_EL2 = 0XE659,
        ICH_EISR_EL2 = 0XE65B,
        ICH_ELSR_EL2 = 0XE65D
    }
}