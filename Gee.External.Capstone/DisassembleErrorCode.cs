namespace Gee.External.Capstone {
    /// <summary>
    ///     Disassemble Error Code.
    /// </summary>
    public enum DisassembleErrorCode {
        /// <summary>
        ///     OK Error Code.
        /// </summary>
        Ok = 0,

        /// <summary>
        ///     Out of Memory Error Code.
        /// </summary>
        OutOfMemory = 1,

        /// <summary>
        ///     Unsupported Architecture Error Code.
        /// </summary>
        UnsupportedArchitecture = 2,

        /// <summary>
        ///     Invalid Handle Error Code.
        /// </summary>
        InvalidHandle = 3,

        /// <summary>
        ///     Invalid Capstone Error Code.
        /// </summary>
        InvalidCapstone = 4,

        /// <summary>
        ///     Unsupported Mode Option Value Error Code.
        /// </summary>
        UnsupportedMode = 5,

        /// <summary>
        ///     Unsupported Option Type Error Code.
        /// </summary>
        UnsupportedOption = 6,

        /// <summary>
        ///     Unavailable Instruction Detail Error Code.
        /// </summary>
        UnavailableInstructionDetail = 7,

        /// <summary>
        ///     Uninitialized Dynamic Memory Management Error Code.
        /// </summary>
        UninitializedDynamicMemoryManagement = 8,

        /// <summary>
        /// Unsupported version (bindings)
        /// </summary>
        UnsupportedVersion = 9,  
        /// <summary>
        /// Access irrelevant data in "diet" engine
        /// </summary>
        NotAvailableInDietMode = 10,
        /// <summary>
        /// Access irrelevant data for "data" instruction in SKIPDATA mode
        /// </summary>
        NotAvailableInSkipDataMode = 11,
        // The two codes below are documented in the capstone.h header. However they
        // don't have any associated error message.
        /// <summary>
        /// X86 AT&T syntax is unsupported (opt-out at compile time)
        /// </summary>
        UnsupportedATTSyntax = 12,
        /// <summary>
        /// X86 Intel syntax is unsupported (opt-out at compile time)
        /// </summary>
        UnsupportedIntelSyntax = 13,
    }
}