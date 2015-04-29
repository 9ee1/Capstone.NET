using System;
using System.Runtime.InteropServices;
using Gee.External.Capstone.Arm;
using Gee.External.Capstone.Arm64;

namespace Gee.External.Capstone {
    /// <summary>
    ///     Native Instruction.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct NativeInstruction {
        /// <summary>
        ///     Instruction's Unique Identifier.
        /// </summary>
        public uint Id;

        /// <summary>
        ///     Instruction's Address (EIP).
        /// </summary>
        public ulong Address;

        /// <summary>
        ///     Instruction's Size.
        /// </summary>
        public ushort Size;

        /// <summary>
        ///     Instruction's Machine Bytes.
        /// </summary>
        public fixed byte Bytes [16];

        /// <summary>
        ///     Instruction's Mnemonic ASCII Text.
        /// </summary>
        public fixed byte Mnemonic [32];

        /// <summary>
        ///     Instruction's Operand ASCII Text.
        /// </summary>
        public fixed byte Operand [160];

        /// <summary>
        ///     Instruction's Architecture Independent Detail.
        /// </summary>
        public IntPtr IndependentDetail;

        /// <summary>
        ///     Get Instruction's Managed Machine Bytes.
        /// </summary>
        /// <value>
        ///     Convenient property to retrieve the instruction's machine bytes as a managed collection. The size of
        ///     the managed collection will always be equal to the value represented by <c>NativeInstruction.Size</c>.
        ///     This property allocates managed memory for a new managed collection and uses direct memory copying to
        ///     copy the collection from unmanaged memory to managed memory every time it is invoked.
        /// </value>
        public byte[] ManagedBytes {
            get {
                fixed (byte* pBytes = this.Bytes) {
                    var pPBytes = new IntPtr(pBytes);
                    var managedBytes = new byte[this.Size];

                    Marshal.Copy(pPBytes, managedBytes, 0, this.Size);
                    return managedBytes;
                }
            }
        }

        /// <summary>
        ///     Get Instruction's Managed Mnemonic Text.
        /// </summary>
        /// <value>
        ///     Convenient property to retrieve the instruction's mnemonic ASCII text as a managed string. This
        ///     property allocates managed memory for a new managed string every time it is invoked.
        /// </value>
        /// <exception cref="System.ArgumentException">
        ///     Thrown if a managed string could not be initialized.
        /// </exception>
        /// <exception cref="System.ArgumentOutOfRangeException">
        ///     Thrown if the unmanaged string is too large to allocate in managed memory.
        /// </exception>
        /// <exception cref="System.AccessViolationException">
        ///     Thrown if the unmanaged string is inaccessible.
        /// </exception>
        public string ManagedMnemonic {
            get {
                fixed (byte* pMnemonic = this.Mnemonic) {
                    return new string((sbyte*) pMnemonic);
                }
            }
        }

        /// <summary>
        ///     Get Instruction's Managed Operand Text.
        /// </summary>
        /// <value>
        ///     Convenient property to retrieve the instruction's operand ASCII text as a managed string. This
        ///     property allocates managed memory for a new managed string every time it is invoked.
        /// </value>
        /// <exception cref="System.ArgumentException">
        ///     Thrown if a managed string could not be initialized.
        /// </exception>
        /// <exception cref="System.ArgumentOutOfRangeException">
        ///     Thrown if the unmanaged string is too large to allocate in managed memory.
        /// </exception>
        /// <exception cref="System.AccessViolationException">
        ///     Thrown if the unmanaged string is inaccessible.
        /// </exception>
        public string ManagedOperand {
            get {
                fixed (byte* pOperand = this.Operand) {
                    // Create Managed String.
                    //
                    // Throws an exception if the operation fails.
                    return new string((sbyte*) pOperand);
                }
            }
        }

        /// <summary>
        ///     Get Instruction's Managed Architecture Independent Detail.
        /// </summary>
        /// <value>
        ///     Convenient property to retrieve the instruction's architecture independent detail as a managed
        ///     structure. This property allocates managed memory for a new managed structure every time it is
        ///     invoked. If <c>NativeInstruction.IndependentDetail</c> is equal to <c>IntPtr.Zero</c>, a null
        ///     reference is returned. If the unmanaged structure is freed or is inaccessible, the return value is
        ///     undefined.
        /// </value>
        public NativeIndependentInstructionDetail? ManagedIndependentDetail {
            get {
                NativeIndependentInstructionDetail? managedDetail = null;
                if (this.IndependentDetail != IntPtr.Zero) {
                    managedDetail = MarshalExtension.PtrToStructure<NativeIndependentInstructionDetail>(this.IndependentDetail);
                }

                return managedDetail;
            }
        }

        /// <summary>
        ///     Get Instruction's ARM64 Detail.
        /// </summary>
        public NativeArm64InstructionDetail NativeArm64Detail {
            get {
                var pDetail = CapstoneProxyImport.Arm64Detail(this.IndependentDetail);
                var detail = MarshalExtension.PtrToStructure<NativeArm64InstructionDetail>(pDetail);

                return detail;
            }
        }

        /// <summary>
        ///     Get Instruction's ARM Detail.
        /// </summary>
        public NativeArmInstructionDetail NativeArmDetail {
            get {
                var pDetail = CapstoneProxyImport.ArmDetail(this.IndependentDetail);
                var detail = MarshalExtension.PtrToStructure<NativeArmInstructionDetail>(pDetail);

                return detail;
            }
        }

        /// <summary>
        ///     Get Instruction's X86 Detail.
        /// </summary>
        public NativeX86InstructionDetail NativeX86Detail {
            get {
                var pDetail = CapstoneProxyImport.ArmDetail(this.IndependentDetail);
                var detail = MarshalExtension.PtrToStructure<NativeX86InstructionDetail>(pDetail);

                return detail;
            }
        }

        /// <summary>
        ///     Get Object's String Representation.
        /// </summary>
        /// <returns>
        ///     The object's string representation.
        /// </returns>
        public override string ToString() {
            var @string = String.Format("{0} {1}", this.ManagedMnemonic, this.ManagedOperand);
            return @string;
        }
    }
}