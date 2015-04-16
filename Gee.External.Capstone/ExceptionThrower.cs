using System;

namespace Gee.External.Capstone {
    /// <summary>
    ///     Exception Thrower.
    /// </summary>
    internal static class ExceptionThrower {
        /// <summary>
        ///     Throw an Exception.
        /// </summary>
        /// <param name="errorCode">
        ///     An error code.
        /// </param>
        internal static void ThrowOnOpen(DisassembleErrorCode errorCode) {
            switch (errorCode) {
                case DisassembleErrorCode.Ok:
                    break;
                case DisassembleErrorCode.OutOfMemory:
                    throw new OutOfMemoryException("Out of memory.");
                case DisassembleErrorCode.UnsupportedArchitecture:
                    throw new ArgumentException("Unsupported architecture.");
                case DisassembleErrorCode.InvalidHandle:
                    throw new ArgumentException("Invalid handle.");
                case DisassembleErrorCode.InvalidCapstone:
                    throw new ArgumentException("Invalid handle.");
                case DisassembleErrorCode.UnsupportedMode:
                    throw new ArgumentException("Unsupported mode.");
                case DisassembleErrorCode.UnsupportedOption:
                    throw new ArgumentException("Unsupported option.");
                case DisassembleErrorCode.UnavailableInstructionDetail:
                    throw new InvalidOperationException("Unavailable disassemble instruction detail.");
                case DisassembleErrorCode.UninitializedDynamicMemoryManagement:
                    throw new InvalidOperationException("Uninitialized dynamic memory management.");
            }
        }
    }
}