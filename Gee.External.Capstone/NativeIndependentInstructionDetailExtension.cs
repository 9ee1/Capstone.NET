using Gee.External.Capstone.Arm;
using Gee.External.Capstone.Arm64;
using System;
using System.Linq;
using Gee.External.Capstone.X86;

namespace Gee.External.Capstone {
    /// <summary>
    ///     Native Architecture Independent Instruction Detail Extension.
    /// </summary>
    public static class NativeIndependentInstructionDetailExtension {
        /// <summary>
        ///     Create an ARM Independent Instruction Detail.
        /// </summary>
        /// <param name="this">
        ///     A native architecture independent instruction detail.
        /// </param>
        /// <returns>
        ///     An independent instruction detail.
        /// </returns>
        public static IndependentInstructionDetail<ArmRegister, ArmInstructionGroup> AsArmIndependentInstructionDetail(this NativeIndependentInstructionDetail @this) {
            var @object = new IndependentInstructionDetail<ArmRegister, ArmInstructionGroup>();
            @object.Groups = @this.ManagedGroups
                .Select(m => (ArmInstructionGroup) Convert.ToInt32(m))
                .ToArray();

            @object.ReadRegisters = @this.ManagedReadRegisters
                .Select(m => (ArmRegister) Convert.ToInt32(m))
                .ToArray();

            @object.WrittenRegisters = @this.ManagedWrittenRegisters
                .Select(m => (ArmRegister) Convert.ToInt32(m))
                .ToArray();

            return @object;
        }

        /// <summary>
        ///     Convert a Native Architecture Independent Instruction Detail to an ARM64 Independent Instruction Detail.
        /// </summary>
        /// <param name="this">
        ///     A native architecture independent instruction detail.
        /// </param>
        /// <returns>
        ///     An independent instruction detail.
        /// </returns>
        public static IndependentInstructionDetail<Arm64Register, Arm64InstructionGroup> AsArm64IndependentInstructionDetail(this NativeIndependentInstructionDetail @this) {
            var @object = new IndependentInstructionDetail<Arm64Register, Arm64InstructionGroup>();
            @object.Groups = @this.ManagedGroups
                .Select(m => (Arm64InstructionGroup) Convert.ToInt32(m))
                .ToArray();

            @object.ReadRegisters = @this.ManagedReadRegisters
                .Select(m => (Arm64Register) Convert.ToInt32(m))
                .ToArray();

            @object.WrittenRegisters = @this.ManagedWrittenRegisters
                .Select(m => (Arm64Register) Convert.ToInt32(m))
                .ToArray();

            return @object;
        }

        /// <summary>
        ///     Convert a Native Architecture Independent Instruction Detail to an X86 Independent Instruction Detail.
        /// </summary>
        /// <param name="this">
        ///     A native architecture independent instruction detail.
        /// </param>
        /// <returns>
        ///     An independent instruction detail.
        /// </returns>
        public static IndependentInstructionDetail<X86Register, X86InstructionGroup> AsX86IndependentInstructionDetail(this NativeIndependentInstructionDetail @this) {
            var @object = new IndependentInstructionDetail<X86Register, X86InstructionGroup>();
            @object.Groups = @this.ManagedGroups
                .Select(m => (X86InstructionGroup) Convert.ToInt32(m))
                .ToArray();

            @object.ReadRegisters = @this.ManagedReadRegisters
                .Select(m => (X86Register) Convert.ToInt32(m))
                .ToArray();

            @object.WrittenRegisters = @this.ManagedWrittenRegisters
                .Select(m => (X86Register) Convert.ToInt32(m))
                .ToArray();

            return @object;
        }
    }
}