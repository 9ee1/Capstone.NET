using System;
using System.Runtime.InteropServices;

namespace Gee.External.Capstone {
    /// <summary>
    ///     Capstone Import.
    /// </summary>
    public static class CapstoneImport {
        /// <summary>
        ///     Close a Capstone Handle.
        /// </summary>
        /// <param name="pHandle">
        ///     A pointer to a Capstone handle.
        /// </param>
        /// <returns>
        ///     An integer indicating the result of the operation.
        /// </returns>
        [DllImport("capstone.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "cs_close")]
        public static extern int Close(ref IntPtr pHandle);

        /// <summary>
        ///     Disassemble Binary Code.
        /// </summary>
        /// <param name="pHandle">
        ///     A pointer to a Capstone handle.
        /// </param>
        /// <param name="pCode">
        ///     A pointer to a collection of bytes representing the binary code to disassemble.
        /// </param>
        /// <param name="codeSize">
        ///     A platform specific integer representing the number of instructions to disassemble.
        /// </param>
        /// <param name="startingAddress">
        ///     The address of the first instruction in the collection of bytes to disassemble.
        /// </param>
        /// <param name="count">
        ///     A platform specific integer representing the number of instructions to disassemble. A
        ///     <c>IntPtr.Zero</c> indicates all instructions should be disassembled.
        /// </param>
        /// <param name="instruction">
        ///     A pointer to a collection of disassembled instructions.
        /// </param>
        /// <returns>
        ///     A platform specific integer representing the number of instructions disassembled. An
        ///     <c>IntPtr.Zero</c> indicates no instructions were disassembled as a result of an error.
        /// </returns>
        [DllImport("capstone.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "cs_disasm")]
        public static extern IntPtr Disassemble(IntPtr pHandle, IntPtr pCode, IntPtr codeSize, ulong startingAddress, IntPtr count, ref IntPtr instruction);

        /// <summary>
        ///     Free Memory Allocated For Disassembled Instructions.
        /// </summary>
        /// <param name="pInstructions">
        ///     A pointer to a collection of disassembled instructions.
        /// </param>
        /// <param name="instructionCount">
        ///     A platform specific integer representing the number of disassembled instructions.
        /// </param>
        [DllImport("capstone.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "cs_free")]
        public static extern void Free(IntPtr pInstructions, IntPtr instructionCount);

        /// <summary>
        ///     Resolve an Instruction Unique Identifier to an Instruction Name.
        /// </summary>
        /// <param name="pHandle">
        ///     A pointer to a Capstone handle.
        /// </param>
        /// <param name="id">
        ///     An instruction's unique identifier.
        /// </param>
        /// <returns>
        ///     A pointer to a string representing the instruction's name. An <c>IntPtr.Zero</c> indicates the
        ///     instruction's unique identifier is invalid.
        /// </returns>
        [DllImport("capstone.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "cs_insn_name")]
        public static extern IntPtr InstructionName(IntPtr pHandle, uint id);

        /// <summary>
        ///     Open a Capstone Handle.
        /// </summary>
        /// <param name="architecture">
        ///     An integer indicating the disassemble architecture.
        /// </param>
        /// <param name="mode">
        ///     An integer indicating the disassemble mode.
        /// </param>
        /// <param name="handle">
        ///     A pointer to a Capstone handle.
        /// </param>
        /// <returns>
        ///     An integer indicating the result of the operation.
        /// </returns>
        [DllImport("capstone.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "cs_open")]
        public static extern int Open(int architecture, int mode, ref IntPtr handle);

        /// <summary>
        ///     Resolve a Registry Unique Identifier to an Registry Name.
        /// </summary>
        /// <param name="pHandle">
        ///     A pointer to a Capstone handle.
        /// </param>
        /// <param name="id">
        ///     A registry's unique identifier.
        /// </param>
        /// <returns>
        ///     A pointer to a string representing the registry's name. An <c>IntPtr.Zero</c> indicates the
        ///     registry's unique identifier is invalid.
        /// </returns>
        [DllImport("capstone.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "cs_reg_name")]
        public static extern IntPtr RegistryName(IntPtr pHandle, uint id);

        /// <summary>
        ///     Set a Disassemble Option.
        /// </summary>
        /// <param name="pHandle">
        ///     A pointer to a Capstone handle.
        /// </param>
        /// <param name="option">
        ///     An integer indicating the option to set.
        /// </param>
        /// <param name="value">
        ///     A platform specific integer indicating the value to set.
        /// </param>
        /// <returns>
        ///     An integer indicating the result of the operation.
        /// </returns>
        [DllImport("capstone.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "cs_option")]
        public static extern int SetOption(IntPtr pHandle, int option, IntPtr value);
    }
}