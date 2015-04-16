using Microsoft.Win32.SafeHandles;
using System;

namespace Gee.External.Capstone {
    /// <summary>
    ///     Safe Capstone Handle.
    /// </summary>
    public sealed class SafeCapstoneHandle : SafeHandleZeroOrMinusOneIsInvalid {
        /// <summary>
        ///     Create a Safe Capstone Handle.
        /// </summary>
        /// <param name="handle">
        ///     A pointer to a handle representing a capstone engine. Should not be a null reference.
        /// </param>
        public SafeCapstoneHandle(IntPtr handle) : base(true) {
            this.handle = handle;
        }

        /// <summary>
        ///     Release Handle.
        /// </summary>
        /// <returns>
        ///     A boolean true if the handle was released. A boolean false otherwise.
        /// </returns>
        protected override bool ReleaseHandle() {
            var resultCode = CapstoneImport.Close(ref this.handle);
            var isReleased = resultCode == (int) DisassembleErrorCode.Ok;

            return isReleased;
        }
    }
}