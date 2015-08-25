using System;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;

namespace Gee.External.Capstone {
    /// <summary>
    ///     Native Capstone Disassembler.
    /// </summary>
    public static class NativeCapstone {
        /// <summary>
        ///     Capstone Assembly File Name.
        /// </summary>
        private const string CapstoneAssemblyFileName = "capstone.dll";

        /// <summary>
        ///     Proxy Assembly File Name.
        /// </summary>
        private const string ProxyAssemblyFileName = "Gee.External.Capstone.Proxy.dll";

        /// <summary>
        ///     X64 Directory Name.
        /// </summary>
        private const string X64DirectoryName = "X64";

        /// <summary>
        ///     X86 Directory Name.
        /// </summary>
        private const string X86DirectoryName = "X86";

        /// <summary>
        ///     Create a Capstone Disassembler.
        /// </summary>
        /// <param name="architecture">
        ///     The disassemble architecture.
        /// </param>
        /// <param name="mode">
        ///     The disassemble mode.
        /// </param>
        /// <returns>
        ///     A Capstone handle.
        /// </returns>
        /// <exception cref="System.InvalidOperationException">
        ///     Thrown if a Capstone disassembler could not be created.
        /// </exception>
        public static SafeCapstoneHandle Create(DisassembleArchitecture architecture, DisassembleMode mode) {
            var iArchitecture = (int) architecture;
            var iMode = (int) mode;
            var pHandle = IntPtr.Zero;

            // Open Capstone Handle.
            //
            // ...
            var resultCode = CapstoneImport.Open(iArchitecture, iMode, ref pHandle);
            if (resultCode != (int) DisassembleErrorCode.Ok) {
                throw new InvalidOperationException("Unable to create a Capstone disassembler.");
            }

            var handle = new SafeCapstoneHandle(pHandle);
            return handle;
        }

        /// <summary>
        ///     Disable Disassemble Details Option.
        /// </summary>
        /// <param name="handle">
        ///     A Capstone handle. Should not be a null reference.
        /// </param>
        /// <exception cref="System.InvalidOperationException">
        ///     Thrown if the disassemble details option could not be disabled.
        /// </exception>
        public static void DisableDetailOption(SafeCapstoneHandle handle) {
            NativeCapstone.SetDisassembleDetails(handle, false);
        }

        /// <summary>
        ///     Disassemble Binary Code.
        /// </summary>
        /// <param name="handle">
        ///     A Capstone handle. Should not be a null reference.
        /// </param>
        /// <param name="code">
        ///     A collection of bytes representing the binary code to disassemble. Should not be a null reference.
        /// </param>
        /// <param name="count">
        ///     The number of instructions to disassemble. A 0 indicates all instructions should be disassembled.
        /// </param>
        /// <param name="startingAddress">
        ///     The address of the first instruction in the collection of bytes to disassemble.
        /// </param>
        /// <returns>
        ///     A native instruction handle.
        /// </returns>
        /// <exception cref="System.InvalidOperationException">
        ///     Thrown if the binary code could not be disassembled.
        /// </exception>
        public static SafeNativeInstructionHandle Disassemble(SafeCapstoneHandle handle, byte[] code, int count, long startingAddress) {
            // Copy Code to Unmanaged Memory.
            //
            // ...
            var pCode = MarshalExtension.AllocHGlobal<byte>(code.Length);
            Marshal.Copy(code, 0, pCode, code.Length);

            var pCount = (IntPtr) count;
            var pHandle = handle.DangerousGetHandle();
            var pInstructions = IntPtr.Zero;
            var pSize = (IntPtr) code.Length;
            var uStartingAddress = (ulong) startingAddress;

            // Disassemble Binary Code.
            //
            // ...
            var pResultCode = CapstoneImport.Disassemble(pHandle, pCode, pSize, uStartingAddress, pCount, ref pInstructions);
            if (pResultCode == IntPtr.Zero) {
                throw new InvalidOperationException("Unable to disassemble binary code.");
            }

            var iResultCode = (int) pResultCode;
            var instructions = MarshalExtension.PtrToStructure<NativeInstruction>(pInstructions, iResultCode);

            // Free Unmanaged Memory.
            //
            // Avoid a memory leak.
            Marshal.FreeHGlobal(pCode);

            var instructionHandle = new SafeNativeInstructionHandle(instructions, pInstructions, pResultCode);
            return instructionHandle;
        }

