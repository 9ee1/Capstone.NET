using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Gee.External.Capstone {
    /// <summary>
    ///     Safe Native Instruction Handle.
    /// </summary>
    /// <remarks>
    ///     Represents a safe handle to a collection of native instructions copied from unmanaged memory to managed
    ///     memory. A managed native instruction has a pointer to unmanaged memory that has to be freed after the
    ///     instruction has been processed by application code to avoid memory leaks. A safe handle ensures that
    ///     memory is eventually freed automatically if application code fails to free it explicitly.
    /// </remarks>
    public sealed class SafeNativeInstructionHandle : SafeHandleZeroOrMinusOneIsInvalid {
        /// <summary>
        ///     Instruction Count.
        /// </summary>
        private readonly IntPtr _instructionCount;

        /// <summary>
        ///     Instructions.
        /// </summary>
        private IEnumerable<NativeInstruction> _instructions;

        /// <summary>
        ///     Get Instructions.
        /// </summary>
        public IEnumerable<NativeInstruction> Instructions {
            get {
                return this._instructions;
            }
        }

        /// <summary>
        ///     Get Instruction Count.
        /// </summary>
        /// <value>
        ///     A platform specific integer representing the number of disassembled instructions in unmanaged memory.
        /// </value>
        internal IntPtr InstructionCount {
            get {
                return this._instructionCount;
            }
        }

        /// <summary>
        ///     Get Instruction Pointer.
        /// </summary>
        /// <value>
        ///     A pointer to disassembled instructions in unmanaged memory.
        /// </value>
        internal IntPtr InstructionPointer {
            get {
                return this.handle;
            }
        }

        /// <summary>
        ///     Create a Safe Native Instruction Handle.
        /// </summary>
        /// <param name="instructions">
        ///     A collection of instructions. Should not be a null reference.
        /// </param>
        /// <param name="pInstructions">
        ///     A pointer to disassembled instructions in unmanaged memory.
        /// </param>
        /// <param name="instructionCount">
        ///     A platform specific integer representing the number of disassembled instructions in unmanaged memory.
        /// </param>
        public SafeNativeInstructionHandle(IEnumerable<NativeInstruction> instructions, IntPtr pInstructions, IntPtr instructionCount) : base(true) {
            this._instructions = instructions;
            this.handle = pInstructions;
            this._instructionCount = instructionCount;
        }

        /// <summary>
        ///     Release Handle.
        /// </summary>
        /// <returns>
        ///     A boolean true if the handle was released. A boolean false otherwise.
        /// </returns>
        protected override bool ReleaseHandle() {
            CapstoneImport.Free(this.InstructionPointer, this._instructionCount);

            // Empty Instructions.
            //
            // ...
            this._instructions = Enumerable.Empty<NativeInstruction>();
            return true;
        }
    }
}