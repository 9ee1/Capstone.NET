using System.Runtime.InteropServices;

namespace Gee.External.Capstone.Arm64 {
    /// <summary>
    ///     Native ARM64 Instruction Operand.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct NativeArm64InstructionOperand {
        /// <summary>
        ///     Operand's Vector Index.
        /// </summary>
        public int VectorIndex;

        /// <summary>
        ///     Operand's Vector Arrangement Specifier.
        /// </summary>
        public int VectorArrangementSpecifier;

        /// <summary>
        ///     Operand's Vector Element Size Specifier.
        /// </summary>
        public int VectorElementSizeSpecifier;

        /// <summary>
        ///     Operand's Shifter.
        /// </summary>
        public NativeArm64Shifter Shifter;

        /// <summary>
        ///     Operand's Extender.
        /// </summary>
        public int Extender;

        /// <summary>
        ///     Operand's Type.
        /// </summary>
        public int Type;

        /// <summary>
        ///     Operand's Value.
        /// </summary>
        public NativeArm64InstructionOperandValue Value;

        /// <summary>
        ///     Get Operand's Managed Extender.
        /// </summary>
        /// <value>
        ///     Convenient property to retrieve the operand's extender as a managed enumerated type.
        /// </value>
        public Arm64Extender ManagedExtender {
            get {
                var @enum = (Arm64Extender) this.Extender;
                return @enum;
            }
        }

        /// <summary>
        ///     Get Operand's Managed Type.
        /// </summary>
        /// <value>
        ///     Convenient property to retrieve the operand's type as a managed enumerated type.
        /// </value>
        public Arm64InstructionOperandType ManagedType {
            get {
                var @enum = (Arm64InstructionOperandType) this.Type;
                return @enum;
            }
        }

        /// <summary>
        ///     Get Instruction's Managed Vector Arrangement Specifier.
        /// </summary>
        /// <value>
        ///     Convenient property to retrieve the instruction's vector arrangement specifier as a managed
        ///     enumerated type.
        /// </value>
        public Arm64VectorArrangementSpecifier ManagedVectorArrangementSpecifier {
            get {
                var @enum = (Arm64VectorArrangementSpecifier) this.VectorArrangementSpecifier;
                return @enum;
            }
        }

        /// <summary>
        ///     Get Instruction's Managed Vector Element Size Specifier.
        /// </summary>
        /// <value>
        ///     Convenient property to retrieve the instruction's vector element size specifier as a managed
        ///     enumerated type.
        /// </value>
        public Arm64VectorElementSizeSpecifier ManagedVectorElementSizeSpecifier {
            get {
                var @enum = (Arm64VectorElementSizeSpecifier) this.VectorElementSizeSpecifier;
                return @enum;
            }
        }
    }
}