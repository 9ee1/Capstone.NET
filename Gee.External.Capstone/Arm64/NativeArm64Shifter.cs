using System.Runtime.InteropServices;

namespace Gee.External.Capstone.Arm64 {
    /// <summary>
    ///     Native ARM64 Shifter.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct NativeArm64Shifter {
        /// <summary>
        ///     Shifter's Type.
        /// </summary>
        public int Type;

        /// <summary>
        ///     Shifter's Value.
        /// </summary>
        public uint Value;

        /// <summary>
        ///     Get Shifter's Managed Type.
        /// </summary>
        /// <value>
        ///     Convenient property to retrieve the shifter's type as a managed enumerated type.
        /// </value>
        public Arm64ShifterType ManagedType {
            get {
                var @enum = (Arm64ShifterType) this.Type;
                return @enum;
            }
        }
    }
}