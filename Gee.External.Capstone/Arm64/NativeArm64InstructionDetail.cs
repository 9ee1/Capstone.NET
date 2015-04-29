using System;
using System.Runtime.InteropServices;

namespace Gee.External.Capstone.Arm64 {
    /// <summary>
    ///     Native ARM64 Instruction Detail.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct NativeArm64InstructionDetail {
        /// <summary>
        ///     Instruction's Code Condition.
        /// </summary>
        public int CodeCondition;

        /// <summary>
        ///     Instruction's Update Flags Flag.
        /// </summary>
        /// <remarks>
        ///     Interestingly enough, the default .NET Marshaller is marshalling this field from unmanaged memory as
        ///     4 bytes! The result is an overlapping problem. The attribute helps resolves this. Theoretically,
        ///     declaring the field as a byte would also solve the problem but the field is declared in unmanaged memory
        ///     as a boolean. Even more interesting, for other structures, the default .NET Marshaller does not seem
        ///     to have this problem! For an example, see <c>NativeX86InstructionDetail</c>.
        /// </remarks>
        [MarshalAs(UnmanagedType.I1)] public bool UpdateFlags;

        /// <summary>
        ///     Instruction's Write Back Flag.
        /// </summary>
        [MarshalAs(UnmanagedType.I1)] public bool WriteBack;

        /// <summary>
        ///     Number of Instruction's Operands.
        /// </summary>
        public byte OperandCount;

        /// <summary>
        ///     Instruction's First Operand.
        /// </summary>
        public NativeArm64InstructionOperand Operand1;

        /// <summary>
        ///     Instruction's Second Operand.
        /// </summary>
        public NativeArm64InstructionOperand Operand2;

        /// <summary>
        ///     Instruction's Third Operand.
        /// </summary>
        public NativeArm64InstructionOperand Operand3;

        /// <summary>
        ///     Instruction's Fourth Operand.
        /// </summary>
        public NativeArm64InstructionOperand Operand4;

        /// <summary>
        ///     Instruction's Fifth Operand.
        /// </summary>
        public NativeArm64InstructionOperand Operand5;

        /// <summary>
        ///     Instruction's Sixth Operand.
        /// </summary>
        public NativeArm64InstructionOperand Operand6;

        /// <summary>
        ///     Instruction's Seventh Operand.
        /// </summary>
        public NativeArm64InstructionOperand Operand7;

        /// <summary>
        ///     Instruction's Eighth Operand.
        /// </summary>
        public NativeArm64InstructionOperand Operand8;

        /// <summary>
        ///     Get Instruction's Managed Code Condition.
        /// </summary>
        /// <value>
        ///     Convenient property to retrieve the instruction's code condition as a managed enumerated type.
        /// </value>
        public Arm64CodeCondition ManagedCodeCondition {
            get {
                var eCodeCondition = (Arm64CodeCondition) this.CodeCondition;
                return eCodeCondition;
            }
        }

        /// <summary>
        ///     Get Instruction's Managed Operands.
        /// </summary>
        /// <value>
        ///     Convenient property to retrieve the instruction's operands as a managed collection. The size of the
        ///     managed collection will always be equal to the value represented by
        ///     <c>NativeArm64InstructionDetail.OperandCount</c>. This property allocates managed memory for a new
        ///     managed collection and copies by value the required <c>NativeArm64InstructionDetail.Operand</c>
        ///     fields every time it is invoked.
        /// </value>
        public NativeArm64InstructionOperand[] ManagedOperands {
            get {
                // Create Managed Collection.
                //
                // Unfortunately, C# does not support fixed arrays, or buffers, for user defined structures. To work
                // around alignment issues with the default .NET Marshaller, and because the convenience of the
                // Capstone API allows it, each operand is declared as an individual field. The following ugly code
                // segment deals with composing those individual fields in an appropriately sized collection.
                //
                // I am so sorry for this ugly code.
                var managedOperands = new NativeArm64InstructionOperand[this.OperandCount];
                var thisType = this.GetType();
                for (var i = 1; i <= managedOperands.Length; i++) {
                    // Get Operand Using Reflection.
                    //
                    // This is a relatively expensive operation. An better approach needs to be investigated.
                    var operandPropertyName = String.Format("Operand{0}", i);
                    var operandProperty = thisType.GetField(operandPropertyName);
                    var operandPropertyValue = (NativeArm64InstructionOperand) operandProperty.GetValue(this);

                    managedOperands[(i - 1)] = operandPropertyValue;
                }

                return managedOperands;
            }
        }
    }
}