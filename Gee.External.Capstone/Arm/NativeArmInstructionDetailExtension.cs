using System.Linq;

namespace Gee.External.Capstone.Arm {
    /// <summary>
    ///     Native ARM Instruction Detail Extension.
    /// </summary>
    public static class NativeArmInstructionDetailExtension {
        /// <summary>
        ///     Create an ARM Instruction Detail.
        /// </summary>
        /// <param name="this">
        ///     A native ARM instruction detail.
        /// </param>
        /// <returns>
        ///     An ARM instruction detail.
        /// </returns>
        public static ArmInstructionDetail AsArmInstructionDetail(this NativeArmInstructionDetail @this) {
            var @object = new ArmInstructionDetail();
            @object.CodeCondition = @this.ManagedCodeCondition;
            @object.CpsFlag = @this.ManagedCpsFlag;
            @object.CpsMode = @this.ManagedCpsMode;
            @object.LoadUserModeRegisters = @this.LoadUserModeRegisters;
            @object.MemoryBarrier = @this.ManagedMemoryBarrier;
            @object.UpdateFlags = @this.UpdateFlags;
            @object.VectorDataType = @this.ManagedVectorDataType;
            @object.VectorSize = @this.VectorSize;
            @object.WriteBack = @this.WriteBack;

            // Set Operands.
            //
            // ...
            @object.Operands = @this.ManagedOperands
                .Select(m => m.AsArmInstructionOperand())
                .ToArray();

            return @object;
        }
    }
}