namespace Gee.External.Capstone.X86 {
    /// <summary>
    ///     X86 Encoding Builder.
    /// </summary>
    internal sealed class X86EncodingBuilder {
        /// <summary>
        ///     Get and Set Displacement Offset.
        /// </summary>
        internal byte DisplacementOffset { get; private set; }

        /// <summary>
        ///     Get and Set Displacement Size.
        /// </summary>
        internal byte DisplacementSize { get; private set; }

        /// <summary>
        ///     Get and Set Immediate Offset.
        /// </summary>
        internal byte ImmediateOffset { get; private set; }

        /// <summary>
        ///     Get and Set Immediate Size.
        /// </summary>
        internal byte ImmediateSize { get; private set; }

        /// <summary>
        ///     Get and Set ModR/M Offset.
        /// </summary>
        internal byte ModRmOffset { get; private set; }

        /// <summary>
        ///     Build an X86 Encoding Builder.
        /// </summary>
        /// <param name="disassembler">
        ///     A disassembler.
        /// </param>
        /// <param name="nativeEncoding">
        ///     A native X86 encoding.
        /// </param>
        /// <returns>
        ///     This builder.
        /// </returns>
        internal X86EncodingBuilder Build(CapstoneDisassembler disassembler, ref NativeX86Encoding nativeEncoding) {
            this.DisplacementOffset = nativeEncoding.DisplacementOffset;
            this.DisplacementSize = nativeEncoding.DisplacementSize;
            this.ImmediateOffset = nativeEncoding.ImmediateOffset;
            this.ImmediateSize = nativeEncoding.ImmediateSize;
            this.ModRmOffset = nativeEncoding.ModRmOffset;

            return this;
        }

        /// <summary>
        ///     Create an X86 Encoding.
        /// </summary>
        /// <returns>
        ///     An X86 encoding.
        /// </returns>
        internal X86Encoding Create() {
            return new X86Encoding(this);
        }
    }
}