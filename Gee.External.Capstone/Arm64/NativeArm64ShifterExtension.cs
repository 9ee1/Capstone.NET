namespace Gee.External.Capstone.Arm64 {
    /// <summary>
    ///     Native ARM64 Shifter Extension.
    /// </summary>
    public static class NativeArm64ShifterExtension {
        /// <summary>
        ///     Convert a Native ARM64 Shifter to an ARM64 Shifter.
        /// </summary>
        /// <param name="this">
        ///     A native ARM64 shifter.
        /// </param>
        /// <returns>
        ///     An ARM64 shifter.
        /// </returns>
        public static Arm64Shifter AsArm64Shifter(this NativeArm64Shifter @this) {
            var @object = new Arm64Shifter();
            @object.Type = @this.ManagedType;
            @object.Value = (int) @this.Value;

            return @object;
        }
    }
}