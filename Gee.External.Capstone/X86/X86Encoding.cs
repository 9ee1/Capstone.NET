namespace Gee.External.Capstone.X86 {
    /// <summary>
    ///     X86 Encoding.
    /// </summary>
    public sealed class X86Encoding {
        /// <summary>
        ///     Get Displacement Offset.
        /// </summary>
        public byte DisplacementOffset { get; }

        /// <summary>
        ///     Get Displacement Size.
        /// </summary>
        public byte DisplacementSize { get; }

        /// <summary>
        ///     Get Immediate Offset.
        /// </summary>
        public byte ImmediateOffset { get; }

        /// <summary>
        ///     Get Immediate Size.
        /// </summary>
        public byte ImmediateSize { get; }

        /// <summary>
        ///     Get ModR/M Offset.
        /// </summary>
        public byte ModRmOffset { get; }

        /// <summary>
        ///     Create an X86 Encoding.
        /// </summary>
        /// <param name="disassembler">
        ///     A disassembler.
        /// </param>
        /// <param name="nativeEncoding">
        ///     A native X86 encoding.
        /// </param>
        /// <returns>
        ///     An X86 encoding.
        /// </returns>
        internal static X86Encoding Create(CapstoneDisassembler disassembler, ref NativeX86Encoding nativeEncoding) {
            return new X86EncodingBuilder().Build(disassembler, ref nativeEncoding).Create();
        }

        /// <summary>
        ///     Create an X86 Encoding.
        /// </summary>
        /// <param name="builder">
        ///     A builder to initialize the object with.
        /// </param>
        internal X86Encoding(X86EncodingBuilder builder) {
            this.DisplacementOffset = builder.DisplacementOffset;
            this.DisplacementSize = builder.DisplacementSize;
            this.ImmediateOffset = builder.ImmediateOffset;
            this.ImmediateSize = builder.ImmediateSize;
            this.ModRmOffset = builder.ModRmOffset;
        }
    }
}