using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

namespace Gee.External.Capstone {
    [SuppressMessage("ReSharper", "FieldCanBeMadeReadOnly.Global")]
    [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    internal struct NativeInstructionDetail {
        /// <summary>
        ///     Implicit Registers Read by an Instruction.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 12)]
        public short[] ReadRegisters;

        /// <summary>
        ///     Number of Implicit Registers Read by an Instruction.
        /// </summary>
        public byte ReadRegistersCount;

        /// <summary>
        ///     Implicit Registers Written by an Instruction.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
        public short[] WrittenRegisters;

        /// <summary>
        ///     Number of Implicit Registers Written by an Instruction.
        /// </summary>
        public byte WrittenRegisterCount;

        /// <summary>
        ///     Groups an Instruction Belongs to.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public byte[] Groups;

        /// <summary>
        ///     Number of Groups an Instruction Belongs to.
        /// </summary>
        public byte GroupCount;
    }
}