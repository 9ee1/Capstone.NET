using System;

namespace Gee.External.Capstone {
    /// <summary>
    ///     Instruction.
    /// </summary>
    /// <typeparam name="TSelf">
    ///     This type.
    /// </typeparam>
    /// <typeparam name="TDetail">
    ///     The type of the instruction's details.
    /// </typeparam>
    /// <typeparam name="TGroup">
    ///     The type of the instruction's architecture specific instruction groups.
    /// </typeparam>
    /// <typeparam name="TGroupId">
    ///     The type of the instruction's architecture specific instruction group unique identifiers.
    /// </typeparam>
    /// <typeparam name="TId">
    ///     The type of the instruction's unique identifier.
    /// </typeparam>
    /// <typeparam name="TRegister">
    ///     The type of the instruction's architecture specific registers.
    /// </typeparam>
    /// <typeparam name="TRegisterId">
    ///     The type of the instruction's architecture specific register unique identifiers.
    /// </typeparam>
    public abstract class Instruction<TSelf, TDetail, TGroup, TGroupId, TId, TRegister, TRegisterId>
        where TSelf : Instruction<TSelf, TDetail, TGroup, TGroupId, TId, TRegister, TRegisterId>
        where TDetail : InstructionDetail<TDetail, TGroup, TGroupId, TSelf, TId, TRegister, TRegisterId>
        where TGroup : InstructionGroup<TGroupId>
        where TGroupId : Enum
        where TId : Enum
        where TRegister : Register<TRegisterId>
        where TRegisterId : Enum {
        /// <summary>
        ///     Instruction's Mnemonic.
        /// </summary>
        private readonly string _mnemonic;

        /// <summary>
        ///     Instruction's Operand Text.
        /// </summary>
        private readonly string _operand;

        /// <summary>
        ///     Get Instruction's Address.
        /// </summary>
        public long Address { get; }

        /// <summary>
        ///     Get Instruction's Machine Bytes.
        /// </summary>
        public byte[] Bytes { get; }

        /// <summary>
        ///     Get Instruction's Details.
        /// </summary>
        public TDetail Details { get; }

        /// <summary>
        ///     Get Instruction's Unique Identifier.
        /// </summary>
        public TId Id { get; }

        /// <summary>
        ///     Determine if Diet Mode is Enabled.
        /// </summary>
        /// <value>
        ///     A boolean true if diet mode is enabled. A boolean false otherwise.
        /// </value>
        public bool IsDietModeEnabled => CapstoneDisassembler.IsDietModeEnabled;

        /// <summary>
        ///     Get Instruction's Mnemonic.
        /// </summary>
        /// <exception cref="System.NotSupportedException">
        ///     Thrown if diet mode is enabled.
        /// </exception>
        public string Mnemonic {
            get {
                CapstoneDisassembler.ThrowIfDietModeIsEnabled();
                return this._mnemonic;
            }
        }

        /// <summary>
        ///     Get Instruction's Operand Text.
        /// </summary>
        /// <exception cref="System.NotSupportedException">
        ///     Thrown if diet mode is enabled.
        /// </exception>
        public string Operand {
            get {
                CapstoneDisassembler.ThrowIfDietModeIsEnabled();
                return this._operand;
            }
        }

        /// <summary>
        ///     Create an Instruction.
        /// </summary>
        private protected Instruction(InstructionBuilder<TDetail, TGroup, TGroupId, TSelf, TId, TRegister, TRegisterId> builder) {
            this.Address = builder.Address;
            this.Bytes = builder.Bytes;
            this.Details = builder.Details;
            this.Id = builder.Id;
            this._mnemonic = builder.Mnemonic;
            this._operand = builder.Operand;
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
            var belongsToGroup = this.Details.BelongsToGroup(instructionGroupName);
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
            var belongsToGroup = this.Details.BelongsToGroup(instructionGroupId);
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
            var isRegisterExplicitlyRead = this.Details.IsRegisterExplicitlyRead(registerName);
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
            var isRegisterExplicitlyRead = this.Details.IsRegisterExplicitlyRead(registerId);
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
            var isRegisterExplicitlyWritten = this.Details.IsRegisterExplicitlyWritten(registerName);
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
            var isRegisterExplicitlyWritten = this.Details.IsRegisterExplicitlyWritten(registerId);
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
            var isRegisterImplicitlyRead = this.Details.IsRegisterImplicitlyRead(registerName);
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
            var isRegisterImplicitlyRead = this.Details.IsRegisterImplicitlyRead(registerId);
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
            var isRegisterImplicitlyWritten = this.Details.IsRegisterImplicitlyWritten(registerName);
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
            var isRegisterImplicitlyWritten = this.Details.IsRegisterImplicitlyWritten(registerId);
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
            var isRegisterRead = this.Details.IsRegisterRead(registerName);
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
            var isRegisterRead = this.Details.IsRegisterRead(registerId);
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
            var isRegisterWritten = this.Details.IsRegisterWritten(registerName);
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
            var isRegisterWritten = this.Details.IsRegisterWritten(registerId);
            return isRegisterWritten;
        }
    }
}