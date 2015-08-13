using System;
using System.Collections;
using System.Collections.Generic;

namespace Gee.External.Capstone {
    /// <summary>
    ///     Native Instruction Collection.
    /// </summary>
    [Obsolete("Deprecated.")]
    internal sealed class NativeInstructionCollection : IEnumerable<NativeInstruction> {
        /// <summary>
        ///     Native Instructions.
        /// </summary>
        private readonly NativeInstruction[] _nativeInstructions;

        /// <summary>
        ///     Pointer to Native Instructions in Unmanaged Memory.
        /// </summary>
        private readonly IntPtr _pNativeInstructions;

        /// <summary>
        ///     Create a Native Instruction Collection.
        /// </summary>
        /// <param name="nativeInstructions">
        ///     An array of native instructions. Should not be a null reference.
        /// </param>
        /// <param name="pNativeInstructions">
        ///     A pointer to the array of native instructions in unmanaged memory.
        /// </param>
        internal NativeInstructionCollection(NativeInstruction[] nativeInstructions, IntPtr pNativeInstructions) {
            this._nativeInstructions = nativeInstructions;
            this._pNativeInstructions = pNativeInstructions;
        }

        /// <summary>
        ///     Get Enumerator.
        /// </summary>
        /// <returns>
        ///     An enumerator.
        /// </returns>
        public IEnumerator<NativeInstruction> GetEnumerator() {
            return new NativeInstructionCollectionEnumerator(this._nativeInstructions, this._pNativeInstructions);
        }

        /// <summary>
        ///     Get Enumerator.
        /// </summary>
        /// <returns>
        ///     An enumerator.
        /// </returns>
        IEnumerator IEnumerable.GetEnumerator() {
            return this.GetEnumerator();
        }
    }
}