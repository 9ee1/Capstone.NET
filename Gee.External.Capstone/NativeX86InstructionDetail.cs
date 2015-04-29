using System;
using System.Runtime.InteropServices;

namespace Gee.External.Capstone {
    /// <summary>
    ///     Native X86 Instruction Detail.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct NativeX86InstructionDetail {
        /// <summary>
        ///     Instruction's Prefix.
        /// </summary>
        public fixed byte Prefix [4];

        /// <summary>
        ///     Instruction's Operation Code.
        /// </summary>
        public fixed byte OperationCode [4];

        /// <summary>
        ///     Instruction's REX Prefix.
        /// </summary>
        public byte Rex;

        /// <summary>
        ///     Instruction's Address Size.
        /// </summary>
        public byte AddressSize;

        /// <summary>
        ///     Instruction's ModR/M Byte.
        /// </summary>
        public byte ModRm;

        /// <summary>
        ///     Instruction's SIB Value.
        /// </summary>
        public byte Sib;

        /// <summary>
        ///     Instruction's Displacement Value.
        /// </summary>
        public int Displacement;

        /// <summary>
        ///     Instruction's SIB Index Register.
        /// </summary>
        public int SibIndexRegister;

        /// <summary>
        ///     Instruction's SIB Scale.
        /// </summary>
        public byte SibScale;

        /// <summary>
        ///     Instruction's SIB Base Register.
        /// </summary>
        public int SibBaseRegister;

        /// <summary>
        ///     Instruction's SSE Code Condition.
        /// </summary>
        public int SseCodeCondition;

        /// <summary>
        ///     Instruction's AVX Code Condition.
        /// </summary>
        public int AvxCodeCondition;

        /// <summary>
        ///     Instruction's AVX Suppress All Exceptions Flag.
        /// </summary>
        [MarshalAs(UnmanagedType.I1)]
        public bool AvxSuppressAllExceptions;

        /// <summary>
        ///     Instruction's AVX Rounding Mode.
        /// </summary>
        public int AvxRoundingMode;

        /// <summary>
        ///     Number of Instruction's Operands.
        /// </summary>
        public byte OperandCount;

        /// <summary>
        ///     Instruction's First Operand.
        /// </summary>
        public NativeX86InstructionOperand Operand1;

        /// <summary>
        ///     Instruction's Second Operand.
        /// </summary>
        public NativeX86InstructionOperand Operand2;

        /// <summary>
        ///     Instruction's Third Operand.
        /// </summary>
        public NativeX86InstructionOperand Operand3;

        /// <summary>
        ///     Instruction's Fourth Operand.
        /// </summary>
        public NativeX86InstructionOperand Operand4;

        /// <summary>
        ///     Instruction's Fifth Operand.
        /// </summary>
        public NativeX86InstructionOperand Operand5;

        /// <summary>
        ///     Instruction's Sixth Operand.
        /// </summary>
        public NativeX86InstructionOperand Operand6;

        /// <summary>
        ///     Instruction's Seventh Operand.
        /// </summary>
        public NativeX86InstructionOperand Operand7;

        /// <summary>
        ///     Instruction's Eighth Operand.
        /// </summary>
        public NativeX86InstructionOperand Operand8;

        /// <summary>
        ///     Get Instruction's Managed Prefix.
        /// </summary>
        /// <value>
        ///     Convenient property to retrieve the instruction's prefix as a managed collection. This property
        ///     allocates managed memory for a new managed collection and uses direct memory copying to copy the
        ///     collection from unmanaged memory to managed memory every time it is invoked.
        /// </value>
        public byte[] ManagedPrefix {
            get {
                fixed (byte* pPrefix = this.Prefix) {
                    var pPPrefix = new IntPtr(pPrefix);
                    var managedPrefix = new byte[4];

                    Marshal.Copy(pPPrefix, managedPrefix, 0, 4);
                    return managedPrefix;
                }
            }
        }

        /// <summary>
        ///     Get Instruction's First Managed Prefix Byte.
        /// </summary>
        /// <value>
        ///     Convenient property to retrieve the instruction's first prefix byte as a managed enumerated type.
        /// </value>
        public X86Prefix ManagedPrefix1 {
            get {
                var ePrefix1 = (X86Prefix) this.ManagedPrefix[0];
                return ePrefix1;
            }
        }

        /// <summary>
        ///     Get Instruction's Second Managed Prefix Byte.
        /// </summary>
        /// <value>
        ///     Convenient property to retrieve the instruction's second prefix byte as a managed enumerated type.
        /// </value>
        public X86Prefix ManagedPrefix2 {
            get {
                var ePrefix2 = (X86Prefix) this.ManagedPrefix[1];
                return ePrefix2;
            }
        }

        /// <summary>
        ///     Get Instruction's Third Managed Prefix Byte.
        /// </summary>
        /// <value>
        ///     Convenient property to retrieve the instruction's third prefix byte as a managed enumerated type.
        /// </value>
        public X86Prefix ManagedPrefix3 {
            get {
                var ePrefix3 = (X86Prefix) this.ManagedPrefix[2];
                return ePrefix3;
            }
        }

        /// <summary>
        ///     Get Instruction's Fourth Managed Prefix Byte.
        /// </summary>
        /// <value>
        ///     Convenient property to retrieve the instruction's fourth prefix byte as a managed enumerated type.
        /// </value>
        public X86Prefix ManagedPrefix4 {
            get {
                var ePrefix4 = (X86Prefix) this.ManagedPrefix[3];
                return ePrefix4;
            }
        }

