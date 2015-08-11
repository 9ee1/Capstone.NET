namespace Gee.External.Capstone.Arm {
    /// <summary>
    ///     ARM64 Shifter.
    /// </summary>
    public sealed class ArmShifter {
        /// <summary>
        ///     Shifter Type.
        /// </summary>
        public ArmShifterType Type { get; internal set; }

        /// <summary>
        ///     Shifter Value.
        /// </summary>
        public int Value { get; internal set; }

        /// <summary>
        ///     Create an ARM Shifter.
        /// </summary>
        internal ArmShifter() { }
    }
}