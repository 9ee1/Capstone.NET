using System;
using System.Runtime.InteropServices;

namespace Gee.External.Capstone.Arm {
    /// <summary>
    ///     Native ARM Instruction Detail.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct NativeArmInstructionDetail {
        /// <summary>
        ///     Instruction's Load User Mode Registers Flag.
        /// </summary>
        [MarshalAs(UnmanagedType.I1)] public bool LoadUserModeRegisters;

        /// <summary>
        ///     Instruction's Vector Size.
        /// </summary>
        public int VectorSize;

        /// <summary>
        ///     Instruction's Vector Data Type.
        /// </summary>
        public int VectorDataType;

        /// <summary>
        ///     Instruction's CPS Mode.
        /// </summary>
        public int CpsMode;

        /// <summary>
        ///     Instruction's CPS Flag.
        /// </summary>
        public int CpsFlag;

        /// <summary>
        ///     Instruction's Code Condition.
        /// </summary>
        public int CodeCondition;

        /// <summary>
        ///     Instruction's Update Flags Flag.
        /// </summary>
        [MarshalAs(UnmanagedType.I1)] public bool UpdateFlags;

        /// <summary>
        ///     Instruction's Write Back Flag.
        /// </summary>
        [MarshalAs(UnmanagedType.I1)] public bool WriteBack;

        /// <summary>
        ///     Instruction's Memory Barrier.
        /// </summary>
        public int MemoryBarrier;

        /// <summary>
        ///     Number of Instruction's Operands.
        /// </summary>
        public byte OperandCount;

        /// <summary>
        ///     Instruction's First Operand.
        /// </summary>
        public NativeArmInstructionOperand Operand1;

        /// <summary>
        ///     Instruction's Second Operand.
        /// </summary>
        public NativeArmInstructionOperand Operand2;

        /// <summary>
        ///     Instruction's Third Operand.
        /// </summary>
        public NativeArmInstructionOperand Operand3;

        /// <summary>
        ///     Instruction's Fourth Operand.
        /// </summary>
        public NativeArmInstructionOperand Operand4;

        /// <summary>
        ///     Instruction's Fifth Operand.
        /// </summary>
        public NativeArmInstructionOperand Operand5;

        /// <summary>
        ///     Instruction's Sixth Operand.
        /// </summary>
        public NativeArmInstructionOperand Operand6;

        /// <summary>
        ///     Instruction's Seventh Operand.
        /// </summary>
        public NativeArmInstructionOperand Operand7;

        /// <summary>
        ///     Instruction's Eighth Operand.
        /// </summary>
        public NativeArmInstructionOperand Operand8;

        /// <summary>
        ///     Instruction's Ningth Operand.
        /// </summary>
        public NativeArmInstructionOperand Operand9;

        /// <summary>
        ///     Instruction's Tenth Operand.
        /// </summary>
        public NativeArmInstructionOperand Operand10;

        /// <summary>
        ///     Instruction's Eleventh Operand.
        /// </summary>
        public NativeArmInstructionOperand Operand11;

        /// <summary>
        ///     Instruction's Twelfth Operand.
        /// </summary>
        public NativeArmInstructionOperand Operand12;

        /// <summary>
        ///     Instruction's Thirteenth Operand.
        /// </summary>
        public NativeArmInstructionOperand Operand13;

        /// <summary>
        ///     Instruction's Fourteenth Operand.
        /// </summary>
        public NativeArmInstructionOperand Operand14;

        /// <summary>
        ///     Instruction's Fifteenth Operand.
        /// </summary>
        public NativeArmInstructionOperand Operand15;

        /// <summary>
        ///     Instruction's Sixteenth Operand.
        /// </summary>
        public NativeArmInstructionOperand Operand16;

        /// <summary>
        ///     Instruction's Seventeenth Operand.
        /// </summary>
        public NativeArmInstructionOperand Operand17;

        /// <summary>
        ///     Instruction's Eighteenth Operand.
        /// </summary>
        public NativeArmInstructionOperand Operand18;

        /// <summary>
        ///     Instruction's Nineteenth Operand.
        /// </summary>
        public NativeArmInstructionOperand Operand19;

        /// <summary>
        ///     Instruction's Twentieth Operand.
        /// </summary>
        public NativeArmInstructionOperand Operand20;

        /// <summary>
        ///     Instruction's Twenty-First Operand.
        /// </summary>
        public NativeArmInstructionOperand Operand21;

        /// <summary>
        ///     Instruction's Twenty-Second Operand.
        /// </summary>
        public NativeArmInstructionOperand Operand22;

        /// <summary>
        ///     Instruction's Twenty-Third Operand.
        /// </summary>
        public NativeArmInstructionOperand Operand23;

        /// <summary>
        ///     Instruction's Twenty-Fourth Operand.
        /// </summary>
        public NativeArmInstructionOperand Operand24;

        /// <summary>
        ///     Instruction's Twenty-Fifth Operand.
        /// </summary>
        public NativeArmInstructionOperand Operand25;

        /// <summary>
        ///     Instruction's Twenty-Sixth Operand.
        /// </summary>
        public NativeArmInstructionOperand Operand26;

