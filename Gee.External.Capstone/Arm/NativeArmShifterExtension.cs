namespace Gee.External.Capstone.Arm {
    /// <summary>
    ///     Native ARM Shifter Extension.
    /// </summary>
    public static class NativeArmShifterExtension {
        /// <summary>
        ///     Create an ARM Shifter.
        /// </summary>
        /// <param name="this">
        ///     A native ARM shifter.
        /// </param>
        /// <returns>
        ///     An ARM shifter.
        /// </returns>
        public static ArmShifter AsArmShifter(this NativeArmShifter @this) {
            var @object = new ArmShifter();
            @object.Type = (ArmShifterType) @this.Type;
            @object.Value = (int) @this.Value;

            return @object;
        }
    }
}