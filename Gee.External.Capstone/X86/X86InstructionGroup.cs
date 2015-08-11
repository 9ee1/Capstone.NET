// ReSharper disable InconsistentNaming

namespace Gee.External.Capstone.X86 {
    /// <summary>
    ///     X86 Instruction Group.
    /// </summary>
    public enum X86InstructionGroup {
        /// <summary>
        ///     Invalid Instruction Group.
        /// </summary>
        Invalid = 0,

        JUMP = IndependentInstructionGroup.JUMP,
        CALL = IndependentInstructionGroup.CALL,
        RET = IndependentInstructionGroup.RET,
        INT = IndependentInstructionGroup.INT,
        IRET = IndependentInstructionGroup.IRET,

        VM = 128,
        GROUP3DNOW,
        AES,
        ADX,
        AVX,
        AVX2,
        AVX512,
        BMI,
        BMI2,
        CMOV,
        F16C,
        FMA,
        FMA4,
        FSGSBASE,
        HLE,
        MMX,
        MODE32,
        MODE64,
        RTM,
        SHA,
        SSE1,
        SSE2,
        SSE3,
        SSE41,
        SSE42,
        SSE4A,
        SSSE3,
        PCLMUL,
        XOP,
        CDI,
        ERI,
        TBM,
        GROUP16BITMODE,
        NOT64BITMODE,
        SGX,
        DQI,
        BWI,
        PFI,
        VLX,
        SMAP,
        NOVLX
    }
}