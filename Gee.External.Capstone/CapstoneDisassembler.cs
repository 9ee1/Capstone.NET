using Gee.External.Capstone.Arm;
using Gee.External.Capstone.Arm64;
using Gee.External.Capstone.X86;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace Gee.External.Capstone {
    /// <summary>
    ///     Capstone Disassembler.
    /// </summary>
    public abstract class CapstoneDisassembler : IDisposable {
        /// <summary>
        ///     Disassembler's Architecture.
        /// </summary>
        private readonly DisassembleArchitecture _architecture;

        /// <summary>
        ///     Disassembler's Details Flag.
        /// </summary>
        private bool _detailsFlag;

        /// <summary>
        ///     Disposed Flag.
        /// </summary>
        private bool _disposed;

        /// <summary>
        ///     Disassembler's Handle.
        /// </summary>
        private readonly SafeCapstoneHandle _handle;

        /// <summary>
        ///     Disassembler's Mode.
        /// </summary>
        private DisassembleMode _mode;

        /// <summary>
        ///     Disassembler's Syntax.
        /// </summary>
        private DisassembleSyntaxOptionValue _syntax;

        /// <summary>
        ///     Get Disassembler's Architecture.
        /// </summary>
        public DisassembleArchitecture Architecture {
            get {
                return this._architecture;
            }
        }

        /// <summary>
        ///     Enable or Disable Disassemble Details.
        /// </summary>
        /// <exception cref="System.InvalidOperationException">
        ///     Thrown if the disassemble details could not be set.
        /// </exception>
        public bool EnableDetails {
            get {
                return this._detailsFlag;
            }
            set {
                this._detailsFlag = value;
                NativeCapstone.SetDisassembleDetails(this._handle, this._detailsFlag);
            }
        }

        /// <summary>
        ///     Get and Set Disassembler's Mode.
        /// </summary>
        /// <exception cref="System.InvalidOperationException">
        ///     Thrown if the disassembler's mode could not be set.
        /// </exception>
        public DisassembleMode Mode {
            get {
                return this._mode;
            }
            set {
                this._mode = value;
                NativeCapstone.SetDisassembleModeOption(this._handle, this._mode);
            }
        }

        /// <summary>
        ///     Get and Set Disassembler's Syntax.
        /// </summary>
        /// <exception cref="System.InvalidOperationException">
        ///     Thrown if the disassembler's syntax could not be set.
        /// </exception>
        public DisassembleSyntaxOptionValue Syntax {
            get {
                return this._syntax;
            }
            set {
                this._syntax = value;
                NativeCapstone.SetDisassembleSyntaxOption(this._handle, this._syntax);
            }
        }

        /// <summary>
        ///     Get Disassembler's Handle.
        /// </summary>
        protected SafeCapstoneHandle Handle {
            get {
                return this._handle;
            }
        }

        /// <summary>
        ///     Create an ARM Disassembler.
        /// </summary>
        /// <param name="mode">
        ///     The disassembler's mode.
        /// </param>
        /// <returns>
        ///     A capstone disassembler.
        /// </returns>
        public static CapstoneDisassembler<ArmInstruction, ArmRegister, ArmInstructionGroup, ArmInstructionDetail> CreateArmDisassembler(DisassembleMode mode) {
            var @object = new CapstoneArmDisassembler(mode);
            return @object;
        }

        /// <summary>
        ///     Create a ARM64 Disassembler.
        /// </summary>
        /// <param name="mode">
        ///     The disassembler's mode.
        /// </param>
        /// <returns>
        ///     A capstone disassembler.
        /// </returns>
        public static CapstoneDisassembler<Arm64Instruction, Arm64Register, Arm64InstructionGroup, Arm64InstructionDetail> CreateArm64Disassembler(DisassembleMode mode) {
            var @object = new CapstoneArm64Disassembler(mode);
            return @object;
        }

        /// <summary>
        ///     Create an X86 Disassembler.
        /// </summary>
        /// <param name="mode">
        ///     The disassembler's mode.
        /// </param>
        /// <returns>
        ///     A capstone disassembler.
        /// </returns>
        public static CapstoneDisassembler<X86Instruction, X86Register, X86InstructionGroup, X86InstructionDetail> CreateX86Disassembler(DisassembleMode mode) {
            var @object = new CapstoneX86Disassembler(mode);
            return @object;
        }

        /// <summary>
        ///     Create a Disassembler.
        /// </summary>
        /// <param name="architecture">
        ///     The disassembler's architecture.
        /// </param>
        /// <param name="mode">
        ///     The disassembler's mode.
        /// </param>
        protected CapstoneDisassembler(DisassembleArchitecture architecture, DisassembleMode mode) {
            this._architecture = architecture;
            this._mode = mode;

            this._handle = NativeCapstone.Create(this._architecture, this._mode);
            this.EnableDetails = false;
            this.Syntax = DisassembleSyntaxOptionValue.Default;
        }

        /// <summary>
        ///     Dispose Disassembler.
        /// </summary>
        public void Dispose() {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        ///     Dispose Disassembler.
        /// </summary>
        /// <param name="disposing">
        ///     A boolean true if the disassembler is being disposed from application code. A boolean false otherwise.
        /// </param>
        protected virtual void Dispose(bool disposing) {
            if (!this._disposed) {
                this._handle.Close();
            }

            this._disposed = true;
        }
    }

    /// <summary>
    ///     Capstone Disassembler.
    /// </summary>
    public abstract class CapstoneDisassembler<TArchitectureInstruction, TArchitectureRegister, TArchitectureGroup, TArchitectureDetail> : CapstoneDisassembler {
        /// <summary>
        ///     Create a Disassembler.
        /// </summary>
        /// <param name="architecture">
        ///     The disassembler's architecture.
        /// </param>
        /// <param name="mode">
        ///     The disassembler's mode.
        /// </param>
        protected CapstoneDisassembler(DisassembleArchitecture architecture, DisassembleMode mode) : base(architecture, mode) {}

        /// <summary>
        ///     Disassemble Binary Code.
        /// </summary>
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
        ///     A collection of dissembled instructions.
        /// </returns>
        /// <exception cref="System.InvalidOperationException">
        ///     Thrown if the binary code could not be disassembled.
        /// </exception>
        public Instruction<TArchitectureInstruction, TArchitectureRegister, TArchitectureGroup, TArchitectureDetail>[] Disassemble(byte[] code, int count, long startingAddress) {
            var nativeInstructions = NativeCapstone.Disassemble(this.Handle, code, count, startingAddress);
            var instructions = nativeInstructions
                .Instructions
                .Select(this.CreateInstruction)
                .ToArray();

            return instructions;
        }

        /// <summary>
        ///     Disassemble Binary Code.
        /// </summary>
        /// <param name="code">
        ///     A collection of bytes representing the binary code to disassemble. Should not be a null reference.
        /// </param>
        /// <param name="count">
        ///     The number of instructions to disassemble. A 0 indicates all instructions should be disassembled.
        /// </param>
        /// <returns>
        ///     A collection of dissembled instructions.
        /// </returns>
        /// <exception cref="System.InvalidOperationException">
        ///     Thrown if the binary code could not be disassembled.
        /// </exception>
        public Instruction<TArchitectureInstruction, TArchitectureRegister, TArchitectureGroup, TArchitectureDetail>[] Disassemble(byte[] code, int count) {
            var instructions = this.Disassemble(code, count, 0x1000);
            return instructions;
        }

        /// <summary>
        ///     Disassemble Binary Code.
        /// </summary>
        /// <param name="code">
        ///     A collection of bytes representing the binary code to disassemble. Should not be a null reference.
        /// </param>
        /// <param name="startingAddress">
        ///     The address of the first instruction in the collection of bytes to disassemble.
        /// </param>
        /// <returns>
        ///     A collection of dissembled instructions.
        /// </returns>
        /// <exception cref="System.InvalidOperationException">
        ///     Thrown if the binary code could not be disassembled.
        /// </exception>
        public Instruction<TArchitectureInstruction, TArchitectureRegister, TArchitectureGroup, TArchitectureDetail>[] DisassembleAll(byte[] code, long startingAddress) {
            var instructions = this.Disassemble(code, 0, startingAddress);
            return instructions;
        }

        /// <summary>
        ///     Defer Disassemble Binary Code.
        /// </summary>
        /// <param name="code">
        ///     A collection of bytes representing the binary code to disassemble. Should not be a null reference.
        /// </param>
        /// <param name="offset">
        ///     An offset to start disassembling from. A 0 indicates disassembly should start at the first byte.
        ///     Should be less than the length of the collection of bytes to disassemble.
        /// </param>
        /// <param name="startingAddress">
        ///     The address of the first instruction in the collection of bytes to disassemble.
        /// </param>
        /// <returns>
        ///     A deferred collection of dissembled instructions.
        /// </returns>
        public IEnumerable<Instruction<TArchitectureInstruction, TArchitectureRegister, TArchitectureGroup, TArchitectureDetail>> DisassembleStream(byte[] code, int offset, long startingAddress) {
            var enumerable = new DeferredInstructionEnumerable(this, code, offset, startingAddress);
            return enumerable;
        }

        /// <summary>
        ///     Disassemble Binary Code.
        /// </summary>
        /// <param name="code">
        ///     A collection of bytes representing the binary code to disassemble. Should not be a null reference.
        /// </param>
        /// <returns>
        ///     A collection of dissembled instructions.
        /// </returns>
        /// <exception cref="System.InvalidOperationException">
        ///     Thrown if the binary code could not be disassembled.
        /// </exception>
        public Instruction<TArchitectureInstruction, TArchitectureRegister, TArchitectureGroup, TArchitectureDetail>[] DisassembleAll(byte[] code) {
            var instructions = this.DisassembleAll(code, 0x1000);
            return instructions;
        }

        /// <summary>
        ///     Create a Dissembled Instruction.
        /// </summary>
        /// <param name="nativeInstruction">
        ///     A native instruction.
        /// </param>
        /// <returns>
        ///     A dissembled instruction.
        /// </returns>
        protected abstract Instruction<TArchitectureInstruction, TArchitectureRegister, TArchitectureGroup, TArchitectureDetail> CreateInstruction(NativeInstruction nativeInstruction);

        /// <summary>
        ///     Deferred Instruction Enumerable.
        /// </summary>
        /// <remarks>
        ///     Represents an enumerable that is used to support deferred enumeration of dissembled binary code. This
        ///     allows instruction-by-instruction disassembling of small ranges of code conveniently. This mode of
        ///     use is common with recursive disassemblers, which need to disassembly small chunks of code often.
        /// </remarks>
        private sealed class DeferredInstructionEnumerable : IEnumerable<Instruction<TArchitectureInstruction, TArchitectureRegister, TArchitectureGroup, TArchitectureDetail>> {
            /// <summary>
            ///     Binary Code to Disassemble.
            /// </summary>
            private readonly byte[] _code;

            /// <summary>
            ///     Disassembler.
            /// </summary>
            private readonly CapstoneDisassembler<TArchitectureInstruction, TArchitectureRegister, TArchitectureGroup, TArchitectureDetail> _disassembler;

            /// <summary>
            ///     Offset.
            /// </summary>
            private readonly int _offset;

            /// <summary>
            ///     Starting Address.
            /// </summary>
            private readonly long _startingAddress;

            /// <summary>
            ///     Create a Deferred Instruction Enumerable.
            /// </summary>
            /// <param name="disassembler">
            ///     The disassembler to use. Should not be a null reference.
            /// </param>
            /// <param name="code">
            ///     A collection of bytes representing the binary code to disassemble. Should not be a null reference.
            /// </param>
            /// <param name="offset">
            ///     An offset to start disassembling from. A 0 indicates disassembly should start at the first byte.
            ///     Should be less than the length of the collection of bytes to disassemble.
            /// </param>
            /// <param name="startingAddress">
            ///     The address of the first instruction in the collection of bytes to disassemble.
            /// </param>
            public DeferredInstructionEnumerable(CapstoneDisassembler<TArchitectureInstruction, TArchitectureRegister, TArchitectureGroup, TArchitectureDetail> disassembler, byte[] code, int offset, long startingAddress) {
                this._disassembler = disassembler;
                this._code = code;
                this._offset = offset;
                this._startingAddress = startingAddress;
            }

            /// <summary>
            ///     Get Enumerator.
            /// </summary>
            /// <returns>
            ///     An enumerator.
            /// </returns>
            public IEnumerator<Instruction<TArchitectureInstruction, TArchitectureRegister, TArchitectureGroup, TArchitectureDetail>> GetEnumerator() {
                var enumerator = new DeferredInstructionEnumerator(this._disassembler, this._code, this._offset, this._startingAddress);
                return enumerator;
            }

            /// <summary>
            ///     Get Enumerator.
            /// </summary>
            /// <returns>
            ///     An enumerator.
            /// </returns>
            IEnumerator IEnumerable.GetEnumerator() {
                var enumerator = this.GetEnumerator();
                return enumerator;
            }
        }

        /// <summary>
        ///     Deferred Instruction Enumerator.
        /// </summary>
        /// <remarks>
        ///     Represents an enumerator that is used to support deferred enumeration of dissembled binary code. This
        ///     allows instruction-by-instruction disassembling of small ranges of code conveniently. This mode of
        ///     use is common with recursive disassemblers, which need to disassembly small chunks of code often.
        /// </remarks>
        private class DeferredInstructionEnumerator : IEnumerator<Instruction<TArchitectureInstruction, TArchitectureRegister, TArchitectureGroup, TArchitectureDetail>> {
            /// <summary>
            ///     Code Size.
            /// </summary>
            private readonly int _codeSize;

            /// <summary>
            ///     Current Address.
            /// </summary>
            private ulong _currentAddress;

            /// <summary>
            ///     Current Instruction.
            /// </summary>
            private Instruction<TArchitectureInstruction, TArchitectureRegister, TArchitectureGroup, TArchitectureDetail> _currentInstruction;

            /// <summary>
            ///     Current Offset.
            /// </summary>
            private int _currentOffset;

            /// <summary>
            ///     Disassembler.
            /// </summary>
            private readonly CapstoneDisassembler<TArchitectureInstruction, TArchitectureRegister, TArchitectureGroup, TArchitectureDetail> _disassembler;

            /// <summary>
            ///     Disposed Flag.
            /// </summary>
            private bool _disposed;

            /// <summary>
            ///     Pinned Code.
            /// </summary>
            /// <remarks>
            ///     Represents a garbage collector handle to the collection of bytes representing the binary code to
            ///     disassemble. A "pinning" technique is used to pin the collection of bytes while enumerating
            ///     instead copying the data back and forth between managed and unmanaged memory.
            /// </remarks>
            private GCHandle _pinnedCode;

            /// <summary>
            ///     Created a Deferred Instruction Enumerator.
            /// </summary>
            /// <param name="disassembler">
            ///     The disassembler to use. Should not be a null reference.
            /// </param>
            /// <param name="code">
            ///     A collection of bytes representing the binary code to disassemble. Should not be a null reference.
            /// </param>
            /// <param name="offset">
            ///     An offset to start disassembling from. A 0 indicates disassembly should start at the first byte.
            ///     Should be less than the length of the collection of bytes to disassemble.
            /// </param>
            /// <param name="startingAddress">
            ///     The address of the first instruction in the collection of bytes to disassemble.
            /// </param>
            public DeferredInstructionEnumerator(CapstoneDisassembler<TArchitectureInstruction, TArchitectureRegister, TArchitectureGroup, TArchitectureDetail> disassembler, byte[] code, int offset, long startingAddress) {
                this._disassembler = disassembler;
                this._pinnedCode = GCHandle.Alloc(code, GCHandleType.Pinned);
                this._currentOffset = offset;
                this._currentAddress = (ulong) startingAddress;

                this._codeSize = code.Length;
                this._disposed = false;
            }

            /// <summary>
            ///     Destroy Deferred Instruction Enumerator.
            /// </summary>
            ~DeferredInstructionEnumerator() {
                this.Dispose(false);
            }

            /// <summary>
            ///     Gets the current instruction in the instruction stream.
            /// </summary>
            /// <exception cref="System.InvalidOperationException">
            ///     Thrown if an initial call to <c>DeferredInstructionEnumerator.MoveNext()</c> was not made.
            /// </exception>
            /// <exception cref="System.ObjectDisposedException">
            ///     Thrown if the enumerator is disposed.
            /// </exception>
            public Instruction<TArchitectureInstruction, TArchitectureRegister, TArchitectureGroup, TArchitectureDetail> Current {
                get {
                    this.CheckDisposed();
                    if (_currentInstruction == null) {
                        throw new InvalidOperationException();
                    }

                    return this._currentInstruction;
                }
            }

            /// <summary>
            ///     Get Current Instruction.
            /// </summary>
            /// <exception cref="System.InvalidOperationException">
            ///     Thrown if an initial call to <c>DeferredInstructionEnumerator.MoveNext()</c> was not made.
            /// </exception>
            /// <exception cref="System.ObjectDisposedException">
            ///     Thrown if the enumerator is disposed.
            /// </exception>
            object IEnumerator.Current {
                get {
                    return this.Current;
                }
            }

            /// <summary>
            ///     Destroy Deferred Instruction Enumerator.
            /// </summary>
            public void Dispose() {
                Dispose(true);
                GC.SuppressFinalize(this);
            }

            /// <summary>
            ///     Get Next Instruction.
            /// </summary>
            /// <returns>
            ///     A boolean true if an instruction is returned. A boolean false otherwise.
            /// </returns>
            /// <exception cref="System.ObjectDisposedException">
            ///     Thrown if the enumerator is disposed.
            /// </exception>
            public bool MoveNext() {
                this.CheckDisposed();

                var pCode = this._pinnedCode.AddrOfPinnedObject() + this._currentOffset;
                var pCount = (IntPtr) 1;
                var pInstructions = IntPtr.Zero;
                var pSize = (IntPtr) this._codeSize - this._currentOffset;

                // Disassemble Binary Code.
                //
                // ...
                var pResultCode = CapstoneImport.Disassemble(_disassembler.Handle.DangerousGetHandle(), pCode, pSize, this._currentAddress, pCount, ref pInstructions);

                var iResultCode = (int) pResultCode;
                var nativeInstructions = MarshalExtension.PtrToStructure<NativeInstruction>(pInstructions, iResultCode);
                if (nativeInstructions == null || nativeInstructions.Length == 0) {
                    return false;
                }

                var instruction = nativeInstructions[0];
                this._currentInstruction = this._disassembler.CreateInstruction(instruction);
                this._currentAddress += (ulong) this._currentInstruction.Bytes.Length;
                this._currentOffset += this._currentInstruction.Bytes.Length;

                return true;
            }

            /// <summary>
            ///     Reset Enumerator.
            /// </summary>
            /// <exception cref="System.NotSupportedException">
            ///     Thrown always.
            /// </exception>
            public void Reset() {
                throw new NotSupportedException();
            }

            /// <summary>
            ///     Destroy Deferred Instruction Enumerator.
            /// </summary>
            /// <param name="disposing">
            ///     A boolean true if the enumerator is being disposed from application code. A boolean false otherwise.
            /// </param>
            private void Dispose(bool disposing) {
                if (!this._disposed) {
                    if (this._pinnedCode.IsAllocated) {
                        this._pinnedCode.Free();
                    }

                    this._disposed = true;
                }
            }

            /// <summary>
            ///     Check if Enumerator is Disposed.
            /// </summary>
            /// <exception cref="System.ObjectDisposedException">
            ///     Thrown if the enumerator is disposed.
            /// </exception>
            private void CheckDisposed() {
                if (this._disposed) {
                    throw new ObjectDisposedException("DeferredInstructionEnumerator");
                }
            }
        }
    }
}