        /// <summary>
        ///     Disassemble Binary Code.
        /// </summary>
        /// <remarks>
        ///     Convenient method to disassemble binary code with the assumption that the address of the first
        ///     instruction in the collection of bytes to disassemble is 0x1000. Equivalent to calling
        ///     <c>NativeCapstone.Disassemble(handle, code, 0x1000, count)</c>.
        /// </remarks>
        /// <param name="handle">
        ///     A Capstone handle. Should not be a null reference.
        /// </param>
        /// <param name="code">
        ///     A collection of bytes representing the binary code to disassemble. Should not be a null reference.
        /// </param>
        /// <param name="count">
        ///     The number of instructions to disassemble. A 0 indicates all instructions should be disassembled.
        /// </param>
        /// <returns>
        ///     A native instruction handle.
        /// </returns>
        /// <exception cref="System.InvalidOperationException">
        ///     Thrown if the binary code could not be disassembled.
        /// </exception>
        public static SafeNativeInstructionHandle Disassemble(SafeCapstoneHandle handle, byte[] code, int count) {
            var instructionHandle = NativeCapstone.Disassemble(handle, code, 0x1000, count);
            return instructionHandle;
        }

        /// <summary>
        ///     Disassemble All Binary Code.
        /// </summary>
        /// <param name="handle">
        ///     A Capstone handle. Should not be a null reference.
        /// </param>
        /// <param name="code">
        ///     A collection of bytes representing the binary code to disassemble. Should not be a null reference.
        /// </param>
        /// <param name="startingAddress">
        ///     The address of the first instruction in the collection of bytes to disassemble.
        /// </param>
        /// <returns>
        ///     A native instruction handle.
        /// </returns>
        /// <exception cref="System.InvalidOperationException">
        ///     Thrown if the binary code could not be disassembled.
        /// </exception>
        public static SafeNativeInstructionHandle DisassembleAll(SafeCapstoneHandle handle, byte[] code, long startingAddress) {
            var instructionHandle = NativeCapstone.Disassemble(handle, code, 0, startingAddress);
            return instructionHandle;
        }

        /// <summary>
        ///     Disassemble All Binary Code.
        /// </summary>
        /// <remarks>
        ///     Convenient method to disassemble binary code with the assumption that the address of the first
        ///     instruction in the collection of bytes to disassemble is 0x1000. Equivalent to calling
        ///     <c>NativeCapstone.DisassembleAll(handle, code, 0x1000)</c>.
        /// </remarks>
        /// <param name="handle">
        ///     A Capstone handle. Should not be a null reference.
        /// </param>
        /// <param name="code">
        ///     A collection of bytes representing the binary code to disassemble. Should not be a null reference.
        /// </param>
        /// <returns>
        ///     A native instruction handle.
        /// </returns>
        /// <exception cref="System.InvalidOperationException">
        ///     Thrown if the binary code could not be disassembled.
        /// </exception>
        public static SafeNativeInstructionHandle DisassembleAll(SafeCapstoneHandle handle, byte[] code) {
            var instructions = NativeCapstone.DisassembleAll(handle, code, 0x1000);
            return instructions;
        }

        /// <summary>
        ///     Enable ATT Disassemble Syntax Option.
        /// </summary>
        /// <param name="handle">
        ///     A Capstone handle. Should not be a null reference.
        /// </param>
        /// <exception cref="System.InvalidOperationException">
        ///     Thrown if the disassemble syntax option could not be set.
        /// </exception>
        public static void EnableAttDisassembleSyntaxOption(SafeCapstoneHandle handle) {
            NativeCapstone.SetDisassembleSyntaxOption(handle, DisassembleSyntaxOptionValue.Att);
        }

        /// <summary>
        ///     Enable Disassemble Details Option.
        /// </summary>
        /// <param name="handle">
        ///     A Capstone handle. Should not be a null reference.
        /// </param>
        /// <exception cref="System.InvalidOperationException">
        ///     Thrown if the disassemble details option could not be enabled.
        /// </exception>
        public static void EnableDisassembleDetails(SafeCapstoneHandle handle) {
            NativeCapstone.SetDisassembleDetails(handle, true);
        }

        /// <summary>
        ///     Enable Default Disassemble Syntax Option.
        /// </summary>
        /// <param name="handle">
        ///     A Capstone handle. Should not be a null reference.
        /// </param>
        /// <exception cref="System.InvalidOperationException">
        ///     Thrown if the disassemble syntax option could not be set.
        /// </exception>
        public static void EnableDefaultDisassembleSyntaxOption(SafeCapstoneHandle handle) {
            NativeCapstone.SetDisassembleSyntaxOption(handle, DisassembleSyntaxOptionValue.Default);
        }

        /// <summary>
        ///     Enable Intel Disassemble Syntax Option.
        /// </summary>
        /// <param name="handle">
        ///     A Capstone handle. Should not be a null reference.
        /// </param>
        /// <exception cref="System.InvalidOperationException">
        ///     Thrown if the disassemble syntax option could not be set.
        /// </exception>
        public static void EnableIntelDisassembleSyntaxOption(SafeCapstoneHandle handle) {
            NativeCapstone.SetDisassembleSyntaxOption(handle, DisassembleSyntaxOptionValue.Intel);
        }

