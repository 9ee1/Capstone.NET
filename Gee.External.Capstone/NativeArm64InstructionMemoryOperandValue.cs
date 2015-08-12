using System.Runtime.InteropServices;

namespace Gee.External.Capstone.Arm64 {
    /// <summary>
    ///     Native ARM64 Instruction Memory Operand Value.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct NativeArm64InstructionMemoryOperandValue {
        /// <summary>
        ///     Operand Value's Base Register.
        /// </summary>
        public uint BaseRegister;

        /// <summary>
        ///     Operand Value's Index Register.
        /// </summary>
        public uint IndexRegister;

        /// <summary>
        ///     Operand Value's Displacement Value.
        /// </summary>
        public int Displacement;

        /// <summary>
        ///     Get Operand Value's Managed Base Register.
        /// </summary>
        /// <value>
        ///     Convenient property to retrieve the operand value's base register as a managed enumerated type.
        /// </value>
        public Arm64Register ManagedBaseRegister {
            get {
                var @enum = (Arm64Register) this.BaseRegister;
                return @enum;
            }
        }

        /// <summary>
        ///     Get Operand Value's Managed Index Register.
        /// </summary>
        /// <value>
        ///     Convenient property to retrieve the operand value's index register as a managed enumerated type.
        /// </value>
        public Arm64Register ManagedIndexRegister {
            get {
                var @enum = (Arm64Register) this.IndexRegister;
                return @enum;
            }
        }
    }
}