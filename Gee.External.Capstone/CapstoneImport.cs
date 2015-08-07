using System;
using System.Runtime.InteropServices;

namespace Gee.External.Capstone {
    /// <summary>
    ///     Capstone Import.
    /// </summary>
    public static class CapstoneImport {
        /// <summary>Allocate memory for 1 instruction to be used by cs_disasm_iter().</summary>
        /// <param name="pHandle">handle returned by <see cref="Open"/></param>
        /// <remarks>NOTE: when no longer in use, you can reclaim the memory allocated
        /// for this instruction with cs_free(insn, 1)</remarks>
        /// <returns></returns>
        [DllImport("capstone.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "cs_malloc")]
        public static extern IntPtr /* cs_insn * */ AllocInstruction(IntPtr pHandle);

        /// <summary>Check if a disassembled instruction belong to a particular group.
        /// Find the group id from header file of corresponding architecture (arm.h for
        /// ARM, x86.h for X86, ...)
        /// Internally, this simply verifies if @group_id matches any member of
        /// insn->groups array.</summary>
        /// <param name="pHandle">handle returned by <see cref="Open"/></param>
        /// <param name="insn">disassembled instruction structure received from cs_disasm()
        /// or cs_disasm_iter()</param>
        /// <param name="group_id">group that you want to check if this instruction
        /// belong to.</param>
        /// <remarks>NOTE: this API is only valid when detail option is ON (which is
        /// OFF by default).
        /// WARN: when in 'diet' mode, this API is irrelevant because the engine does
        /// not update @groups array.</remarks>
        /// <returns>true if this instruction indeed belongs to aboved group, or false
        /// otherwise.</returns>
        [DllImport("capstone.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "cs_insn_group")]
        public static extern bool BelongsToGroup(IntPtr pHandle, IntPtr /* cs_insn * */ insn, uint group_id);

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

        /// <summary> Fast API to disassemble binary code, given the code buffer, size,
        /// address and number of instructions to be decoded. This API put the resulted
        /// instruction into a given cache in @insn. See tests/test_iter.c for sample
        /// code demonstrating this API.</summary>
        /// <param name="pHandle">handle returned by <see cref="Open"/></param>
        /// <param name="code">buffer containing raw binary code to be disassembled</param>
        /// <param name="size">size of above code</param>
        /// <param name="address">address of the first insn in given raw code buffer</param>
        /// <param name="insn">pointer to instruction to be filled in by this API.</param>
        /// <returns></returns>
        /// <remarks>NOTE 1: this API will update @code, @size & @address to point to the
        /// next instruction in the input buffer. Therefore, it is convenient to use
        /// cs_disasm_iter() inside a loop to quickly iterate all the instructions.
        /// While decoding one instruction at a time can also be achieved with
        /// cs_disasm(count=1), some benchmarks shown that cs_disasm_iter() can be 30%
        /// faster on random input.
        /// NOTE 2: the cache in @insn can be created with cs_malloc() API.
        /// NOTE 3: for system with scarce memory to be dynamically allocated such as
        /// OS kernel or firmware, this API is recommended over cs_disasm(), which
        /// allocates memory based on the number of instructions to be disassembled.
        /// The reason is that with cs_disasm(), based on limited available memory,
        /// we have to calculate in advance how many instructions to be disassembled,
        /// which complicates things. This is especially troublesome for the case
        /// @count=0, when cs_disasm() runs uncontrollably (until either end of input
        /// buffer, or when it encounters an invalid instruction).</remarks>
        [DllImport("capstone.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "cs_disasm_iter")]
        public static extern bool DisassembleIteratively(IntPtr pHandle, byte[] code,
            int size, out ulong address, IntPtr /* cs_insn * */ insn);

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

        /// <summary>Report the last error number when some API function fail.
        /// Like glibc's errno, cs_errno might not retain its old value once accessed.</summary>
        /// <param name="pHandle">handle returned by <see cref="Open"/></param>
        /// <returns>error code of cs_err enum type (CS_ERR_*, see below</returns>
        [DllImport("capstone.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "cs_errno")]
        public static extern ErrorCode GetLastError(IntPtr pHandle);

        /// <summary>Retrieve the position of operand of given type in <arch>.operands[] array.
        /// Later, the operand can be accessed using the returned position. Find the operand type
        /// in header file of corresponding architecture (arm.h for ARM, x86.h for X86, ...)</summary>
        /// <param name="pHandle">handle returned by <see cref="Open"/></param>
        /// <param name="insn">disassembled instruction structure received from cs_disasm()
        /// <param name="op_type">Operand type to be found.</param>
        /// <param name="position">position of the operand to be found. This must be in the
        /// range [1, cs_op_count(handle, insn, op_type)]</param>
        /// <remarks>NOTE: this API is only valid when detail option is ON (which is OFF by default)
        /// </remarks>
        /// <returns>index of operand of given type @op_type in <arch>.operands[] array
        /// in instruction @insn, or -1 on failure.</returns>
        [DllImport("capstone.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "cs_op_index")]
        public static extern int GetOperandIndex(IntPtr pHandle, IntPtr /* cs_insn * */ insn, uint op_type,
            uint position);

        /// <summary>Count the number of operands of a given type. Find the operand type in header
        /// file of corresponding architecture (arm.h for ARM, x86.h for X86, ...)</summary>
        /// <param name="pHandle">handle returned by <see cref="Open"/></param>
        /// <param name="insn">disassembled instruction structure received from cs_disasm()
        /// or cs_disasm_iter()</param>
        /// <param name="op_type">Operand type to be found.</param>
        /// <remarks>NOTE: this API is only valid when detail option is ON (which is OFF by default)
        /// </remarks>
        /// <returns>number of operands of given type @op_type in instruction @insn,
        /// or -1 on failure.</returns>
        [DllImport("capstone.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "cs_op_count")]
        public static extern int GetOperandsCount(IntPtr pHandle, IntPtr /* cs_insn * */ insn, uint op_type);

        /// <summary>Return combined API version & major and minor version numbers.</summary>
        /// <param name="major">major number of API version</param>
        /// <param name="minor">minor number of API version</param>
        /// <returns>hexical number as (major << 8 | minor), which encodes both major & minor
        /// versions.</returns>
        /// <remarks>NOTE: This returned value can be compared with version number made with
        /// macro CS_MAKE_VERSION
        /// For example, second API version would return 1 in @major, and 1 in @minor
        /// The return value would be 0x0101
        /// NOTE: if you only care about returned value, but not major and minor values,
        /// set both @major & @minor arguments to NULL.</remarks>
        [DllImport("capstone.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "cs_version")]
        public static extern uint GetApiVersion(out int major, out int minor);

        /// <summary>Return a string describing given error code.</summary>
        /// <param name="code">error code (see CS_ERR_* below)</param>
        /// <returns>returns a pointer to a string that describes the error code passed
        /// in the argument @code</returns>
        [DllImport("capstone.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "cs_strerror", CharSet=CharSet.Ansi)]
        public static extern string GetErrorText(ErrorCode code);

        /// <summary>Return friendly name of a group id (that an instruction can belong to)
        /// Find the group id from header file of corresponding architecture (arm.h for ARM,
        /// x86.h for X86, ...)</summary>
        /// <param name="pHandle">handle returned by <see cref="Open"/></param>
        /// <param name="groupId"></param>
        /// <remarks>WARN: when in 'diet' mode, this API is irrelevant because the engine
        /// does not store group name.</remarks>
        /// <returns>string name of the group, or NULL if @group_id is invalid.</returns>
        [DllImport("capstone.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "cs_group_name", CharSet=CharSet.Ansi)]
        public static extern string GroupNamme(IntPtr pHandle, uint groupId);

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

        /// <summary>This API can be used to either ask for archs supported by this library,
        /// or check to see if the library was compile with 'diet' option (or called in 'diet'
        /// mode).
        /// To check if a particular arch is supported by this library, set @query to
        /// arch mode (CS_ARCH_* value).
        /// To check if this library is in 'diet' mode, set @query to Feature.Diet
        /// To verify if this library supports all the archs, use Feature.All
        /// which is a special value (0xFFFF) not encoded in the <see cref="Feature"/>
        /// enumeration.
        /// </summary>
        /// <param name="query"></param>
        /// <returns>True if this library supports the given arch, or in 'diet' mode.</returns>
        [DllImport("capstone.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "cs_support")]
        public static extern bool IsFeatureSupported(Feature query);

        /// <summary>Check if a disassembled instruction IMPLICITLY used a particular register.
        /// Find the register id from header file of corresponding architecture (arm.h for ARM,
        /// x86.h for X86, ...) Internally, this simply verifies if @reg_id matches any member
        /// of insn->regs_read array.</summary>
        /// <param name="pHandle">handle returned by <see cref="Open"/></param>
        /// <param name="insn">disassembled instruction structure received from cs_disasm() or
        /// cs_disasm_iter()</param>
        /// <param name="reg_id">register that you want to check if this instruction used it.
        /// </param>
        /// <remarks>NOTE: this API is only valid when detail option is ON (which is OFF by
        /// default)
        /// WARN: when in 'diet' mode, this API is irrelevant because the engine does not
        /// update @regs_read array.</remarks>
        /// <returns>true if this instruction indeed implicitly used aboved register, or false
        /// otherwise.</returns>
        [DllImport("capstone.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "cs_reg_read")]
        public static extern bool IsRegisterRead(IntPtr pHandle, IntPtr /* cs_insn * */ insn, uint reg_id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pHandle">handle returned by <see cref="Open"/></param>
        /// <param name="insn">disassembled instruction structure received from cs_disasm() or
        /// cs_disasm_iter()</param>
        /// <param name="reg_id">register that you want to check if this instruction used it.
        /// </param>
        /// <remarks>NOTE: this API is only valid when detail option is ON (which is OFF by
        /// default)
        /// WARN: when in 'diet' mode, this API is irrelevant because the engine does not
        /// update @regs_read array.</remarks>
        /// <returns>true if this instruction indeed implicitly modified aboved register, or
        /// false otherwise.</returns>
        [DllImport("capstone.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "cs_reg_write")]
        public static extern bool IsRegisterWriten(IntPtr pHandle, IntPtr /* cs_insn * */ insn, uint reg_id);

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

        // Feature type
        public enum Feature
        {
            ARM = 0,	// ARM architecture (including Thumb, Thumb-2)
            ARM64,		// ARM-64, also called AArch64
            MIPS,		// Mips architecture
            X86,		// X86 architecture (including x86 & x86-64)
            PPC,		// PowerPC architecture
            SPARC,		// Sparc architecture
            SYSZ,		// SystemZ architecture
            XCORE,		// XCore architecture
            All = 0xFFFF,
            Diet = 0x10000,
            X86ReduceMode = 0x10001,
        }

        /// <summary>All type of errors encountered by Capstone API.
        /// These are values returned by cs_errno()
        /// </summary>
        public enum ErrorCode
        {
            Ok = 0,   // No error: everything was fine
            OutOfMemory,      // Out-Of-Memory error: cs_open(), cs_disasm(), cs_disasm_iter()
            UnusupportedArchitecture,     // Unsupported architecture: cs_open()
            InvalidHandle,   // Invalid handle: cs_op_count(), cs_op_index()
            InvalidHandle2,	     // Invalid csh argument: cs_close(), cs_errno(), cs_option()
            InvalidName,     // Invalid/unsupported mode: cs_open()
            InvalidOption,   // Invalid/unsupported option: cs_option()
            DetailOptionIsOff,   // Information is unavailable because detail option is OFF
            UninitializedDynamicMemoryManagee, // Dynamic memory management uninitialized (see CS_OPT_MEM)
            UnsupportedVersion,  // Unsupported version (bindings)
            NotAvailableInDietMode,     // Access irrelevant data in "diet" engine
            NotAvailableInSkipDataMode, // Access irrelevant data for "data" instruction in SKIPDATA mode
            // The two codes below are documented in the capstone.h header. However they
            // don't have any associated error message.
            UnsupportedATTSyntax,  // X86 AT&T syntax is unsupported (opt-out at compile time)
            UnsupportedIntelSyntax, // X86 Intel syntax is unsupported (opt-out at compile time)
        }
    }
}