using System;
using System.Runtime.InteropServices;

namespace Gee.External.Capstone {
    /// <summary>
    ///     Assembly Import.
    /// </summary>
    internal static class AssemblyImport {
        /// <summary>
        ///     Load a Library in The Address Space of The Calling Process.
        /// </summary>
        /// <param name="filePath">
        ///     An absolute file path to the module to load.
        /// </param>
        /// <returns>
        ///     A pointer to the loaded library. An <c>IntPtr.Zero</c> indicates the library was not loaded.
        /// </returns>
        /// <see cref="https://msdn.microsoft.com/en-us/library/windows/desktop/ms684175(v=vs.85).aspx"/>
        [DllImport("Kernel32.dll", CallingConvention = CallingConvention.Winapi, CharSet = CharSet.Ansi, EntryPoint = "LoadLibrary", SetLastError = true)]
        internal static extern IntPtr LoadLibrary(string filePath);
    }
}