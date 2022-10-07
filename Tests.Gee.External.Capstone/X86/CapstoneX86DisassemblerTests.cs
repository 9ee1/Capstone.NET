using FluentAssertions;
using Gee.External.Capstone;
using Gee.External.Capstone.X86;
using System.Diagnostics.CodeAnalysis;
using Xunit;

namespace Tests.Gee.External.Capstone.X86;

[ExcludeFromCodeCoverage]
public sealed class CapstoneX86DisassemblerTests {
    [Fact]
    public void DisassembleBit32_A() {
        var binaryCode = new byte[] { 0x64, 0xA1, 0x18, 0x00, 0x00, 0x00 };
        using var disassembler = CapstoneDisassembler.CreateX86Disassembler(X86DisassembleMode.Bit32);

        disassembler.DisassembleSyntax = DisassembleSyntax.Intel;
        disassembler.EnableInstructionDetails = true;
        var disassembledCode = disassembler.Disassemble(binaryCode);
        disassembledCode.Length.Should().Be(1);

        var instruction = disassembledCode[0];
        instruction.DisassembleArchitecture.Should().Be(DisassembleArchitecture.X86);
        instruction.DisassembleMode.Should().Be(X86DisassembleMode.Bit32);
        $"{instruction.Mnemonic} {instruction.Operand}".Should().Be("mov eax, dword ptr fs:[0x18]");
    }

    [Fact]
    public void DisassembleBit32_B() {
        var binaryCode = new byte[] { 0xB4, 0xC6 };
        using var disassembler = CapstoneDisassembler.CreateX86Disassembler(X86DisassembleMode.Bit32);

        disassembler.DisassembleSyntax = DisassembleSyntax.Intel;
        disassembler.EnableInstructionDetails = true;
        var disassembledCode = disassembler.Disassemble(binaryCode);
        disassembledCode.Length.Should().Be(1);

        var instruction = disassembledCode[0];
        instruction.DisassembleArchitecture.Should().Be(DisassembleArchitecture.X86);
        instruction.DisassembleMode.Should().Be(X86DisassembleMode.Bit32);
        $"{instruction.Mnemonic} {instruction.Operand}".Should().Be("mov ah, 0xc6");
    }

    [Fact]
    public void DisassembleBit64_A() {
        var binaryCode = new byte[] { 0x55, 0x48, 0x8B, 0x05, 0xB8, 0x13, 0x00, 0x00, 0xE9, 0xEA, 0xBE, 0xAD, 0xDE, 0xFF, 0x25, 0x23, 0x01, 0x00, 0x00, 0xE8, 0xDF, 0xBE, 0xAD, 0xDE, 0x74, 0xFF };
        using var disassembler = CapstoneDisassembler.CreateX86Disassembler(X86DisassembleMode.Bit64);

        disassembler.DisassembleSyntax = DisassembleSyntax.Intel;
        disassembler.EnableInstructionDetails = true;
        var disassembledCode = disassembler.Disassemble(binaryCode);
        disassembledCode.Length.Should().Be(6);

        var instruction = disassembledCode[0];
        instruction.DisassembleArchitecture.Should().Be(DisassembleArchitecture.X86);
        instruction.DisassembleMode.Should().Be(X86DisassembleMode.Bit64);
        $"{instruction.Mnemonic} {instruction.Operand}".Should().Be("push rbp");

        instruction = disassembledCode[1];
        instruction.DisassembleArchitecture.Should().Be(DisassembleArchitecture.X86);
        instruction.DisassembleMode.Should().Be(X86DisassembleMode.Bit64);
        $"{instruction.Mnemonic} {instruction.Operand}".Should().Be("mov rax, qword ptr [rip + 0x13b8]");

        instruction = disassembledCode[2];
        instruction.DisassembleArchitecture.Should().Be(DisassembleArchitecture.X86);
        instruction.DisassembleMode.Should().Be(X86DisassembleMode.Bit64);
        $"{instruction.Mnemonic} {instruction.Operand}".Should().Be("jmp 0xffffffffdeadcef7");

        instruction = disassembledCode[3];
        instruction.DisassembleArchitecture.Should().Be(DisassembleArchitecture.X86);
        instruction.DisassembleMode.Should().Be(X86DisassembleMode.Bit64);
        $"{instruction.Mnemonic} {instruction.Operand}".Should().Be("jmp qword ptr [rip + 0x123]");

        instruction = disassembledCode[4];
        instruction.DisassembleArchitecture.Should().Be(DisassembleArchitecture.X86);
        instruction.DisassembleMode.Should().Be(X86DisassembleMode.Bit64);
        $"{instruction.Mnemonic} {instruction.Operand}".Should().Be("call 0xffffffffdeadcef7");

        instruction = disassembledCode[5];
        instruction.DisassembleArchitecture.Should().Be(DisassembleArchitecture.X86);
        instruction.DisassembleMode.Should().Be(X86DisassembleMode.Bit64);
        $"{instruction.Mnemonic} {instruction.Operand}".Should().Be("je 0x1019");
    }
}