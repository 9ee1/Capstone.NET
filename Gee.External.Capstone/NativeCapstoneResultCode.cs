using System.Diagnostics.CodeAnalysis;

namespace Gee.External.Capstone {
    /// <summary>
    ///     Native Capstone Result Code.
    /// </summary>
    [SuppressMessage("ReSharper", "IdentifierTypo")]
    internal enum NativeCapstoneResultCode {
        /// <summary>
        ///     Indicates an operation completed successfully.
        /// </summary>
        Ok = 0,
        OutOfMemory,
        UnsupportedArchitecture,
        InvalidHandle1,
        InvalidHandle2,
        UnsupportedDissembleMode,
        InvalidOption,
        UnsupportedInstructionDetail,
        UninitializedMemoryManagement,
        UnsupportedVersion,
        UnSupportedDietModeOperation,
        UnsupportedSkipDataModeOperation,
        UnSupportedX86AttSyntax,
        UnSupportedX86IntelSyntax,
        UnSupportedX86MasmSyntax
    }
}