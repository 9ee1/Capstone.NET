using System.Runtime.InteropServices;

namespace Gee.External.Capstone.PowerPc {
    /// <summary>
    ///     Native PowerPC Instruction Condition Register Operand Value.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct NativePowerPcInstructionConditionRegisterOperandValue {
        /// <summary>
        ///     Operand Value's Scale Value.
        /// </summary>
        public uint Scale;

        /// <summary>
        ///     Operand Value's Register.
        /// </summary>
        public uint Register;
    }
}