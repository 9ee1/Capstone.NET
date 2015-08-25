using Gee.External.Capstone;
using Gee.External.Capstone.Arm;
using NUnit.Framework;
using System.Linq;

namespace Tests.Gee.External.Capstone {
    /// <summary>
    ///     Test Capstone ARM32 Disassembler.
    /// </summary>
    [TestFixture]
    public sealed class TestCapstoneArm32Disassembler {
        private CapstoneDisassembler<ArmInstruction, ArmRegister, ArmInstructionGroup, ArmInstructionDetail> disassembler;

        /// <summary>
        ///     Sets up the unit test state before each run.
        /// </summary>
        [SetUp]
        public void Setup() {
            this.disassembler = CapstoneDisassembler.CreateArmDisassembler(DisassembleMode.Arm32);
        }

        /// <summary>
        ///     Cleans up the unit test after each test run.
        /// </summary>
        [TearDown]
        public void TearDown() {
            if (this.disassembler != null) {
                this.disassembler.Dispose();
                this.disassembler = null;
            }
        }

        /// <summary>
        ///     Convenience function that converts a sequence of little-endian
        ///     uints into an array of bytes, and then disassembles them.
        /// </summary>
        /// <param name="opcodes"></param>
        /// <returns></returns>
        private Instruction<ArmInstruction, ArmRegister, ArmInstructionGroup, ArmInstructionDetail>[] DisassembleInstructions(params uint[] opcodes) {
            var code = opcodes.SelectMany(opc =>
                new byte[] { (byte) opc, (byte) (opc >> 8), (byte) (opc >> 16), (byte) (opc >> 24) })
                .ToArray();
            disassembler.EnableDetails = true;
            return disassembler.DisassembleAll(code, 0x0010000);
        }

        /// <summary>
        ///     Test Create.
        /// </summary>
        [Test]
        public void TestCreate() {
            Assert.IsNotNull(disassembler);
            Assert.AreEqual(disassembler.Architecture, DisassembleArchitecture.Arm);
            Assert.AreEqual(disassembler.EnableDetails, false);
            Assert.AreEqual(disassembler.Mode, DisassembleMode.Arm32);
            Assert.AreEqual(disassembler.Syntax, DisassembleSyntaxOptionValue.Default);
        }

        /// <summary>
        ///     Test Disassemble.
        /// </summary>
        [Test]
        public void TestDisassemble() {
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
            var code = new byte[] { 0x09, 0x00, 0x38, 0xd5, 0xbf, 0x40, 0x00, 0xd5, 0x0c, 0x05, 0x13, 0xd5, 0x20, 0x50, 0x02, 0x0e, 0x20, 0xe4, 0x3d, 0x0f, 0x00, 0x18, 0xa0, 0x5f, 0xa2, 0x00, 0xae, 0x9e, 0x9f, 0x37, 0x03, 0xd5, 0xbf, 0x33, 0x03, 0xd5, 0xdf, 0x3f, 0x03, 0xd5, 0x21, 0x7c, 0x02, 0x9b, 0x21, 0x7c, 0x00, 0x53, 0x00, 0x40, 0x21, 0x4b, 0xe1, 0x0b, 0x40, 0xb9, 0x20, 0x04, 0x81, 0xda, 0x20, 0x08, 0x02, 0x8b, 0x10, 0x5b, 0xe8, 0x3c };
            var instructions = disassembler.DisassembleAll(code, 0x2C);
            //Assert.AreEqual(instructions.Length, 2);
        }

        /// <summary>
        ///     Regression test for Github issue #12 
        ///     (https://github.com/9ee1/Capstone.NET/issues/12)
        /// </summary>
        [Test]
        public void Github_Issue_12() {
            var instr = DisassembleInstructions(0xE19120D3).First();
            Assert.AreEqual("ldrsb r2, [r1, r3]", string.Format("{0} {1}", instr.Mnemonic, instr.Operand));
            Assert.AreEqual(1, instr.ArchitectureDetail.Operands[1].MemoryValue.IndexRegisterScale);

            instr = DisassembleInstructions(0xE11120D3).First();
            Assert.AreEqual("ldrsb r2, [r1, -r3]", string.Format("{0} {1}", instr.Mnemonic, instr.Operand));
            Assert.AreEqual(-1, instr.ArchitectureDetail.Operands[1].MemoryValue.IndexRegisterScale);
        }
    }
}