using System;
using System.Linq;

namespace Gee.External.Capstone {
    /// <summary>
    ///     Native X86 Instruction Detail Extension.
    /// </summary>
    public static class NativeX86InstructionDetailExtension {
        /// <summary>
        ///     Create an X86 Instruction Detail From a Native X86 Instruction Detail.
        /// </summary>
        /// <param name="this">
        ///     A native X86 instruction detail.
        /// </param>
        /// <returns>
        ///     An X86 instruction detail.
        /// </returns>
        public static X86InstructionDetail AsX86InstructionDetail(this NativeX86InstructionDetail @this) {
            var @object = new X86InstructionDetail();
            @object.AddressSize = @this.AddressSize;
            @object.AvxCodeCondition = @this.ManagedAvxCodeCondition;
            @object.AvxRoundingMode = @this.ManagedAvxRoundingMode;
            @object.Displacement = @this.Displacement;
            @object.ModRm = @this.ModRm;
            @object.Operands = @this.ManagedOperands.Select(m => m.AsX86InstructionOperand()).ToArray();
            @object.OperationCode = @this.ManagedOperationCode;
            @object.Prefix = @this.ManagedPrefix.Select(m => (X86Prefix) Convert.ToInt32(m)).ToArray();
            @object.Rex = @this.Rex;
            @object.Sib = @this.Sib;
            @object.SibBaseRegister = @this.ManagedSibBaseRegister;
            @object.SibIndexRegister = @this.ManagedSibIndexRegister;
            @object.SibScale = @this.SibScale;
            @object.SseCodeCondition = @this.ManagedSseCodeCondition;
            @object.SuppressAllAvxExceptions = @this.AvxSuppressAllExceptions;

            return @object;
        }
    }
}