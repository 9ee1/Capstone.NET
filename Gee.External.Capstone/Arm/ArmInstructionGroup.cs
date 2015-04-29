// ReSharper disable InconsistentNaming

namespace Gee.External.Capstone.Arm {
    /// <summary>
    ///     ARM Instruction Group.
    /// </summary>
    public enum ArmInstructionGroup {
        /// <summary>
        ///     Invalid Instruction Group.
        /// </summary>
        Invalid = 0,

        JUMP = IndependentInstructionGroup.JUMP,

        CRYPTO = 128,
        DATABARRIER,
        DIVIDE,
        FPARMV8,
        MULTPRO,
        NEON,
        T2EXTRACTPACK,
        THUMB2DSP,
        TRUSTZONE,
        V4T,
        V5T,
        V5TE,
        V6,
        V6T2,
        V7,
        V8,
        VFP2,
        VFP3,
        VFP4,
        ARM,
        MCLASS,
        NOTMCLASS,
        THUMB,
        THUMB1ONLY,
        THUMB2,
        PREV8,
        FPVMLX,
        MULOPS,
        CRC,
        DPVFP,
        V6M
    }
}