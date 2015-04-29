using System.Runtime.InteropServices;

namespace Gee.External.Capstone.PowerPc {
    /// <summary>
    ///     Native PowerPC Instruction Operand Value.
    /// </summary>
    [StructLayout(LayoutKind.Explicit)]
    public struct NativePowerPcInstructionOperandValue {
        /// <summary>
        ///     Operand Value's Register Value.
        /// </summary>
        [FieldOffset(0)] public uint Register;

        /// <summary>
        ///     Operand Value's Immediate Value.
        /// </summary>
        [FieldOffset(0)] public int Immediate;

        /// <summary>
        ///     Operand Value's Memory Value.
        /// </summary>
        [FieldOffset(0)] public NativePowerPcInstructionMemoryOperandValue Memory;

        /// <summary>
        ///     Operand Value's Condition Register Value.
        /// </summary>
        [FieldOffset(0)] public NativePowerPcInstructionConditionRegisterOperandValue ConditionRegister;
    }
}