        /// <summary>
        ///     Load Capstone and Proxy Assemblies.
        /// </summary>
        /// <remarks>
        ///     Conveniently loads the Capstone and proxy assemblies in a platform independent manner. The calling
        ///     process' platform is determined and the path to the Capstone and proxy assemblies is resolved to
        ///     predefined directories relative to the calling process' load path. This allows both the X64 and X86
        ///     versions of Capstone to be supported. To have any impact, this function should be invoked before any
        ///     Capstone function is invoked, ideally on application startup when the calling process launches.
        /// </remarks>
        public static void LoadAssemblies() {
            // Initialize Platform Directory Name.
            //
            // Assume the current process is an X86 process unless the runtime says otherwise.
            var platformDirectoryName = NativeCapstone.X86DirectoryName;
            if (Environment.Is64BitProcess) {
                platformDirectoryName = NativeCapstone.X64DirectoryName;
            }

            var thisAssembly = Assembly.GetCallingAssembly();
            var thisAssemblyDirectoryPath = AppDomain.CurrentDomain.BaseDirectory;
            if (thisAssemblyDirectoryPath != null) {
                // Initialize File Paths for Libraries.
                //
                // ...
                var capstoneAssemblyFilePath = Path.Combine(thisAssemblyDirectoryPath, platformDirectoryName, NativeCapstone.CapstoneAssemblyFileName);
                var proxyAssemblyFilePath = Path.Combine(thisAssemblyDirectoryPath, platformDirectoryName, NativeCapstone.ProxyAssemblyFileName);

                // Load Capstone and Proxy Libraries.
                //
                // Some error checking should probably be added here, to make sure the libraries were loaded
                // correctly.Though, technically, if the libraries were not loaded correctly for whatever reason,
                // there is very little that can be done anyway and the application will crash either way.
                AssemblyImport.LoadLibrary(capstoneAssemblyFilePath);
                AssemblyImport.LoadLibrary(proxyAssemblyFilePath);
            }
        }

        /// <summary>
        ///     Set Disassemble Details Option.
        /// </summary>
        /// <param name="handle">
        ///     A Capstone handle. Should not be a null reference.
        /// </param>
        /// <param name="flag">
        ///     A flag indicating whether to disable or enable the disassemble details option.
        /// </param>
        /// <exception cref="System.InvalidOperationException">
        ///     Thrown if the disassemble details option could not be set.
        /// </exception>
        public static void SetDisassembleDetails(SafeCapstoneHandle handle, bool flag) {
            var pHandle = handle.DangerousGetHandle();
            const int iOption = (int) DisassembleOptionType.Detail;
            var value = flag ? (IntPtr) DisassembleOptionValue.On : (IntPtr) DisassembleOptionValue.Off;

            // Set Disassemble Option.
            //
            // ...
            var resultCode = CapstoneImport.SetOption(pHandle, iOption, value);
            if (resultCode != (int) DisassembleErrorCode.Ok) {
                throw new InvalidOperationException("Unable to set disassemble details option.");
            }
        }

        /// <summary>
        ///     Set Disassemble Syntax Option.
        /// </summary>
        /// <param name="handle">
        ///     A Capstone handle. Should not be a null reference.
        /// </param>
        /// <param name="value">
        ///     A syntax option value.
        /// </param>
        /// <exception cref="System.InvalidOperationException">
        ///     Thrown if the disassemble syntax option could not be set.
        /// </exception>
        public static void SetDisassembleSyntaxOption(SafeCapstoneHandle handle, DisassembleSyntaxOptionValue value) {
            var pHandle = handle.DangerousGetHandle();
            const int iOption = (int) DisassembleOptionType.Syntax;

            // Set Disassemble Option.
            //
            // ...
            var resultCode = CapstoneImport.SetOption(pHandle, iOption, (IntPtr) value);
            if (resultCode != (int) DisassembleErrorCode.Ok) {
                throw new InvalidOperationException("Unable to set disassemble syntax option.");
            }
        }

        /// <summary>
        ///     Set Disassemble Mode Option.
        /// </summary>
        /// <param name="handle">
        ///     A Capstone handle. Should not be a null reference.
        /// </param>
        /// <param name="mode">
        ///     A disassemble mode.
        /// </param>
        /// <exception cref="System.InvalidOperationException">
        ///     Thrown if the disassemble mode option could not be set.
        /// </exception>
        public static void SetDisassembleModeOption(SafeCapstoneHandle handle, DisassembleMode mode) {
            var pHandle = handle.DangerousGetHandle();
            const int iOption = (int) DisassembleOptionType.Mode;

            // Set Disassemble Option.
            //
            // ...
            var resultCode = CapstoneImport.SetOption(pHandle, iOption, (IntPtr) mode);
            if (resultCode != (int) DisassembleErrorCode.Ok) {
                throw new InvalidOperationException("Unable to set disassemble mode option.");
            }
        }
    }
}