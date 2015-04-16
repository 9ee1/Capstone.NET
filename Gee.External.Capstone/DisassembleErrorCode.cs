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
        UninitializedDynamicMemoryManagement = 8
    }
}