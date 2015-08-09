using System.Runtime.InteropServices;

namespace Gee.External.Capstone.X86 {
    /// <summary>
    ///     Native X86 Instruction Operand.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct NativeX86InstructionOperand {
        /// <summary>
        ///     Operand's Type.
        /// </summary>
        public int Type;

        /// <summary>
        ///     Operand's Value.
        /// </summary>
        public NativeX86InstructionOperandValue Value;

        /// <summary>
        ///     Operand's Size.
        /// </summary>
        public byte Size;

        /// <summary>
        ///     Operand's AVX Broadcast.
        /// </summary>
        public int AvxBroadcast;

        /// <summary>
        ///     Operand's AVX Zero Operation Mask Flag.
        /// </summary>
        [MarshalAs(UnmanagedType.I1)]
        public bool AvxZeroOperationMask;

        /// <summary>
        ///     Get Operand's Managed Type.
        /// </summary>
        /// <value>
        ///     Convenient property to retrieve the operand's type as a managed enumerated type.
        /// </value>
        public X86InstructionOperandType ManagedType {
            get {
                var eType = (X86InstructionOperandType) this.Type;
                return eType;
            }
        }

        /// <summary>
        ///     Get Operand's Managed AVX Broadcast.
        /// </summary>
        /// <value>
        ///     Convenient property to retrieve the operand's AVX broadcast as a managed enumerated type.
        /// </value>
        public X86AvxBroadcast ManagedAvxBroadcast {
            get {
                var eAvxBroadcastType = (X86AvxBroadcast) this.AvxBroadcast;
                return eAvxBroadcastType;
            }
        }

        /// <summary>
        ///     Get Object's String Representation.
        /// </summary>
        /// <returns>
        ///     The object's string representation.
        /// </returns>
        public override string ToString() {
            return this.ManagedType.ToString();
        }
    }
}