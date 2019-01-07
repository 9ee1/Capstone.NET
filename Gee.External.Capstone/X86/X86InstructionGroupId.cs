using System.Diagnostics.CodeAnalysis;

namespace Gee.External.Capstone.X86 {
    /// <summary>
    ///     X86 Instruction Group Unique Identifier.
    /// </summary>
    [SuppressMessage("ReSharper", "IdentifierTypo")]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public enum X86InstructionGroupId : byte {
        /// <summary>
        ///     Indicates an invalid, or an uninitialized, instruction group.
        /// </summary>
        Invalid = 0,
        JUMP,
        CALL,
        RET,
        INT,
        IRET,
        PRIVILEGE,
        BRANCH_RELATIVE,
        VM = 128,
        THREEDNOW, // This is "3DNOW" in the Capstone API. It is renamed here to respect C# identifier naming rules.
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
        SIXTEENBITMODE, // This is "16BITMODE" in the Capstone API. It is renamed here to respect C# identifier naming rules.
        NOT64BITMODE,
        SGX,
        DQI,
        BWI,
        PFI,
        VLX,
        SMAP,
        NOVLX,
        FPU
    }
}