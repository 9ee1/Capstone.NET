namespace Gee.External.Capstone;

/// <summary>
///     Represents the result codes that can be returned by the methods defined by
///     <see cref="NativeCapstoneImport" />.
/// </summary>
/// <see href="https://github.com/capstone-engine/capstone/blob/1d230532840a37ac032c6ab80128238fc930c6c1/include/capstone/capstone.h#L361" />
internal enum NativeCapstoneResultCode {
    /// <summary>
    ///     Indicates an operation completed successfully. This member is equivalent to <c>CS_ERR_OK</c> in the
    ///     Capstone API.
    /// </summary>
    Ok = 0,

    /// <summary>
    ///     Indicates an operation failed because sufficient memory could not be allocated. This member is
    ///     equivalent to <c>CS_ERR_MEM</c> in the Capstone API.
    /// </summary>
    OutOfMemory,

    /// <summary>
    ///     Indicates a disassemble architecture is unsupported. This member is equivalent to <c>CS_ERR_ARCH</c>
    ///     in the Capstone API.
    /// </summary>
    UnsupportedDisassembleArchitecture,
    InvalidHandle1,
    InvalidHandle2,

    /// <summary>
    ///     Indicates a disassemble mode is unsupported. This member is equivalent to <c>CS_ERR_MODE</c> in the
    ///     Capstone API.
    /// </summary>
    UnsupportedDisassembleMode,

    /// <summary>
    ///     Indicates a disassembler option is invalid. This member is equivalent to <c>CS_ERR_OPTION</c> in the
    ///     Capstone API.
    /// </summary>
    InvalidOption,

    /// <summary>
    ///     Indicates an instruction's details are unsupported because Diet Mode is enabled. This member is
    ///     equivalent to <c>CS_ERR_DETAIL</c> in the Capstone API.
    /// </summary>
    UnsupportedInstructionDetail,
    UninitializedMemoryManagement,

    /// <summary>
    ///     Indicates the loaded native Capstone library is unsupported. This member is equivalent to
    ///     <c>CS_ERR_VERSION</c> in the Capstone API.
    /// </summary>
    UnsupportedVersion,

    /// <summary>
    ///     Indicates an operation is unsupported because Diet Mode is enabled. This member is equivalent to
    ///     <c>CS_ERR_DIET</c> in the Capstone API.
    /// </summary>
    UnsupportedDietModeOperation,

    /// <summary>
    ///     Indicates an operation is unsupported because an instruction is a skipped data instruction. This
    ///     member is equivalent to <c>CS_ERR_SKIPDATA</c> in the Capstone API.
    /// </summary>
    UnsupportedSkipDataModeOperation,

    /// <summary>
    ///     Indicates <see cref="DisassembleSyntax.Att" /> is unsupported. This member is equivalent to
    ///     <c>CS_ERR_X86_ATT</c> in the Capstone API.
    /// </summary>
    UnsupportedX86AttDisassembleSyntax,

    /// <summary>
    ///     Indicates <see cref="DisassembleSyntax.Intel" /> is unsupported. This member is equivalent to
    ///     <c>CS_ERR_X86_INTEL</c> in the Capstone API.
    /// </summary>
    UnsupportedX86IntelDisassembleSyntax,

    /// <summary>
    ///     Indicates <see cref="DisassembleSyntax.Masm" /> is unsupported. This member is equivalent to
    ///     <c>CS_ERR_X86_MASM</c> in the Capstone API.
    /// </summary>
    UnsupportedX86MasmDisassembleSyntax
}