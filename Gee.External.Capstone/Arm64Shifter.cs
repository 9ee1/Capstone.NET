namespace Gee.External.Capstone.Arm64 {
    /// <summary>
    ///     ARM64 Shifter.
    /// </summary>
    public sealed class Arm64Shifter {
        /// <summary>
        ///     Shifter's Type.
        /// </summary>
        public Arm64ShifterType Type { get; internal set; }

        /// <summary>
        ///     Shifter's Value.
        /// </summary>
        public int Value { get; internal set; }

        /// <summary>
        ///     Create an ARM64 Shifter.
        /// </summary>
        internal Arm64Shifter() {}
    }
}