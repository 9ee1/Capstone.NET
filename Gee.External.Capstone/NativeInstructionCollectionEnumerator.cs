using System;
using System.Collections;
using System.Collections.Generic;

namespace Gee.External.Capstone {
    /// <summary>
    ///     Native Instruction Collection Enumerator.
    /// </summary>
    internal sealed class NativeInstructionCollectionEnumerator : IEnumerator<NativeInstruction> {
        /// <summary>
        ///     Current Native Instruction's Index.
        /// </summary>
        private int _currentIndex;

        /// <summary>
        ///     Disposed Flag.
        /// </summary>
        private bool _disposed;

        /// <summary>
        ///     Enumerator's Native Instructions.
        /// </summary>
        private readonly NativeInstruction[] _nativeInstructions;

        /// <summary>
        ///     Pointer to Native Instructions in Unmanaged Memory.
        /// </summary>
        private readonly IntPtr _pNativeInstructions;

        /// <summary>
        ///     Get Current Element.
        /// </summary>
        /// <exception cref="System.ObjectDisposedException">
        ///     Thrown if the enumerator is disposed.
        /// </exception>
        public NativeInstruction Current {
            get {
                this.CheckDisposed();
                return this._nativeInstructions[this._currentIndex];
            }
        }

        /// <summary>
        ///     Get Current Element.
        /// </summary>
        /// <exception cref="System.ObjectDisposedException">
        ///     Thrown if the enumerator is disposed.
        /// </exception>
        object IEnumerator.Current {
            get {
                return this.Current;
            }
        }

        /// <summary>
        ///     Create a Native Instruction Collection Enumerator.
        /// </summary>
        /// <param name="nativeInstructions">
        ///     An array of native instructions. Should not be a null reference.
        /// </param>
        /// <param name="pNativeInstructions">
        ///     A pointer to the array of native instructions in unmanaged memory.
        /// </param>
        internal NativeInstructionCollectionEnumerator(NativeInstruction[] nativeInstructions, IntPtr pNativeInstructions) {
            this._nativeInstructions = nativeInstructions;
            this._pNativeInstructions = pNativeInstructions;

            this._currentIndex = -1;
            this._disposed = false;
        }

        /// <summary>
        ///     Destroy Native Instruction Collection Enumerator.
        /// </summary>
        ~NativeInstructionCollectionEnumerator() {
            this.Dispose(false);
        }

        /// <summary>
        ///     Dispose Enumerator.
        /// </summary>
        public void Dispose() {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        ///     Get Next Element.
        /// </summary>
        /// <returns>
        ///     A boolean true if an element is returned. A boolean false otherwise.
        /// </returns>
        public bool MoveNext() {
            this.CheckDisposed();
            if ((this._currentIndex + 1 == this._nativeInstructions.Length)) {
                return false;
            }

            this._currentIndex++;
            return true;
        }

        /// <summary>
        ///     Reset Enumerator.
        /// </summary>
        /// <exception cref="System.ObjectDisposedException">
        ///     Thrown if the enumerator is disposed.
        /// </exception>
        public void Reset() {
            this.CheckDisposed();
            this._currentIndex = -1;
        }

        /// <summary>
        ///     Check if Enumerator is Disposed.
        /// </summary>
        /// <exception cref="System.ObjectDisposedException">
        ///     Thrown if the enumerator is disposed.
        /// </exception>
        private void CheckDisposed() {
            if (this._disposed) {
                throw new ObjectDisposedException("NativeInstructionCollectionEnumerator");
            }
        }

        /// <summary>
        ///     Dispose Enumerator
        /// </summary>
        /// <param name="disposing">
        ///     A boolean true if the enumerator is being disposed from client code. A boolean false otherwise.
        /// </param>
        private void Dispose(bool disposing) {
            if (!this._disposed) {
                var pNativeInstructionCount = (IntPtr) this._nativeInstructions.Length;
                CapstoneImport.Free(this._pNativeInstructions, pNativeInstructionCount);
            }

            this._disposed = true;
        }
    }
}