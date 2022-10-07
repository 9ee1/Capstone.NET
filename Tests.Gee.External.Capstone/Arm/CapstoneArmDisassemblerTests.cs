using FluentAssertions;
using Gee.External.Capstone;
using Gee.External.Capstone.Arm;
using System.Diagnostics.CodeAnalysis;
using Xunit;

namespace Tests.Gee.External.Capstone.Arm;

[ExcludeFromCodeCoverage]
public sealed class CapstoneArmDisassemblerTests {
    [Fact]
    public void DisassembleArm_A() {
        var binaryCode = new byte[] { 0x04, 0xE0, 0x2D, 0xE5 };
        using var disassembler = CapstoneDisassembler.CreateArmDisassembler(ArmDisassembleMode.Arm);

        disassembler.DisassembleSyntax = DisassembleSyntax.Intel;
        disassembler.EnableInstructionDetails = true;
        var disassembledCode = disassembler.Disassemble(binaryCode);
        disassembledCode.Length.Should().Be(1);

        var instruction = disassembledCode[0];
        instruction.DisassembleArchitecture.Should().Be(DisassembleArchitecture.Arm);
        instruction.DisassembleMode.Should().Be(ArmDisassembleMode.Arm);
        $"{instruction.Mnemonic} {instruction.Operand}".Should().Be("str lr, [sp, #-4]!");
    }

    [Fact]
    public void DisassembleArm_B() {
        var binaryCode = new byte[] { 0xE0, 0x83, 0x22, 0xE5 };
        using var disassembler = CapstoneDisassembler.CreateArmDisassembler(ArmDisassembleMode.Arm);

        disassembler.DisassembleSyntax = DisassembleSyntax.Intel;
        disassembler.EnableInstructionDetails = true;
        var disassembledCode = disassembler.Disassemble(binaryCode);
        disassembledCode.Length.Should().Be(1);

        var instruction = disassembledCode[0];
        instruction.DisassembleArchitecture.Should().Be(DisassembleArchitecture.Arm);
        instruction.DisassembleMode.Should().Be(ArmDisassembleMode.Arm);
        $"{instruction.Mnemonic} {instruction.Operand}".Should().Be("str r8, [r2, #-0x3e0]!");
    }

    [Fact]
    public void DisassembleArmV8_A() {
        var binaryCode = new byte[] { 0xE0, 0x3B, 0xB2, 0xEE, 0x42, 0x00, 0x01, 0xE1, 0x51, 0xF0, 0x7F, 0xF5 };
        using var disassembler = CapstoneDisassembler.CreateArmDisassembler(ArmDisassembleMode.Arm | ArmDisassembleMode.V8);

        disassembler.DisassembleSyntax = DisassembleSyntax.Intel;
        disassembler.EnableInstructionDetails = true;
        var disassembledCode = disassembler.Disassemble(binaryCode);
        disassembledCode.Length.Should().Be(3);

        var instruction = disassembledCode[0];
        instruction.DisassembleArchitecture.Should().Be(DisassembleArchitecture.Arm);
        instruction.DisassembleMode.Should().Be(ArmDisassembleMode.Arm | ArmDisassembleMode.V8);
        $"{instruction.Mnemonic} {instruction.Operand}".Should().Be("vcvtt.f64.f16 d3, s1");

        instruction = disassembledCode[1];
        instruction.DisassembleArchitecture.Should().Be(DisassembleArchitecture.Arm);
        instruction.DisassembleMode.Should().Be(ArmDisassembleMode.Arm | ArmDisassembleMode.V8);
        $"{instruction.Mnemonic} {instruction.Operand}".Should().Be("crc32b r0, r1, r2");

        instruction = disassembledCode[2];
        instruction.DisassembleArchitecture.Should().Be(DisassembleArchitecture.Arm);
        instruction.DisassembleMode.Should().Be(ArmDisassembleMode.Arm | ArmDisassembleMode.V8);
        $"{instruction.Mnemonic} {instruction.Operand}".Should().Be("dmb oshld");
    }

    [Fact]
    public void DisassembleThumbCortexM_A() {
        var binaryCode = new byte[] { 0xEF, 0xF3, 0x02, 0x80 };
        using var disassembler = CapstoneDisassembler.CreateArmDisassembler(ArmDisassembleMode.Thumb | ArmDisassembleMode.CortexM);

        disassembler.DisassembleSyntax = DisassembleSyntax.Intel;
        disassembler.EnableInstructionDetails = true;
        var disassembledCode = disassembler.Disassemble(binaryCode);
        disassembledCode.Length.Should().Be(1);

        var instruction = disassembledCode[0];
        instruction.DisassembleArchitecture.Should().Be(DisassembleArchitecture.Arm);
        instruction.DisassembleMode.Should().Be(ArmDisassembleMode.Thumb | ArmDisassembleMode.CortexM);
        $"{instruction.Mnemonic} {instruction.Operand}".Should().Be("mrs r0, eapsr");
    }
}