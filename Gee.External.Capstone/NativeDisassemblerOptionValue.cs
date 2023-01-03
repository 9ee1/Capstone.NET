namespace Gee.External.Capstone {
    /// <summary>
    ///     Represents the values that can be set for <see cref="NativeDisassemblerOptionType" />s by
    ///     <see cref="NativeCapstone.SetOption" />.
    /// </summary>
    /// <see href="https://github.com/capstone-engine/capstone/blob/1d230532840a37ac032c6ab80128238fc930c6c1/include/capstone/capstone.h#L181" />
    internal enum NativeDisassemblerOptionValue {
        /// <summary>
        ///     Indicates a <see cref="NativeDisassemblerOptionType" /> should be disabled. This member can only be
        ///     used with <see cref="NativeDisassemblerOptionType.SetInstructionDetails" />,
        ///     <see cref="NativeDisassemblerOptionType.SetSkipDataMode" />, and
        ///     <see cref="NativeDisassemblerOptionType.SetUnsigned" />. This member is equivalent to
        ///     <c>CS_OPT_OFF </c> in the Capstone API.
        /// </summary>
        Disable = 0,

        /// <summary>
        ///     Indicates a <see cref="NativeDisassemblerOptionType" /> should be enabled. This member can only be
        ///     used with <see cref="NativeDisassemblerOptionType.SetInstructionDetails" />,
        ///     <see cref="NativeDisassemblerOptionType.SetSkipDataMode" />, and
        ///     <see cref="NativeDisassemblerOptionType.SetUnsigned" />. This member is equivalent to <c>CS_OPT_ON</c>
        ///     in the Capstone API.
        /// </summary>
        Enable = 3,

        /// <summary>
        ///     Indicates a disassembler should use its default syntax for generated assembly code. This member can
        ///     only be used with <see cref="NativeDisassemblerOptionType.SetDisassembleSyntax" />. This member is
        ///     equivalent to <c>CS_OPT_SYNTAX_DEFAULT</c> in the Capstone API.
        /// </summary>
        UseDefaultDisassembleSyntax = 0,

        /// <summary>
        ///     Indicates a disassembler should use Intel syntax for generated assembly code. This member can only be
        ///     used with <see cref="NativeDisassemblerOptionType.SetDisassembleSyntax" />. This member is equivalent
        ///     to <c>CS_OPT_SYNTAX_INTEL</c> in the Capstone API.
        /// </summary>
        UseIntelDisassembleSyntax,

        /// <summary>
        ///     Indicates a disassembler should use ATT syntax for generated assembly code. This member can only be
        ///     used with <see cref="NativeDisassemblerOptionType.SetDisassembleSyntax" />. This member is equivalent
        ///     to <c>CS_OPT_SYNTAX_ATT</c> in the Capstone API.
        /// </summary>
        UseAttDisassembleSyntax,

        /// <summary>
        ///     Indicates a disassembler should use MASM syntax for generated assembly code. This member can only be
        ///     used with <see cref="NativeDisassemblerOptionType.SetDisassembleSyntax" />. This member is equivalent
        ///     to <c>CS_OPT_SYNTAX_MASM</c> in the Capstone API.
        /// </summary>
        UseMasmDisassembleSyntax
    }
}