using System.Linq;

namespace Gee.External.Capstone.Arm64 {
    /// <summary>
    ///     Native ARM64 Instruction Detail Extension.
    /// </summary>
    public static class NativeArm64InstructionDetailExtension {
        /// <summary>
        ///     Create an ARm64 Instruction Detail From a Native ARM64 Instruction Detail.
        /// </summary>
        /// <param name="this">
        ///     A native ARM64 instruction detail.
        /// </param>
        /// <param name="instruction">
        ///     The instruction the detail belongs to.
        /// </param>
        /// <returns>
        ///     An ARM64 instruction detail.
        /// </returns>
        public static Arm64InstructionDetail AsArm64InstructionDetail(this NativeArm64InstructionDetail @this, Arm64Instruction instruction) {
            var @object = new Arm64InstructionDetail();
            @object.CodeCondition = @this.ManagedCodeCondition;
            @object.Operands = @this.ManagedOperands.Select(m => m.AsArm64InstructionOperand(instruction)).ToArray();

            return @object;
        }
    }
}