        /// <summary>
        ///     Instruction's Twenty-Seventh Operand.
        /// </summary>
        public NativeArmInstructionOperand Operand27;

        /// <summary>
        ///     Instruction's Twenty-Eighth Operand.
        /// </summary>
        public NativeArmInstructionOperand Operand28;

        /// <summary>
        ///     Instruction's Twenty-Ninth Operand.
        /// </summary>
        public NativeArmInstructionOperand Operand29;

        /// <summary>
        ///     Instruction's Thirth Operand.
        /// </summary>
        public NativeArmInstructionOperand Operand30;

        /// <summary>
        ///     Instruction's Thirth-First Operand.
        /// </summary>
        public NativeArmInstructionOperand Operand31;

        /// <summary>
        ///     Instruction's Thirth-Second Operand.
        /// </summary>
        public NativeArmInstructionOperand Operand32;

        /// <summary>
        ///     Instruction's Thirth-Third Operand.
        /// </summary>
        public NativeArmInstructionOperand Operand33;

        /// <summary>
        ///     Instruction's Thirth-Fourth Operand.
        /// </summary>
        public NativeArmInstructionOperand Operand34;

        /// <summary>
        ///     Instruction's Thirth-Fifth Operand.
        /// </summary>
        public NativeArmInstructionOperand Operand35;

        /// <summary>
        ///     Instruction's Thirth-Sixth Operand.
        /// </summary>
        public NativeArmInstructionOperand Operand36;

        /// <summary>
        ///     Get Instruction's Managed Vector Data Type.
        /// </summary>
        /// <value>
        ///     Convenient property to retrieve the instruction's vector data type as a managed enumerated type.
        /// </value>
        public ArmVectorDataType ManagedVectorDataType {
            get {
                var eVectorDataType = (ArmVectorDataType) this.VectorDataType;
                return eVectorDataType;
            }
        }

        /// <summary>
        ///     Get Instruction's Managed CPS Mode.
        /// </summary>
        /// <value>
        ///     Convenient property to retrieve the instruction's CPS mode as a managed enumerated type.
        /// </value>
        public ArmCpsMode ManagedCpsMode {
            get {
                var eCpsMode = (ArmCpsMode) this.CpsMode;
                return eCpsMode;
            }
        }

        /// <summary>
        ///     Get Instruction's Managed CPS Flag.
        /// </summary>
        /// <value>
        ///     Convenient property to retrieve the instruction's CPS flag as a managed enumerated type.
        /// </value>
        public ArmCpsFlag ManagedCpsFlag {
            get {
                var eCpsFlag = (ArmCpsFlag) this.CpsFlag;
                return eCpsFlag;
            }
        }

        /// <summary>
        ///     Get Instruction's Managed Code Condition.
        /// </summary>
        /// <value>
        ///     Convenient property to retrieve the instruction's code condition as a managed enumerated type.
        /// </value>
        public ArmCodeCondition ManagedCodeCondition {
            get {
                var eCodeCondition = (ArmCodeCondition) this.CodeCondition;
                return eCodeCondition;
            }
        }

        /// <summary>
        ///     Get Instruction's Managed Memory Barrier.
        /// </summary>
        /// <value>
        ///     Convenient property to retrieve the instruction's memory barrier as a managed enumerated type.
        /// </value>
        public ArmMemoryBarrier ManagedMemoryBarrier {
            get {
                var eMemoryBarrier = (ArmMemoryBarrier) this.MemoryBarrier;
                return eMemoryBarrier;
            }
        }

        /// <summary>
        ///     Get Instruction's Managed Operands.
        /// </summary>
        /// <value>
        ///     Convenient property to retrieve the instruction's operands as a managed collection. The size of the
        ///     managed collection will always be equal to the value represented by
        ///     <c>NativeArmInstructionDetail.OperandCount</c>. This property allocates managed memory for a new
        ///     managed collection and copies by value the required <c>NativeArmInstructionDetail.Operand</c>
        ///     fields every time it is invoked.
        /// </value>
        public NativeArmInstructionOperand[] ManagedOperands {
            get {
                // Create Managed Collection.
                //
                // Unfortunately, C# does not support fixed arrays, or buffers, for user defined structures. To work
                // around alignment issues with the default .NET Marshaller, and because the convenience of the
                // Capstone API allows it, each operand is declared as an individual field. The following ugly code
                // segment deals with composing those individual fields in an appropriately sized collection.
                //
                // I am so sorry for this ugly code.
                var managedOperands = new NativeArmInstructionOperand[this.OperandCount];
                var thisType = this.GetType();
                for (var i = 1; i <= managedOperands.Length; i++) {
                    // Get Operand Using Reflection.
                    //
                    // This is a relatively expensive operation. An better approach needs to be investigated.
                    var operandPropertyName = String.Format("Operand{0}", i);
                    var operandProperty = thisType.GetField(operandPropertyName);
                    var operandPropertyValue = (NativeArmInstructionOperand) operandProperty.GetValue(this);

                    managedOperands[(i - 1)] = operandPropertyValue;
                }

                return managedOperands;
            }
        }
    }
}