        /// <summary>
        ///     Get Instruction's Managed Operation Code.
        /// </summary>
        /// <value>
        ///     Convenient property to retrieve the instruction's operation code as a managed collection. This
        ///     property allocates managed memory for a new managed collection and uses direct memory copying to copy
        ///     the collection from unmanaged memory to managed memory every time it is invoked.
        /// </value>
        public byte[] ManagedOperationCode {
            get {
                fixed (byte* pOperationCode = this.OperationCode) {
                    var pPOperationCode = new IntPtr(pOperationCode);
                    var managedOperationCode = new byte[4];

                    Marshal.Copy(pPOperationCode, managedOperationCode, 0, 4);
                    return managedOperationCode;
                }
            }
        }

        /// <summary>
        ///     Get Instruction's Managed SIB Index Register.
        /// </summary>
        /// <value>
        ///     Convenient property to retrieve the instruction's SIB index register as a managed enumerated type.
        /// </value>
        public X86Register ManagedSibIndexRegister {
            get {
                var eSibIndexRegister = (X86Register) this.SibIndexRegister;
                return eSibIndexRegister;
            }
        }

        /// <summary>
        ///     Get Instruction's Managed SIB Base Register.
        /// </summary>
        /// <value>
        ///     Convenient property to retrieve the instruction's SIB base register as a managed enumerated type.
        /// </value>
        public X86Register ManagedSibBaseRegister {
            get {
                var eSibBaseRegister = (X86Register) this.SibBaseRegister;
                return eSibBaseRegister;
            }
        }

        /// <summary>
        ///     Get Instruction's Managed SSE Code Condition.
        /// </summary>
        /// <value>
        ///     Convenient property to retrieve the instruction's SSE code condition as a managed enumerated type.
        /// </value>
        public X86SSECodeCondition ManagedSseCodeCondition {
            get {
                var eSseCodeCondition = (X86SSECodeCondition) this.SseCodeCondition;
                return eSseCodeCondition;
            }
        }

        /// <summary>
        ///     Get Instruction's Managed AVX Code Condition.
        /// </summary>
        /// <value>
        ///     Convenient property to retrieve the instruction's AVX code condition as a managed enumerated type.
        /// </value>
        public X86AvxCodeCondition ManagedAvxCodeCondition {
            get {
                var eAvxCodeCondition = (X86AvxCodeCondition) this.AvxCodeCondition;
                return eAvxCodeCondition;
            }
        }

        /// <summary>
        ///     Get Instruction's Managed AVX Rounding Mode.
        /// </summary>
        /// <value>
        ///     Convenient property to retrieve the instruction's AVX rounding mode as a managed enumerated type.
        /// </value>
        public X86AvxRoundingMode ManagedAvxRoundingMode {
            get {
                var eAvxRoundingMode = (X86AvxRoundingMode) this.AvxRoundingMode;
                return eAvxRoundingMode;
            }
        }

        /// <summary>
        ///     Get Instruction's Managed Operands.
        /// </summary>
        /// <value>
        ///     Convenient property to retrieve the instruction's operands as a managed collection. The size of the
        ///     managed collection will always be equal to the value represented by
        ///     <c>NativeInstructionX86Detail.OperandCount</c>. This property allocates managed memory for a new
        ///     managed collection and copies by value the required <c>NativeInstructionX86Detail.Operand</c>
        ///     fields every time it is invoked.
        /// </value>
        public NativeX86InstructionOperand[] ManagedOperands {
            get {
                // Create Managed Collection.
                //
                // Unfortunately, C# does not support fixed arrays, or buffers, for user defined structures. To work
                // around alignment issues with the default .NET Marshaller, and because the convenience of the
                // Capstone API allows it, each operand is declared as an individual field. The following ugly code
                // segment deals with composing those individual fields in an appropriately sized collection.
                //
                // I am so sorry for this ugly code.
                var managedOperands = new NativeX86InstructionOperand[this.OperandCount];
                switch (this.OperandCount) {
                    case 1:
                        managedOperands[0] = this.Operand1;

                        break;
                    case 2:
                        managedOperands[0] = this.Operand1;
                        managedOperands[1] = this.Operand2;

                        break;
                    case 3:
                        managedOperands[0] = this.Operand1;
                        managedOperands[1] = this.Operand2;
                        managedOperands[2] = this.Operand3;

                        break;
                    case 4:
                        managedOperands[0] = this.Operand1;
                        managedOperands[1] = this.Operand2;
                        managedOperands[2] = this.Operand3;
                        managedOperands[3] = this.Operand4;

                        break;
                    case 5:
                        managedOperands[0] = this.Operand1;
                        managedOperands[1] = this.Operand2;
                        managedOperands[2] = this.Operand3;
                        managedOperands[3] = this.Operand4;
                        managedOperands[4] = this.Operand5;

                        break;
                    case 6:
                        managedOperands[0] = this.Operand1;
                        managedOperands[1] = this.Operand2;
                        managedOperands[2] = this.Operand3;
                        managedOperands[3] = this.Operand4;
                        managedOperands[4] = this.Operand5;
                        managedOperands[5] = this.Operand6;

                        break;
                    case 7:
                        managedOperands[0] = this.Operand1;
                        managedOperands[1] = this.Operand2;
                        managedOperands[2] = this.Operand3;
                        managedOperands[3] = this.Operand4;
                        managedOperands[4] = this.Operand5;
                        managedOperands[5] = this.Operand6;
                        managedOperands[6] = this.Operand7;

                        break;
                    case 8:
                        managedOperands[0] = this.Operand1;
                        managedOperands[1] = this.Operand2;
                        managedOperands[2] = this.Operand3;
                        managedOperands[3] = this.Operand4;
                        managedOperands[4] = this.Operand5;
                        managedOperands[5] = this.Operand6;
                        managedOperands[6] = this.Operand7;
                        managedOperands[7] = this.Operand8;

                        break;
                }

                return managedOperands;
            }
        }
    }
}