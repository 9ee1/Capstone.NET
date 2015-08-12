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
        protected CapstoneDisassembler(DisassembleArchitecture architecture, DisassembleMode mode) : base(architecture, mode) { }

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
        ///     Disassemble Binary Code incrementally.
        /// </summary>
        /// <param name="code">
        ///     A collection of bytes representing the binary code to disassemble. Should not be a null reference.
        /// </param>
        /// <returns>
        ///     An IEnumerable deferred stream of dissembled instructions.
        /// </returns>
        /// <exception cref="System.InvalidOperationException">
        ///     Thrown if the binary code could not be disassembled.
        /// </exception>
        public IEnumerable<Instruction<TArchitectureInstruction, TArchitectureRegister, TArchitectureGroup, TArchitectureDetail>> DisassembleStream(byte[] code, int offset, long startAddress) {
            return new InstructionStream(this, code, offset, startAddress);
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
        ///     Provides an IEnumerable interface so that Capstone.NET can be used with
        ///     other .NET components, like LinQ, without having to eagerly disassemble
        ///     large areas of memory.
        /// </summary>
        private sealed class InstructionStream : IEnumerable<Instruction<TArchitectureInstruction, TArchitectureRegister, TArchitectureGroup, TArchitectureDetail>> {
            private readonly CapstoneDisassembler<TArchitectureInstruction, TArchitectureRegister, TArchitectureGroup, TArchitectureDetail> _disassembler;
            private byte[] code;
            private int offset;
            private long address;

            public InstructionStream(
                CapstoneDisassembler<TArchitectureInstruction, TArchitectureRegister, TArchitectureGroup, TArchitectureDetail> disassembler,
                byte[] code,
                int offset,
                long address)
            {
                this._disassembler = disassembler;
                this.code = code;
                this.offset = offset;
                this.address = address;
            }
        
            public IEnumerator<Instruction<TArchitectureInstruction,TArchitectureRegister,TArchitectureGroup,TArchitectureDetail>> GetEnumerator()
            {
                return new InstructionEnumerator(_disassembler, code, offset, address);
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
 	            return GetEnumerator();
            }
        }

        /// <summary>
        ///     Enumerator that lazily disassembles a stream of instructions. 
        /// </summary>
        private class InstructionEnumerator :
            IEnumerator<Instruction<TArchitectureInstruction, TArchitectureRegister, TArchitectureGroup, TArchitectureDetail>> {
            private CapstoneDisassembler<TArchitectureInstruction, TArchitectureRegister, TArchitectureGroup, TArchitectureDetail> dasm;
            private GCHandle pinnedCode;      // Pinned array of bytes containing the area we wish to disassemble.
            private int offset;               // "cursor": the position within the code we're currently at.
            private int codeSize;       // the size of the code.
            private Instruction<TArchitectureInstruction, TArchitectureRegister, TArchitectureGroup, TArchitectureDetail> current;
            private ulong address;

            public InstructionEnumerator(
                CapstoneDisassembler<TArchitectureInstruction, TArchitectureRegister, TArchitectureGroup, TArchitectureDetail> dasm,
                byte[] code,
                int offset,
                long startAddress) {
                this.dasm = dasm;
                // Avoid copying the code to be disassembled, by pinning it instead.
                this.pinnedCode = GCHandle.Alloc(code, GCHandleType.Pinned);
                this.offset = offset;
                this.codeSize = code.Length;
                this.address = (ulong)startAddress;
            }

            /// <summary>
            ///     Finalize the enumerator.
            /// </summary>
            /// <remarks>
            ///     The finalizer will be called at some non-specified time 
            ///     if you forget to Dispose() this object. Avoid this by being
            ///     diligent with your resource management.
            /// </remarks>
            ~InstructionEnumerator() {
                Dispose(false);
            }

            /// <summary>
            ///     Gets the current instruction in the instruction stream.
            /// </summary>
            /// <exception cref="System.InvalidOperationException">
            ///     Thrown if the caller attempts to read this property before
            ///     calling the MoveNext() method.
            /// </exception>
            public Instruction<TArchitectureInstruction, TArchitectureRegister, TArchitectureGroup, TArchitectureDetail> Current {
                get {
                    if (current == null)
                        throw new InvalidOperationException();
                    return current;
                }
            }

            object IEnumerator.Current {
                get { return Current; }
            }

            /// <summary>
            ///     Dispose() method is called automatically by foreach 
            /// </summary>
            public void Dispose() {
                Dispose(true);
                GC.SuppressFinalize(this);
            }

            /// <summary>
            ///     Disposes of any unmanaged/unsafe resources.
            /// </summary>
            /// <param name="disposing"></param>
            private void Dispose(bool disposing) {
                if (pinnedCode.IsAllocated)
                    pinnedCode.Free();
            }

            /// <summary>
            ///     Retrieve the next instruction using the native Capstone disassembler.
            /// </summary>
            /// <returns></returns>
            public bool MoveNext() {
                var pCount = (IntPtr)1;
                var pCode = this.pinnedCode.AddrOfPinnedObject() + offset;
                var pInstructions = IntPtr.Zero;
                var pSize = (IntPtr)codeSize - offset;
                var uStartingAddress = (ulong)address;

                var pResultCode = CapstoneImport.Disassemble(dasm.Handle.DangerousGetHandle(), pCode, pSize, uStartingAddress, pCode, ref pInstructions);

                var iResultCode = (int)pResultCode;
                var instructions = MarshalExtension.PtrToStructure<NativeInstruction>(pInstructions, iResultCode);
                if (instructions == null || instructions.Length == 0)
                    return false;

                // Update the state of the IEnumerator.
                this.current = dasm.CreateInstruction(instructions[0]);
                this.address += (ulong) current.Bytes.Length;
                this.offset += current.Bytes.Length;
                return true;
            }

            /// <summary>
            ///     The Reset method is not supported; it is rarely used in practice.
            /// </summary>
            public void Reset() {
                throw new NotSupportedException();
            }
        }
    }
}