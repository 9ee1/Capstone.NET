using Gee.External.Capstone;
using System;

namespace CapstoneCMD {
    /// <summary>
    ///     Main Program.
    /// </summary>
    internal static class Program {
        /// <summary>
        ///     Run Main Program.
        /// </summary>
        /// <param name="args">
        ///     A collection of arguments passed from the command line.
        /// </param>
        internal static void Main(string[] args) {
            // Create X86 Disassembler.
            //
            // Creating the disassembler in a "using" statement ensures that resources get cleaned up automatically
            // when it is no longer needed.
            using (var disassembler = CapstoneDisassembler.CreateX86Disassembler(DisassembleMode.Bit32)) {
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
                var code = new byte[] {0x8d, 0x4c, 0x32, 0x08, 0x01, 0xd8, 0x81, 0xc6, 0x34, 0x12, 0x00, 0x00, 0x05, 0x23, 0x01, 0x00, 0x00, 0x36, 0x8b, 0x84, 0x91, 0x23, 0x01, 0x00, 0x00, 0x41, 0x8d, 0x84, 0x39, 0x89, 0x67, 0x00, 0x00, 0x8d, 0x87, 0x89, 0x67, 0x00, 0x00, 0xb4, 0xc6};
                var instructions = disassembler.DisassembleAll(code);

                // Loop Through Each Disassembled Instruction.
                // ...
                foreach (var instruction in instructions) {
                    Console.WriteLine("{0}: {1} ... {2} ... {3}", instruction.Address, instruction.Mnemonic, instruction.Operand, instruction.Id);

                    // Check if Instruction Has Architecture Independent Details.
                    //
                    // Will normally be available if CapstoneDisassembler.EnableDetails is "true".
                    if (instruction.IndependentDetail != null) {
                        Console.WriteLine("\t Groups: {0}", String.Join(",", instruction.IndependentDetail.Groups));
                        Console.WriteLine("\t Read Registers: {0}", String.Join(",", instruction.IndependentDetail.ReadRegisters));
                        Console.WriteLine("\t Written Registers: {0}", String.Join(",", instruction.IndependentDetail.WrittenRegisters));
                    }

                    // Check if Instruction Has Architecture Dependent Details.
                    //
                    // Will normally be available if CapstoneDisassembler.EnableDetails is "true". For this example,
                    // this is all X86 specific details since we created an X86 Disassembler.
                    if (instruction.ArchitectureDetail != null) {
                        Console.WriteLine("\t Address Size: {0}", instruction.ArchitectureDetail.AddressSize);
                        Console.WriteLine("\t AVX Code Condition: {0}", instruction.ArchitectureDetail.AvxCodeCondition);
                        Console.WriteLine("\t AVX Rounding Mode: {0}", instruction.ArchitectureDetail.AvxRoundingMode);
                        Console.WriteLine("\t Displacement: {0}", instruction.ArchitectureDetail.Displacement);
                        Console.WriteLine("\t ModRM: {0}", instruction.ArchitectureDetail.ModRm);

                        // Loop Through Instruction's Operands.
                        //
                        // ...
                        Console.WriteLine("\t Operands:");
                        foreach (var operand in instruction.ArchitectureDetail.Operands) {
                            Console.WriteLine("\t\t Operand Type: {0}", operand.Type);
                            switch (operand.Type) {
                                case X86InstructionOperandType.FloatingPoint:
                                    Console.WriteLine("\t\t Operand Value: {0}", operand.FloatingPointValue);
                                    Console.WriteLine();
                                    break;
                                case X86InstructionOperandType.Immediate:
                                    Console.WriteLine("\t\t Operand Value: {0}", operand.ImmediateValue);
                                    Console.WriteLine();
                                    break;
                                case X86InstructionOperandType.Memory:
                                    Console.WriteLine("\t\t Operand Base Register: {0}", operand.MemoryValue.BaseRegister);
                                    Console.WriteLine("\t\t Operand Displacement: {0}", operand.MemoryValue.Displacement);
                                    Console.WriteLine("\t\t Operand Index Register: {0}", operand.MemoryValue.IndexRegister);
                                    Console.WriteLine("\t\t Operand Index Register Scale: {0}", operand.MemoryValue.IndexRegisterScale);
                                    Console.WriteLine("\t\t Operand Segment Register: {0}", operand.MemoryValue.SegmentRegister);
                                    Console.WriteLine();
                                    break;
                                case X86InstructionOperandType.Register:
                                    Console.WriteLine("\t\t Operand Value: {0}", operand.RegisterValue);
                                    Console.WriteLine();
                                    break;
                            }
                        }

                        Console.WriteLine("\t OpCode: {0}", String.Join(",", instruction.ArchitectureDetail.OperationCode));
                        Console.WriteLine("\t Prefix: {0}", String.Join(",", instruction.ArchitectureDetail.Prefix));
                        Console.WriteLine("\t REX: {0}", instruction.ArchitectureDetail.Rex);
                        Console.WriteLine("\t SIB: {0}", instruction.ArchitectureDetail.Sib);
                        Console.WriteLine("\t SIB Base Register: {0}", instruction.ArchitectureDetail.SibBaseRegister);
                        Console.WriteLine("\t SIB Index Register: {0}", instruction.ArchitectureDetail.SibIndexRegister);
                        Console.WriteLine("\t SIB Scale: {0}", instruction.ArchitectureDetail.SibScale);
                        Console.WriteLine("\t SSE Code Condition: {0}", instruction.ArchitectureDetail.SseCodeCondition);
                    }

                    Console.WriteLine();
                }
            }

            Console.ReadLine();
        }
    }
}