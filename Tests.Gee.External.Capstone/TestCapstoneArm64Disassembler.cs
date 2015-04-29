using Gee.External.Capstone;
using NUnit.Framework;

namespace Tests.Gee.External.Capstone {
    /// <summary>
    ///     Test Capstone ARM64 Disassembler.
    /// </summary>
    [TestFixture]
    public sealed class TestCapstoneArm64Disassembler {
        /// <summary>
        ///     Test Create.
        /// </summary>
        [Test]
        public void TestCreate() {
            var disassembler = CapstoneDisassembler.CreateArm64Disassembler(DisassembleMode.Arm32);
            Assert.IsNotNull(disassembler);
            Assert.AreEqual(disassembler.Architecture, DisassembleArchitecture.Arm64);
            Assert.AreEqual(disassembler.EnableDetails, false);
            Assert.AreEqual(disassembler.Mode, DisassembleMode.Arm32);
            Assert.AreEqual(disassembler.Syntax, DisassembleSyntaxOptionValue.Default);
        }

        /// <summary>
        ///     Test Disassemble.
        /// </summary>
        [Test]
        public void TestDisassemble() {
            // Create X86 Disassembler.
            //
            // Creating the disassembler in a "using" statement ensures that resources get cleaned up automatically
            // when it is no longer needed.
            using (var disassembler = CapstoneDisassembler.CreateArm64Disassembler(DisassembleMode.Arm32)) {
                Assert.IsNotNull(disassembler);

                // Enable Disassemble Details.
                //
                // Enables disassemble details, which are disabled by default, to provide more detailed information on
                // disassembled binary code.
                disassembler.EnableDetails = true;

                // Set Disassembler's Syntax.
                //
                // Make the disassembler generate instructions in Intel syntax.
                disassembler.Syntax = DisassembleSyntaxOptionValue.Intel;

                // Disassemble All Binary Code.
                //
                // ...
                var code = new byte[] {0x09, 0x00, 0x38, 0xd5, 0xbf, 0x40, 0x00, 0xd5, 0x0c, 0x05, 0x13, 0xd5, 0x20, 0x50, 0x02, 0x0e, 0x20, 0xe4, 0x3d, 0x0f, 0x00, 0x18, 0xa0, 0x5f, 0xa2, 0x00, 0xae, 0x9e, 0x9f, 0x37, 0x03, 0xd5, 0xbf, 0x33, 0x03, 0xd5, 0xdf, 0x3f, 0x03, 0xd5, 0x21, 0x7c, 0x02, 0x9b, 0x21, 0x7c, 0x00, 0x53, 0x00, 0x40, 0x21, 0x4b, 0xe1, 0x0b, 0x40, 0xb9, 0x20, 0x04, 0x81, 0xda, 0x20, 0x08, 0x02, 0x8b, 0x10, 0x5b, 0xe8, 0x3c};
                var instructions = disassembler.DisassembleAll(code, 0x2C);
                //Assert.AreEqual(instructions.Length, 2);
            }
        }
    }
}