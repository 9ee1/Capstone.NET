using System;
using System.Runtime.InteropServices;

namespace Gee.External.Capstone {
    /// <summary>
    ///     Native Architecture Independent Instruction Detail.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct NativeIndependentInstructionDetail {
        /// <summary>
        ///     Implicit Registers Read by an Instruction.
        /// </summary>
        public fixed byte ReadRegisters [12];

        /// <summary>
        ///     Number of Implicit Registers Read by an Instruction.
        /// </summary>
        public byte ReadRegisterCount;

        /// <summary>
        ///     Implicit Registers Written by an Instruction.
        /// </summary>
        public fixed byte WrittenRegisters [20];

        /// <summary>
        ///     Number of Implicit Registers Written by an Instruction.
        /// </summary>
        public byte WrittenRegisterCount;

        /// <summary>
        ///     Groups an Instruction Belongs to.
        /// </summary>
        public fixed byte Groups [8];

        /// <summary>
        ///     Number of Groups an Instruction Belongs to.
        /// </summary>
        public byte GroupCount;

        /// <summary>
        ///     Instruction's X86 Architecture Detail.
        /// </summary>
        public NativeX86InstructionDetail X86Detail;

        /// <summary>
        ///     Get Managed Implicit Registers Read by an Instruction.
        /// </summary>
        /// <value>
        ///     Convenient property to retrieve the implicit registers read by an instruction as a managed collection.
        ///     The size of the managed collection will always be equal to the value represented by
        ///     <c>NativeInstructionIndependentDetail.ReadRegisterCount</c>. This property allocates managed memory
        ///     for a new managed collection and uses direct memory copying to copy the collection from unmanaged
        ///     memory to managed memory every time it is invoked.
        /// </value>
        public byte[] ManagedReadRegisters {
            get {
                fixed (byte* pReadRegisters = this.ReadRegisters) {
                    var pPReadRegisters = new IntPtr(pReadRegisters);
                    var managedReadRegisters = new byte[this.ReadRegisterCount];

                    Marshal.Copy(pPReadRegisters, managedReadRegisters, 0, this.ReadRegisterCount);
                    return managedReadRegisters;
                }
            }
        }

        /// <summary>
        ///     Get Managed Implicit Registers Written by an Instruction.
        /// </summary>
        /// <value>
        ///     Convenient property to retrieve the implicit registers written by an instruction as a managed
        ///     collection. The size of the managed collection will always be equal to the value represented by
        ///     <c>NativeInstructionIndependentDetail.WrittenRegisterCount</c>. This property allocates managed memory
        ///     for a new managed collection and uses direct memory copying to copy the collection from unmanaged
        ///     memory to managed memory every time it is invoked.
        /// </value>
        public byte[] ManagedWrittenRegisters {
            get {
                fixed (byte* pWrittenRegisters = this.WrittenRegisters) {
                    var pPWrittenRegisters = new IntPtr(pWrittenRegisters);
                    var managedWrittenRegisters = new byte[this.WrittenRegisterCount];

                    Marshal.Copy(pPWrittenRegisters, managedWrittenRegisters, 0, this.WrittenRegisterCount);
                    return managedWrittenRegisters;
                }
            }
        }

        /// <summary>
        ///     Get Managed Groups an Instruction Belongs to.
        /// </summary>
        /// <value>
        ///     Convenient property to retrieve the implicit groups an instruction belongs to as a managed collection.
        ///     The size of the managed collection will always be equal to the value represented by
        ///     <c>NativeInstructionIndependentDetail.GroupCount</c>. This property allocates managed memory for a new
        ///     managed collection and uses direct memory copying to copy the collection from unmanaged memory to
        ///     managed memory every time it is invoked.
        /// </value>
        public byte[] ManagedGroups {
            get {
                fixed (byte* pGroups = this.Groups) {
                    var pPGroups = new IntPtr(pGroups);
                    var managedGroups = new byte[this.GroupCount];

                    Marshal.Copy(pPGroups, managedGroups, 0, this.GroupCount);
                    return managedGroups;
                }
            }
        }
    }
}