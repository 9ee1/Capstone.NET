namespace Gee.External.Capstone;

/// <summary>
///     Represents the syntax a <see cref="CapstoneDisassembler" /> should use for generated assembly code.
/// </summary>
public enum DisassembleSyntax {
    /// <inheritdoc cref="NativeDisassemblerOptionValue.UseAttDisassembleSyntax" />
    Att = NativeDisassemblerOptionValue.UseAttDisassembleSyntax,

    /// <inheritdoc cref="NativeDisassemblerOptionValue.UseIntelDisassembleSyntax" />
    Intel = NativeDisassemblerOptionValue.UseIntelDisassembleSyntax,

    /// <inheritdoc cref="NativeDisassemblerOptionValue.UseMasmDisassembleSyntax" />
    Masm = NativeDisassemblerOptionValue.UseMasmDisassembleSyntax
}