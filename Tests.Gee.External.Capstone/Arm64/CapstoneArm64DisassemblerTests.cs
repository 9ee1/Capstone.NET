using FluentAssertions;
using Gee.External.Capstone;
using Gee.External.Capstone.Arm64;
using System.Diagnostics.CodeAnalysis;
using Xunit;

namespace Tests.Gee.External.Capstone.Arm64;

[ExcludeFromCodeCoverage]
public sealed class CapstoneArm64DisassemblerTests {
    [Fact]
    public void DisassembleArm_A() {
        var binaryCode = new byte[] { 0xE1, 0x0B, 0x40, 0xB9 };
        using var disassembler = CapstoneDisassembler.CreateArm64Disassembler(Arm64DisassembleMode.Arm);

        disassembler.DisassembleSyntax = DisassembleSyntax.Intel;
        disassembler.EnableInstructionDetails = true;
        var disassembledCode = disassembler.Disassemble(binaryCode);
        disassembledCode.Length.Should().Be(1);

        var instruction = disassembledCode[0];
        instruction.DisassembleArchitecture.Should().Be(DisassembleArchitecture.Arm64);
        instruction.DisassembleMode.Should().Be(Arm64DisassembleMode.Arm);
        $"{instruction.Mnemonic} {instruction.Operand}".Should().Be("ldr w1, [sp, #8]");
    }

    [Fact]
    public void DisassembleArm_B() {
        var binaryCode = new byte[] { 0x20, 0x04, 0x81, 0xDA };
        using var disassembler = CapstoneDisassembler.CreateArm64Disassembler(Arm64DisassembleMode.Arm);

        disassembler.DisassembleSyntax = DisassembleSyntax.Intel;
        disassembler.EnableInstructionDetails = true;
        var disassembledCode = disassembler.Disassemble(binaryCode);
        disassembledCode.Length.Should().Be(1);

        var instruction = disassembledCode[0];
        instruction.DisassembleArchitecture.Should().Be(DisassembleArchitecture.Arm64);
        instruction.DisassembleMode.Should().Be(Arm64DisassembleMode.Arm);
        $"{instruction.Mnemonic} {instruction.Operand}".Should().Be("cneg x0, x1, ne");
    }
}