using System;
using System.Linq;

namespace Gee.External.Capstone {
    /// <summary>
    ///     Native Architecture Independent Instruction Detail Extension.
    /// </summary>
    public static class NativeIndependentInstructionDetailExtension {
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