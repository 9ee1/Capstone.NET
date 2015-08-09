namespace Gee.External.Capstone.Arm {
    /// <summary>
    ///     ARM Instruction Detail.
    /// </summary>
    public sealed class ArmInstructionDetail {
        /// <summary>
        ///     Get Instruction's Code Condition.
        /// </summary>
        public ArmCodeCondition CodeCondition { get; internal set; }

        /// <summary>
        ///     Get Instruction's CPS Flag.
        /// </summary>
        public ArmCpsFlag CpsFlag { get; internal set; }

        /// <summary>
        ///     Get Instruction's CPS Mode.
        /// </summary>
        public ArmCpsMode CpsMode { get; internal set; }

        /// <summary>
        ///     Get Instruction's Load User Mode Registers Flag.
        /// </summary>
        public bool LoadUserModeRegisters { get; internal set; }

        /// <summary>
        ///     Get Instruction's Memory Barrier.
        /// </summary>
        public ArmMemoryBarrier MemoryBarrier { get; internal set; }

        /// <summary>
        ///     Get Instruction's Operands.
        /// </summary>
        public ArmInstructionOperand[] Operands { get; internal set; }

        /// <summary>
        ///     Get Instruction's Update Flags Flag.
        /// </summary>
        public bool UpdateFlags { get; internal set; }

        /// <summary>
        ///     Get Instruction's Vector Data Type.
        /// </summary>
        public ArmVectorDataType VectorDataType { get; internal set; }

        /// <summary>
        ///     Get Instruction's Vector Size.
        /// </summary>
        public int VectorSize { get; internal set; }

        /// <summary>
        ///     Get Instruction's Write Back Flag.
        /// </summary>
        public bool WriteBack { get; internal set; }

        /// <summary>
        ///     Create an ARM Instruction Detail.
        /// </summary>
        internal ArmInstructionDetail() {}
    }
}