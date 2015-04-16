// ReSharper disable InconsistentNaming

namespace Gee.External.Capstone {
    /// <summary>
    ///     Architecture Independent Instruction Group.
    /// </summary>
    public enum IndependentInstructionGroup {
        /// <summary>
        ///     Invalid Instruction Group.
        /// </summary>
        Invalid = 0,

        JUMP,
        CALL,
        RET,
        INT,
        IRET,
    }
}