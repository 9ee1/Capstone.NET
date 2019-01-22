using System;
using System.Linq;

namespace Gee.External.Capstone {
    /// <summary>
    ///     Disassembled Instruction Detail.
    /// </summary>
    /// <typeparam name="TSelf">
    ///     This type.
    /// </typeparam>
    /// <typeparam name="TDisassembleMode">
    ///     The type of the hardware mode for the disassembler to use.
    /// </typeparam>
    /// <typeparam name="TGroup">
    ///     The type of the instruction's architecture specific instruction groups.
    /// </typeparam>
    /// <typeparam name="TGroupId">
    ///     The type of the instruction's architecture specific instruction group unique identifiers.
    /// </typeparam>
    /// <typeparam name="TInstruction">
    ///     The type of the instruction.
    /// </typeparam>
    /// <typeparam name="TInstructionId">
    ///     The type of the instruction's unique identifier.
    /// </typeparam>
    /// <typeparam name="TRegister">
    ///     The type of the instruction's architecture specific registers.
    /// </typeparam>
    /// <typeparam name="TRegisterId">
    ///     The type of the instruction's architecture specific register unique identifiers.
    /// </typeparam>
    public abstract class InstructionDetail<TSelf, TDisassembleMode, TGroup, TGroupId, TInstruction, TInstructionId, TRegister, TRegisterId>
        where TSelf : InstructionDetail<TSelf, TDisassembleMode, TGroup, TGroupId, TInstruction, TInstructionId, TRegister, TRegisterId>
        where TDisassembleMode : Enum
        where TGroup : InstructionGroup<TGroupId>
        where TGroupId : Enum
        where TInstruction : Instruction<TInstruction, TSelf, TDisassembleMode, TGroup, TGroupId, TInstructionId, TRegister, TRegisterId>
        where TInstructionId : Enum
        where TRegister : Register<TRegisterId>
        where TRegisterId : Enum {
        /// <summary>
        ///     Read Registers.
        /// </summary>
        private readonly TRegister[] _allReadRegisters;

        /// <summary>
        ///     Written Registers.
        /// </summary>
        private readonly TRegister[] _allWrittenRegisters;

        /// <summary>
        ///     Instruction's Explicitly Read Registers.
        /// </summary>
        private readonly Lazy<TRegister[]> _explicitlyReadRegisters;

        /// <summary>
        ///     Instruction's Explicitly Written Registers.
        /// </summary>
        private readonly Lazy<TRegister[]> _explicitlyWrittenRegisters;

        /// <summary>
        ///     Instruction's Groups.
        /// </summary>
        private readonly TGroup[] _groups;

        /// <summary>
        ///     Instruction's Implicitly Read Registers.
        /// </summary>
        private readonly TRegister[] _implicitlyReadRegisters;

        /// <summary>
        ///     Instruction's Implicitly Written Registers.
        /// </summary>
        private readonly TRegister[] _implicitlyWrittenRegisters;

        /// <summary>
        ///     Get All Read Registers.
        /// </summary>
        /// <exception cref="System.NotSupportedException">
        ///     Thrown if diet mode is enabled.
        /// </exception>
        public TRegister[] AllReadRegisters {
            get {
                CapstoneDisassembler.ThrowIfDietModeIsEnabled();
                return this._allReadRegisters;
            }
        }

        /// <summary>
        ///     Get All Written Registers.
        /// </summary>
        /// <exception cref="System.NotSupportedException">
        ///     Thrown if diet mode is enabled.
        /// </exception>
        public TRegister[] AllWrittenRegisters {
            get {
                CapstoneDisassembler.ThrowIfDietModeIsEnabled();
                return this._allWrittenRegisters;
            }
        }

        /// <summary>
        ///     Get Disassemble Architecture.
        /// </summary>
        /// <remarks>
        ///     Represents the hardware architecture of the disassembled instruction.
        /// </remarks>
        public DisassembleArchitecture DisassembleArchitecture { get; }

        /// <summary>
        ///     Get Instruction's Disassemble Mode.
        /// </summary>
        /// <remarks>
        ///     Represents the hardware mode of the disassembled instruction.
        /// </remarks>
        public TDisassembleMode DisassembleMode { get; }

        /// <summary>
        ///     Get Instruction's Explicitly Read Registers.
        /// </summary>
        /// <exception cref="System.NotSupportedException">
        ///     Thrown if diet mode is enabled.
        /// </exception>
        public TRegister[] ExplicitlyReadRegisters {
            get {
                CapstoneDisassembler.ThrowIfDietModeIsEnabled();
                return this._explicitlyReadRegisters.Value;
            }
        }

        /// <summary>
        ///     Get Instruction's Explicitly Written Registers.
        /// </summary>
        /// <exception cref="System.NotSupportedException">
        ///     Thrown if diet mode is enabled.
        /// </exception>
        public TRegister[] ExplicitlyWrittenRegisters {
            get {
                CapstoneDisassembler.ThrowIfDietModeIsEnabled();
                return this._explicitlyWrittenRegisters.Value;
            }
        }

        /// <summary>
        ///     Get Instruction's Groups.
        /// </summary>
        /// <exception cref="System.NotSupportedException">
        ///     Thrown if diet mode is enabled.
        /// </exception>
        public TGroup[] Groups {
            get {
                CapstoneDisassembler.ThrowIfDietModeIsEnabled();
                return this._groups;
            }
        }

        /// <summary>
        ///     Get Instruction's Implicitly Read Registers.
        /// </summary>
        /// <exception cref="System.NotSupportedException">
        ///     Thrown if diet mode is enabled.
        /// </exception>
        public TRegister[] ImplicitlyReadRegisters {
            get {
                CapstoneDisassembler.ThrowIfDietModeIsEnabled();
                return this._implicitlyReadRegisters;
            }
        }

        /// <summary>
        ///     Get Instruction's Implicitly Written Registers.
        /// </summary>
        /// <exception cref="System.NotSupportedException">
        ///     Thrown if diet mode is enabled.
        /// </exception>
        public TRegister[] ImplicitlyWrittenRegisters {
            get {
                CapstoneDisassembler.ThrowIfDietModeIsEnabled();
                return this._implicitlyWrittenRegisters;
            }
        }

        /// <summary>
        ///     Determine if Diet Mode is Enabled.
        /// </summary>
        /// <value>
        ///     A boolean true if diet mode is enabled. A boolean false otherwise.
        /// </value>
        public bool IsDietModeEnabled => CapstoneDisassembler.IsDietModeEnabled;

        /// <summary>
        ///     Create an Instruction Detail.
        /// </summary>
        /// <param name="builder">
        ///     A builder to initialize the object with.
        /// </param>
        private protected InstructionDetail(InstructionDetailBuilder<TSelf, TDisassembleMode, TGroup, TGroupId, TInstruction, TInstructionId, TRegister, TRegisterId> builder) {
            this._allReadRegisters = builder.AllReadRegisters;
            this._allWrittenRegisters = builder.AllWrittenRegisters;
            this.DisassembleArchitecture = builder.DisassembleArchitecture;
            this.DisassembleMode = builder.DisassembleMode;
            this._explicitlyReadRegisters = new Lazy<TRegister[]>(this.OnExplicitlyReadRegistersLazyInitialization);
            this._explicitlyWrittenRegisters = new Lazy<TRegister[]>(this.OnExplicitlyWrittenRegistersLazyInitialization);
            this._groups = builder.Groups;
            this._implicitlyReadRegisters = builder.ImplicitlyReadRegisters;
            this._implicitlyWrittenRegisters = builder.ImplicitlyWrittenRegisters;
        }

        /// <summary>
        ///     Determine if Instruction Belongs to an Instruction Group.
        /// </summary>
        /// <param name="instructionGroupName">
        ///     An instruction group's name.
        /// </param>
        /// <returns>
        ///     A boolean true if the instruction belongs to the instruction group. A boolean false otherwise.
        /// </returns>
        /// <exception cref="System.NotSupportedException">
        ///     Thrown if diet mode is enabled.
        /// </exception>
        public bool BelongsToGroup(string instructionGroupName) {
            // ...
            //
            // Throws an exception if the operation fails.
            var belongsToGroup = this.Groups.Any(g => g.Name == instructionGroupName);
            return belongsToGroup;
        }

        /// <summary>
        ///     Determine if Instruction Belongs to an Instruction Group.
        /// </summary>
        /// <param name="instructionGroupId">
        ///     An instruction group's unique identifier.
        /// </param>
        /// <returns>
        ///     A boolean true if the instruction belongs to the instruction group. A boolean false otherwise.
        /// </returns>
        /// <exception cref="System.NotSupportedException">
        ///     Thrown if diet mode is enabled.
        /// </exception>
        public bool BelongsToGroup(TGroupId instructionGroupId) {
            // ...
            //
            // Throws an exception if the operation fails.
            var belongsToGroup = this.Groups.Any(g => g.Id.Equals(instructionGroupId));
            return belongsToGroup;
        }

        /// <summary>
        ///     Determine if a Register Was Explicitly Read.
        /// </summary>
        /// <param name="registerName">
        ///     A register's name.
        /// </param>
        /// <returns>
        ///     A boolean true if the register was explicitly read by the instruction. A boolean false otherwise.
        /// </returns>
        /// <exception cref="System.NotSupportedException">
        ///     Thrown if diet mode is enabled.
        /// </exception>
        public bool IsRegisterExplicitlyRead(string registerName) {
            // ...
            //
            // Throws an exception if the operation fails.
            var isRegisterExplicitlyRead = this.ExplicitlyReadRegisters.Any(r => r.Name == registerName);
            return isRegisterExplicitlyRead;
        }

        /// <summary>
        ///     Determine if a Register Was Explicitly Read.
        /// </summary>
        /// <param name="registerId">
        ///     A register's unique identifier.
        /// </param>
        /// <returns>
        ///     A boolean true if the register was explicitly read by the instruction. A boolean false otherwise.
        /// </returns>
        /// <exception cref="System.NotSupportedException">
        ///     Thrown if diet mode is enabled.
        /// </exception>
        public bool IsRegisterExplicitlyRead(TRegisterId registerId) {
            // ...
            //
            // Throws an exception if the operation fails.
            var isRegisterExplicitlyRead = this.ExplicitlyReadRegisters.Any(r => r.Id.Equals(registerId));
            return isRegisterExplicitlyRead;
        }

        /// <summary>
        ///     Determine if a Register Was Explicitly Modified.
        /// </summary>
        /// <param name="registerName">
        ///     A register's name.
        /// </param>
        /// <returns>
        ///     A boolean true if the register was explicitly modified by the instruction. A boolean false otherwise.
        /// </returns>
        /// <exception cref="System.NotSupportedException">
        ///     Thrown if diet mode is enabled.
        /// </exception>
        public bool IsRegisterExplicitlyWritten(string registerName) {
            // ...
            //
            // Throws an exception if the operation fails.
            var isRegisterExplicitlyWritten = this.ExplicitlyWrittenRegisters.Any(r => r.Name == registerName);
            return isRegisterExplicitlyWritten;
        }

        /// <summary>
        ///     Determine if a Register Was Explicitly Modified.
        /// </summary>
        /// <param name="registerId">
        ///     A register's unique identifier.
        /// </param>
        /// <returns>
        ///     A boolean true if the register was explicitly modified by the instruction. A boolean false otherwise.
        /// </returns>
        /// <exception cref="System.NotSupportedException">
        ///     Thrown if diet mode is enabled.
        /// </exception>
        public bool IsRegisterExplicitlyWritten(TRegisterId registerId) {
            // ...
            //
            // Throws an exception if the operation fails.
            var isRegisterExplicitlyWritten = this.ExplicitlyWrittenRegisters.Any(r => r.Id.Equals(registerId));
            return isRegisterExplicitlyWritten;
        }

        /// <summary>
        ///     Determine if a Register Was Implicitly Read.
        /// </summary>
        /// <param name="registerName">
        ///     A register's name.
        /// </param>
        /// <returns>
        ///     A boolean true if the register was implicitly read by the instruction. A boolean false otherwise.
        /// </returns>
        /// <exception cref="System.NotSupportedException">
        ///     Thrown if diet mode is enabled.
        /// </exception>
        public bool IsRegisterImplicitlyRead(string registerName) {
            // ...
            //
            // Throws an exception if the operation fails.
            var isRegisterImplicitlyRead = this.ImplicitlyReadRegisters.Any(r => r.Name == registerName);
            return isRegisterImplicitlyRead;
        }

        /// <summary>
        ///     Determine if a Register Was Implicitly Read.
        /// </summary>
        /// <param name="registerId">
        ///     A register's unique identifier.
        /// </param>
        /// <returns>
        ///     A boolean true if the register was implicitly read by the instruction. A boolean false otherwise.
        /// </returns>
        /// <exception cref="System.NotSupportedException">
        ///     Thrown if diet mode is enabled.
        /// </exception>
        public bool IsRegisterImplicitlyRead(TRegisterId registerId) {
            // ...
            //
            // Throws an exception if the operation fails.
            var isRegisterImplicitlyRead = this.ImplicitlyReadRegisters.Any(r => r.Id.Equals(registerId));
            return isRegisterImplicitlyRead;
        }

        /// <summary>
        ///     Determine if a Register Was Implicitly Modified.
        /// </summary>
        /// <param name="registerName">
        ///     A register's name.
        /// </param>
        /// <returns>
        ///     A boolean true if the register was implicitly modified by the instruction. A boolean false otherwise.
        /// </returns>
        /// <exception cref="System.NotSupportedException">
        ///     Thrown if diet mode is enabled.
        /// </exception>
        public bool IsRegisterImplicitlyWritten(string registerName) {
            // ...
            //
            // Throws an exception if the operation fails.
            var isRegisterImplicitlyWritten = this.ImplicitlyWrittenRegisters.Any(r => r.Name == registerName);
            return isRegisterImplicitlyWritten;
        }

        /// <summary>
        ///     Determine if a Register Was Implicitly Modified.
        /// </summary>
        /// <param name="registerId">
        ///     A register's unique identifier.
        /// </param>
        /// <returns>
        ///     A boolean true if the register was implicitly modified by the instruction. A boolean false otherwise.
        /// </returns>
        /// <exception cref="System.NotSupportedException">
        ///     Thrown if diet mode is enabled.
        /// </exception>
        public bool IsRegisterImplicitlyWritten(TRegisterId registerId) {
            // ...
            //
            // Throws an exception if the operation fails.
            var isRegisterImplicitlyWritten = this.ImplicitlyWrittenRegisters.Any(r => r.Id.Equals(registerId));
            return isRegisterImplicitlyWritten;
        }

        /// <summary>
        ///     Determine if a Register Was Read Explicitly or Implicitly.
        /// </summary>
        /// <param name="registerName">
        ///     A register's name.
        /// </param>
        /// <returns>
        ///     A boolean true if the register was explicitly or implicitly read by the instruction. A boolean false
        ///     otherwise.
        /// </returns>
        /// <exception cref="System.NotSupportedException">
        ///     Thrown if diet mode is enabled.
        /// </exception>
        public bool IsRegisterRead(string registerName) {
            // ...
            //
            // Throws an exception if the operation fails.
            var isRegisterRead = this.AllReadRegisters.Any(r => r.Name == registerName);
            return isRegisterRead;
        }

        /// <summary>
        ///     Determine if a Register Was Read Explicitly or Implicitly.
        /// </summary>
        /// <param name="registerId">
        ///     A register's unique identifier.
        /// </param>
        /// <returns>
        ///     A boolean true if the register was explicitly or implicitly read by the instruction. A boolean false
        ///     otherwise.
        /// </returns>
        /// <exception cref="System.NotSupportedException">
        ///     Thrown if diet mode is enabled.
        /// </exception>
        public bool IsRegisterRead(TRegisterId registerId) {
            // ...
            //
            // Throws an exception if the operation fails.
            var isRegisterRead = this.AllReadRegisters.Any(r => r.Id.Equals(registerId));
            return isRegisterRead;
        }

        /// <summary>
        ///     Determine if a Register Was Modified Explicitly or Implicitly.
        /// </summary>
        /// <param name="registerName">
        ///     A register's name.
        /// </param>
        /// <returns>
        ///     A boolean true if the register was explicitly or implicitly modified by the instruction. A boolean
        ///     false otherwise.
        /// </returns>
        /// <exception cref="System.NotSupportedException">
        ///     Thrown if diet mode is enabled.
        /// </exception>
        public bool IsRegisterWritten(string registerName) {
            // ...
            //
            // Throws an exception if the operation fails.
            var isRegisterWritten = this.AllWrittenRegisters.Any(r => r.Name == registerName);
            return isRegisterWritten;
        }

        /// <summary>
        ///     Determine if a Register Was Modified Explicitly or Implicitly.
        /// </summary>
        /// <param name="registerId">
        ///     A register's unique identifier.
        /// </param>
        /// <returns>
        ///     A boolean true if the register was explicitly or implicitly modified by the instruction. A boolean
        ///     false otherwise.
        /// </returns>
        /// <exception cref="System.NotSupportedException">
        ///     Thrown if diet mode is enabled.
        /// </exception>
        public bool IsRegisterWritten(TRegisterId registerId) {
            // ...
            //
            // Throws an exception if the operation fails.
            var isRegisterWritten = this.AllWrittenRegisters.Any(r => r.Id.Equals(registerId));
            return isRegisterWritten;
        }

        /// <summary>
        ///     On Instruction's Explicitly Read Registers Lazy Initialization.
        /// </summary>
        /// <returns>
        ///     The instruction's explicitly read registers.
        /// </returns>
        private TRegister[] OnExplicitlyReadRegistersLazyInitialization() {
            var value = this._allReadRegisters.Except(this._implicitlyReadRegisters).ToArray();
            return value;
        }

        /// <summary>
        ///     On Instruction's Explicitly Written Registers Lazy Initialization.
        /// </summary>
        /// <returns>
        ///     The instruction's explicitly written registers.
        /// </returns>
        private TRegister[] OnExplicitlyWrittenRegistersLazyInitialization() {
            var value = this._allWrittenRegisters.Except(this._implicitlyWrittenRegisters).ToArray();
            return value;
        }
    }
}