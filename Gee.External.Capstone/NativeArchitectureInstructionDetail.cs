using System.Runtime.InteropServices;
using Gee.External.Capstone.Arm;
using Gee.External.Capstone.Arm64;
using Gee.External.Capstone.Mips;
using Gee.External.Capstone.PowerPc;
using Gee.External.Capstone.Sparc;
using Gee.External.Capstone.SystemZ;
using Gee.External.Capstone.XCore;

namespace Gee.External.Capstone {
    /// <summary>
    ///     Native Architecture Dependent Instruction Detail.
    /// </summary>
    [StructLayout(LayoutKind.Explicit)]
    public struct NativeArchitectureInstructionDetail {
        /// <summary>
        ///     Instruction's X86 Architecture Detail.
        /// </summary>
        [FieldOffset(0)] public NativeX86InstructionDetail X86Detail;

        /// <summary>
        ///     Instruction's ARM64 Architecture Detail.
        /// </summary>
        [FieldOffset(0)] public NativeArm64InstructionDetail Arm64Detail;

        // <summary>
        ///     Instruction's ARM64 Architecture Detail.
        /// </summary>
        [FieldOffset(0)] public NativeArmInstructionDetail ArmDetail;

        /// <summary>
        ///     Instruction's MIPS Architecture Detail.
        /// </summary>
        [FieldOffset(0)] public NativeMipsInstructionDetail MipsDetail;

        /// <summary>
        ///     Instruction's PowerPC Architecture Detail.
        /// </summary>
        [FieldOffset(0)] public NativePowerPcInstructionDetail PowerPcDetail;

        /// <summary>
        ///     Instruction's SPARC Architecture Detail.
        /// </summary>
        [FieldOffset(0)] public NativeSparcInstructionDetail SparcDetail;

        /// <summary>
        ///     Instruction's SystemZ Architecture Detail.
        /// </summary>
        [FieldOffset(0)] public NativeSystemZInstructionDetail SystemZDetail;

        /// <summary>
        ///     Instruction's XCore Architecture Detail.
        /// </summary>
        [FieldOffset(0)] public NativeXCoreInstructionDetail XCoreDetail;
    }
}