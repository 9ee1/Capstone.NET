using System.Runtime.InteropServices;

namespace Gee.External.Capstone.Arm64 {
    /// <summary>
    ///     Native ARM64 Instruction Operand Value.
    /// </summary>
    [StructLayout(LayoutKind.Explicit)]
    public struct NativeArm64InstructionOperandValue {
        /// <summary>
        ///     Operand Value's Register Value.
        /// </summary>
        [FieldOffset(0)] public uint Register;

        /// <summary>
        ///     Operand Value's Immediate Value.
        /// </summary>
        [FieldOffset(0)] public long Immediate;

        /// <summary>
        ///     Operand Value's Floating Point Value.
        /// </summary>
        [FieldOffset(0)] public double FloatingPoint;

        /// <summary>
        ///     Operand Value's Memory Value.
        /// </summary>
        [FieldOffset(0)] public NativeArm64InstructionMemoryOperandValue Memory;

        /// <summary>
        ///     Operand Value's PState Value.
        /// </summary>
        [FieldOffset(0)] public int PState;

        /// <summary>
        ///     Operand Value's SYS Operation.
        /// </summary>
        [FieldOffset(0)] public uint SysOperation;

        /// <summary>
        ///     Operand Value's Prefetch Operation.
        /// </summary>
        [FieldOffset(0)] public int PrefetchOperation;

        /// <summary>
        ///     Operand Value's Memory Barrier Operation.
        /// </summary>
        [FieldOffset(0)] public int MemoryBarrierOperation;

        /// <summary>
        ///     Get Operand Value's Managed Memory Barrier Operation.
        /// </summary>
        /// <value>
        ///     Convenient property to retrieve the operand value's memory barrier operation as a managed enumerated
        ///     type.
        /// </value>
        public Arm64MemoryBarrierOperation ManagedMemoryBarrierOperation {
            get {
                var @enum = (Arm64MemoryBarrierOperation) this.MemoryBarrierOperation;
                return @enum;
            }
        }

        /// <summary>
        ///     Get Operand Value's Managed Prefetch Operation.
        /// </summary>
        /// <value>
        ///     Convenient property to retrieve the operand value's prefetch operation as a managed enumerated type.
        /// </value>
        public Arm64PrefetchOperation ManagedPrefetchOperation {
            get {
                var @enum = (Arm64PrefetchOperation) this.PrefetchOperation;
                return @enum;
            }
        }

        /// <summary>
        ///     Get Operand Value's Managed PState.
        /// </summary>
        /// <value>
        ///     Convenient property to retrieve the operand value's pstate as a managed enumerated type.
        /// </value>
        public Arm64PState ManagedPState {
            get {
                var @enum = (Arm64PState) this.PState;
                return @enum;
            }
        }

        /// <summary>
        ///     Get Operand Value's Managed Register.
        /// </summary>
        /// <value>
        ///     Convenient property to retrieve the operand value's register as a managed enumerated type.
        /// </value>
        public Arm64Register ManagedRegister {
            get {
                var @enum = (Arm64Register) this.Register;
                return @enum;
            }
        }
    }
}