using Gee.External.Capstone;
using Gee.External.Capstone.Arm;
using Gee.External.Capstone.Arm64;
using Gee.External.Capstone.M68K;
using Gee.External.Capstone.X86;
using System;

namespace ConsoleApp1 {
    /// <summary>
    ///     Main Program.
    /// </summary>
    internal static class Program {
        internal static void Main(string[] args) {
            Console.WriteLine("Capstone.NET Example Application");
            Console.WriteLine();
            Console.Write("Choose an Architecture (ARM32, ARM32-V8, ARM32-Thumb, ARM32-Thumb-MClass, ARM64, X86): --> ");

            var v = CapstoneDisassembler.Version;
            var disassembleArchitecture = Console.ReadLine();
            switch (disassembleArchitecture) {
                case "Arm":
                    Program.ShowArm();
                    break;
                case "Arm64":
                    Console.WriteLine();
                    Program.ShowArm64();
                    break;
                case "X86":
                    Program.ShowX86();
                    break;
                case "M68K000":
                    Program.ShowM68K000();
                    break;
                default:
                    Console.WriteLine("ERROR: You did not select a disassemble architecture. Good bye Steve!");
                    break;
            }

            Console.ReadLine();
        }

        private static void ShowArm() {
            // ...
            //
            // Creating the disassembler in a "using" statement ensures that resources get cleaned up automatically
            // when it is no longer needed.
            var disassembleMode = ArmDisassembleMode.Arm;
            using (var disassembler = CapstoneDisassembler.CreateArmDisassembler(disassembleMode)) {
                // ....
                //
                // Enables disassemble details, which are disabled by default, to provide more detailed information on
                // disassembled binary code.
                disassembler.EnableInstructionDetails = true;
                disassembler.DisassembleSyntax = DisassembleSyntax.Intel;

                var binaryCode = new byte[] {
                    0x86, 0x48, 0x60, 0xf4, 0x4d, 0x0f, 0xe2, 0xf4, 0xED, 0xFF, 0xFF, 0xEB, 0x04, 0xe0, 0x2d, 0xe5,
                    0x00, 0x00, 0x00, 0x00, 0xe0, 0x83, 0x22, 0xe5, 0xf1, 0x02, 0x03, 0x0e, 0x00, 0x00, 0xa0, 0xe3,
                    0x02, 0x30, 0xc1, 0xe7, 0x00, 0x00, 0x53, 0xe3, 0x00, 0x02, 0x01, 0xf1, 0x05, 0x40, 0xd0, 0xe8,
                    0xf4, 0x80, 0x00, 0x00
                };

                var instructions = disassembler.Disassemble(binaryCode);
                var hexCode = BitConverter.ToString(binaryCode).Replace("-", " ");
                Console.WriteLine(hexCode);
                Console.WriteLine();
            }
        }

        /// <summary>
        ///     Show ARM64.
        /// </summary>
        private static void ShowArm64() {
            // ...
            //
            // Creating the disassembler in a "using" statement ensures that resources get cleaned up automatically
            // when it is no longer needed.
            const Arm64DisassembleMode disassembleMode = Arm64DisassembleMode.Arm;
            using (var disassembler = CapstoneDisassembler.CreateArm64Disassembler(disassembleMode)) {
                // ....
                //
                // Enables disassemble details, which are disabled by default, to provide more detailed information on
                // disassembled binary code.
                disassembler.EnableInstructionDetails = true;
                disassembler.DisassembleSyntax = DisassembleSyntax.Intel;

                var binaryCode = new byte[] {
                    0x09, 0x00, 0x38, 0xd5, 0xbf, 0x40, 0x00, 0xd5, 0x0c, 0x05, 0x13, 0xd5, 0x20, 0x50, 0x02, 0x0e,
                    0x20, 0xe4, 0x3d, 0x0f, 0x00, 0x18, 0xa0, 0x5f, 0xa2, 0x00, 0xae, 0x9e, 0x9f, 0x37, 0x03, 0xd5,
                    0xbf, 0x33, 0x03, 0xd5, 0xdf, 0x3f, 0x03, 0xd5, 0x21, 0x7c, 0x02, 0x9b, 0x21, 0x7c, 0x00, 0x53,
                    0x00, 0x40, 0x21, 0x4b, 0xe1, 0x0b, 0x40, 0xb9, 0x20, 0x04, 0x81, 0xda, 0x20, 0x08, 0x02, 0x8b,
                    0x10, 0x5b, 0xe8, 0x3c
                };

                var hexCode = BitConverter.ToString(binaryCode).Replace("-", " ");
                Console.WriteLine(hexCode);
                Console.WriteLine();

                var instructions = disassembler.Iterate(binaryCode);
                foreach (var instruction in instructions) {
                    // ...
                    //
                    // An instruction's address and unique identifier are always available.
                    var address = instruction.Address;
                    var id = instruction.Id;
                    if (!instruction.IsDietModeEnabled) {
                        // ...
                        //
                        // An instruction's mnemonic and operand text are only available when the native Capstone
                        // DLL is compiled WITHOUT Diet Mode. An exception is thrown otherwise!
                        var mnemonic = instruction.Mnemonic;
                        var operand = instruction.Operand;
                        Console.WriteLine("{0:X}: \t {1} \t {2}", address, mnemonic, operand);
                        Console.WriteLine("\t Instruction Id = {0}", id);
                    }
                    else {
                        Console.WriteLine("{0:X}:", address);
                        Console.WriteLine("\t Id = {0}", id);
                    }

                    hexCode = BitConverter.ToString(instruction.Bytes).Replace("-", " ");
                    Console.WriteLine("\t Machine Bytes = {0}", hexCode);

                    if (disassembler.EnableInstructionDetails) {
                        Console.WriteLine("\t Condition Code = {0}", instruction.Details.ConditionCode);
                        Console.WriteLine("\t Update Flags? = {0}", instruction.Details.UpdateFlags);
                        Console.WriteLine("\t Write Back? = {0}", instruction.Details.WriteBack);

                        if (!CapstoneDisassembler.IsDietModeEnabled) {
                            // ...
                            //
                            // Instruction groups are only available when Diet Mode is disabled. An exception is
                            // thrown otherwise!
                            var instructionGroups = instruction.Details.Groups;
                            Console.WriteLine("\t # of Instruction Groups: {0}", instructionGroups.Length);
                            for (var i = 0; i < instructionGroups.Length; i++) {
                                // ...
                                //
                                // A instruction group's name is only available when Diet Mode is disabled. An
                                // exception is thrown otherwise! But since we already checked that it is disabled, we
                                // don't need to perform another check.
                                var instructionGroup = instructionGroups[i];
                                Console.Write("\t\t {0}) ", i + 1);
                                Console.WriteLine("Id = {0}, Name = {1}", instructionGroup.Id, instructionGroup.Name);
                            }

                            // ...
                            //
                            // Explicitly read registers are only available when Diet Mode is disabled. An exception
                            // is thrown otherwise!
                            var registers = instruction.Details.ExplicitlyReadRegisters;
                            Console.WriteLine("\t # of Explicitly Read Registers: {0}", registers.Length);
                            for (var i = 0; i < registers.Length; i++) {
                                // ...
                                //
                                // A register's name is only available when Diet Mode is disabled. An exception is
                                // thrown otherwise! But since we already checked that it is disabled, we don't need
                                // to perform another check.
                                var register = registers[i];
                                Console.Write("\t\t {0}) ", i + 1);
                                Console.WriteLine("Id = {0}, Name = {1}", register.Id, register.Name);
                            }

                            // ...
                            //
                            // Explicitly modified registers are only available when Diet Mode is disabled. An
                            // exception is thrown otherwise!
                            registers = instruction.Details.ExplicitlyWrittenRegisters;
                            Console.WriteLine("\t # of Explicitly Modified Registers: {0}", registers.Length);
                            for (var i = 0; i < registers.Length; i++) {
                                var register = registers[i];
                                Console.Write("\t\t {0}) ", i + 1);
                                Console.WriteLine("Id = {0}, Name = {1}", register.Id, register.Name);
                            }

                            // ...
                            //
                            // Implicitly read registers are only available when Diet Mode is disabled. An exception
                            // is thrown otherwise!
                            registers = instruction.Details.ImplicitlyReadRegisters;
                            Console.WriteLine("\t # of Implicitly Read Registers: {0}", registers.Length);
                            for (var i = 0; i < registers.Length; i++) {
                                var register = registers[i];
                                Console.Write("\t\t {0}) ", i + 1);
                                Console.WriteLine("Id = {0}, Name = {1}", register.Id, register.Name);
                            }

                            // ...
                            //
                            // Implicitly modified registers are only available when Diet Mode is disabled. An
                            // exception is thrown otherwise!
                            registers = instruction.Details.ImplicitlyWrittenRegisters;
                            Console.WriteLine("\t # of Implicitly Modified Registers: {0}", registers.Length);
                            for (var i = 0; i < registers.Length; i++) {
                                var register = registers[i];
                                Console.Write("\t\t {0}) ", i + 1);
                                Console.WriteLine("Id = {0}, Name = {1}", register.Id, register.Name);
                            }
                        }

                        // ...
                        //
                        // An Instruction's operands are always available.
                        var operands = instruction.Details.Operands;
                        Console.WriteLine("\t # of Operands: {0}", operands.Length);
                        for (var i = 0; i < operands.Length; i++) {
                            // ...
                            //
                            // Always check the operand's type before retrieving the associated property. An exception
                            // is thrown otherwise!
                            var operand = operands[i];
                            var operandType = operand.Type;
                            Console.WriteLine("\t\t {0}) Operand Type: {1}", i + 1, operandType);
                            if (operand.Type == Arm64OperandType.AtOperation) {
                                var atOperation = operand.AtOperation;
                                Console.WriteLine("\t\t\t Address Translation (AT) Operation = {0}", atOperation);
                            }
                            else if (operand.Type == Arm64OperandType.BarrierOperation) {
                                var barrierOperation = operand.BarrierOperation;
                                Console.WriteLine("\t\t\t Barrier Operation = {0}", barrierOperation);
                            }
                            else if (operand.Type == Arm64OperandType.DcOperation) {
                                var dcOperation = operand.DcOperation;
                                Console.WriteLine("\t\t\t Data Cache (DC) Operation = {0}", dcOperation);
                            }
                            else if (operand.Type == Arm64OperandType.FloatingPoint) {
                                var floatingPoint = operand.FloatingPoint;
                                Console.WriteLine("\t\t\t Floating Point Value = {0}", floatingPoint);
                            }
                            else if (operand.Type == Arm64OperandType.IcOperation) {
                                var icOperation = operand.IcOperation;
                                Console.WriteLine("\t\t\t Instruction Cache (IC) Operation = {0}", icOperation);
                            }
                            else if (operand.Type == Arm64OperandType.Immediate) {
                                var immediate = operand.Immediate;
                                Console.WriteLine("\t\t\t Immediate Value = {0:X}", immediate);
                            }
                            else if (operand.Type == Arm64OperandType.Memory) {
                                var memory = operand.Memory;
                                Console.WriteLine("\t\t\t Memory Value:");

                                // ...
                                //
                                // For a memory operand, an irrelevant base register will be a null reference!
                                var @base = memory.Base;
                                if (@base != null) {
                                    if (!@base.IsDietModeEnabled) {
                                        // ...
                                        //
                                        // A register's name is only available when Diet Mode is disabled. An
                                        // exception is thrown otherwise!
                                        Console.WriteLine("\t\t\t\t Base: Id = {0}, Name = {1}", @base.Id, @base.Name);
                                    }
                                    else {
                                        // ...
                                        //
                                        // A register's unique identifier is always available.
                                        Console.WriteLine("\t\t\t\t Base: Id = {0}", @base.Id);
                                    }
                                }

                                var displacement = memory.Displacement;
                                Console.WriteLine("\t\t\t\t Displacement Value = {0}", displacement);

                                // ...
                                //
                                // For a memory operand, an irrelevant index register will be a null reference!
                                var index = memory.Index;
                                if (index != null) {
                                    if (!index.IsDietModeEnabled) {
                                        Console.WriteLine("\t\t\t\t Index: Id = {0}, Name = {1}", index.Id, index.Name);
                                    }
                                    else {
                                        Console.WriteLine("\t\t\t\t Index: Id = {0}", index.Id);
                                    }
                                }
                            }
                            else if (operand.Type == Arm64OperandType.MrsSystemRegister) {
                                var mrsRegister = operand.MrsSystemRegister;
                                Console.WriteLine("\t\t\t MRS System Register = {0}", mrsRegister);
                            }
                            else if (operand.Type == Arm64OperandType.MsrSystemRegister) {
                                var msrRegister = operand.MsrSystemRegister;
                                Console.WriteLine("\t\t\t MSR System Register = {0}", msrRegister);
                            }
                            else if (operand.Type == Arm64OperandType.PStateField) {
                                var pStateField = operand.PStateField;
                                Console.WriteLine("\t\t\t Processor State (PSTATE) Field = {0}", pStateField);
                            }
                            else if (operand.Type == Arm64OperandType.PrefetchOperation) {
                                var prefetchOperation = operand.PrefetchOperation;
                                Console.WriteLine("\t\t\t Prefetch Operation = {0}", prefetchOperation);
                            }
                            else if (operand.Type == Arm64OperandType.Register) {
                                var register = operand.Register;
                                if (!register.IsDietModeEnabled) {
                                    // ...
                                    //
                                    // A register's name is only available when Diet Mode is disabled. An exception is
                                    // thrown otherwise!
                                    Console.WriteLine("\t\t\t Register: Id = {0}, Name = {1}", register.Id, register.Name);
                                }
                                else {
                                    // ...
                                    //
                                    // A register's unique identifier is always available.
                                    Console.WriteLine("\t\t\t Register: Id = {0}", register.Id);
                                }
                            }

                            if (!operand.IsDietModeEnabled) {
                                // ...
                                //
                                // An operand's access type is only available when Diet Mode is disabled. An exception
                                // is thrown otherwise!
                                var accessType = operand.AccessType;
                                Console.WriteLine("\t\t\t Access Type = {0}", accessType);
                            }

                            var extendOperation = operand.ExtendOperation;
                            Console.WriteLine("\t\t\t Extend Operation = {0}", extendOperation);

                            var shiftOperation = operand.ShiftOperation;
                            Console.WriteLine("\t\t\t Shift Operation: {0}", shiftOperation);
                            if (shiftOperation != Arm64ShiftOperation.Invalid) {
                                // ...
                                //
                                // An operand's shift value is only available if the shift operation is not invalid.
                                // An exception is thrown otherwise!
                                var shiftValue = operand.ShiftValue;
                                Console.WriteLine("\t\t\t\t Shift Value = {0}", shiftValue);
                            }

                            var vectorArrangementSpecifier = operand.VectorArrangementSpecifier;
                            Console.WriteLine("\t\t\t Vector Arrangement Specifier = {0}", vectorArrangementSpecifier);

                            var vectorElementSizeSpecifier = operand.VectorElementSizeSpecifier;
                            Console.WriteLine("\t\t\t Vector Element Size Specifier = {0}", vectorElementSizeSpecifier);

                            var vectorIndex = operand.VectorIndex;
                            Console.WriteLine("\t\t\t Vector Index = {0}", vectorIndex);
                        }
                    }

                    Console.WriteLine();
                }
            }
        }

        private static void ShowM68K000() {
            const M68KDisassembleMode disassembleMode = M68KDisassembleMode.BigEndian | M68KDisassembleMode.M68K040;
            using (var disassembler = CapstoneDisassembler.CreateM68KDisassembler(disassembleMode)) {
                disassembler.DisassembleSyntax = DisassembleSyntax.Intel;
                disassembler.EnableInstructionDetails = true;

                var binaryCode = new byte[] {
                    0X4C, 0X00, 0X54, 0X04, 0X48, 0XE7, 0XE0, 0X30, 0X4C, 0XDF, 0X0C, 0X07, 0XD4, 0X40, 0X87, 0X5A,
                    0X4E, 0X71, 0X02, 0XB4, 0XC0, 0XDE, 0XC0, 0XDE, 0X5C, 0X00, 0X1D, 0X80, 0X71, 0X12, 0X01, 0X23,
                    0XF2, 0X3C, 0X44, 0X22, 0X40, 0X49, 0X0E, 0X56, 0X54, 0XC5, 0XF2, 0X3C, 0X44, 0X00, 0X44, 0X7A,
                    0X00, 0X00, 0XF2, 0X00, 0X0A, 0X28, 0X4E, 0XB9, 0X00, 0X00, 0X00, 0X12, 0X4E, 0X75
                };

                // M68K000
                var instructions = disassembler.Iterate(binaryCode);
                foreach (var instruction in instructions) {
                    disassembler.DisassembleMode = M68KDisassembleMode.M68K000;
                }
            }
        }

        private static void ShowX86() {
            // ...
            //
            // Creating the disassembler in a "using" statement ensures that resources get cleaned up automatically
            // when it is no longer needed.
            using (var disassembler = CapstoneDisassembler.CreateX86Disassembler(X86DisassembleMode.Bit32)) {
                // ....
                //
                // Enables disassemble details, which are disabled by default, to provide more detailed information on
                // disassembled binary code.
                disassembler.EnableInstructionDetails = true;
                disassembler.DisassembleSyntax = DisassembleSyntax.Intel;
                disassembler.EnableSkipDataMode = true;
                disassembler.SkipDataInstructionMnemonic = "Ahmed";
                disassembler.SkipDataCallback = (b, o) => {
                    return 1;
                };

//                var binaryCode = new byte[] {
//                    0x8d, 0x4c, 0x32, 0x08, 0x01, 0xd8, 0x81, 0xc6, 0x34, 0x12, 0x00, 0x00, 0x05, 0x23, 0x01, 0x00,
//                    0x00, 0x36, 0x8b, 0x84, 0x91, 0x23, 0x01, 0x00, 0x00, 0x41, 0x8d, 0x84, 0x39, 0x89, 0x67, 0x00,
//                    0x00, 0x8d, 0x87, 0x89, 0x67, 0x00, 0x00, 0xb4, 0xc6, 0x66, 0xe9, 0xb8, 0x00, 0x00, 0x00, 0x67,
//                    0xff, 0xa0, 0x23, 0x01, 0x00, 0x00, 0x66, 0xe8, 0xcb, 0x00, 0x00, 0x00, 0x74, 0xfc
//                };
//
                var binaryCode = new byte[] {
                    0xed, 0x00, 0x00, 0x00, 0x00, 0x1a, 0x5a, 0x0f, 0x1f, 0xff, 0xc2, 0x09, 0x80, 0x00, 0x00, 0x00, 0x07, 0xf7, 0xeb, 0x2a, 0xff, 0xff, 0x7f,
                    0x57, 0xe3, 0x01, 0xff, 0xff, 0x7f, 0x57, 0xeb, 0x00, 0xf0, 0x00, 0x00, 0x24, 0xb2, 0x4f, 0x00, 0x78
                };

                var instructions = disassembler.Disassemble(binaryCode);
                var hexCode = BitConverter.ToString(binaryCode).Replace("-", " ");
                Console.WriteLine(hexCode);
                Console.WriteLine();

                foreach (var instruction in instructions) {
                    Console.WriteLine("{0:X}: \t {1} \t {2}", instruction.Address, instruction.Mnemonic, instruction.Operand);
                    Console.WriteLine("\t Id = {0}", instruction.Id);

                    if (instruction.Details != null) {
                        Console.WriteLine("\t Address Size = {0}", instruction.Details.AddressSize);
                        Console.WriteLine("\t AVX Code Condition = {0}", instruction.Details.AvxConditionCode);
                        Console.WriteLine("\t AVX Rounding Mode = {0}", instruction.Details.AvxRoundingMode);
                        Console.WriteLine("\t Displacement = {0:X}", instruction.Details.Displacement);
                        Console.WriteLine("\t Mod/Rm = {0:X}", instruction.Details.ModRm);
                        Console.WriteLine("\t Operand Count: {0}", instruction.Details.Operands.Length);

                        foreach (var operand in instruction.Details.Operands) {
                            string operandValue = null;
                            switch (operand.Type) {
                                case X86OperandType.Immediate:
                                    operandValue = operand.Immediate.ToString("X");
                                    break;
                                case X86OperandType.Memory:
                                    operandValue = "-->";
                                    break;
                                case X86OperandType.Register:
                                    operandValue = operand.Register.ToString();
                                    break;
                            }

                            Console.WriteLine("\t\t {0} = {1}", operand.Type, operandValue);

                            // Handle Memory Operand.
                            //
                            // ...
                            if (operand.Type == X86OperandType.Memory) {
                                Console.WriteLine("\t\t\t Base Register = {0} ", operand.Memory.Base);
                                Console.WriteLine("\t\t\t Displacement = {0:X} ", operand.Memory.Displacement);
                                Console.WriteLine("\t\t\t Index Register = {0}", operand.Memory.Index);
                                Console.WriteLine("\t\t\t Index Register Scale = {0}", operand.Memory.Scale);
                                Console.WriteLine("\t\t\t Segment Register = {0}", operand.Memory.Segment);
                                Console.WriteLine();
                            }

                            Console.WriteLine("\t\t\t AVX Broadcast = {0}", operand.AvxBroadcast);
                            Console.WriteLine("\t\t\t AVX Zero Operation Mask? {0}", operand.AvxZeroOpMask);
                        }

                        var hexOperationCode = BitConverter.ToString(instruction.Details.Opcode).Replace("-", " ");
                        Console.WriteLine("\t Operation Code = {0}", hexOperationCode);

                        var hexPrefix = String.Join(" ", instruction.Details.Prefix);
                        Console.WriteLine("\t Prefix = {0}", hexPrefix);

                        Console.WriteLine("\t REX = {0}", instruction.Details.Rex);
                        Console.WriteLine("\t SIB = {0}", instruction.Details.Sib);
                        Console.WriteLine("\t SIB Base Register = {0}", instruction.Details.SibBase);
                        Console.WriteLine("\t SIB Index Register = {0}", instruction.Details.SibIndex);
                        Console.WriteLine("\t SIB Scale = {0}", instruction.Details.SibScale);
                        Console.WriteLine("\t SSE Code Condition = {0}", instruction.Details.SseConditionCode);
                        Console.WriteLine("\t Suppress All AVX Exceptions? {0}", instruction.Details.AvxSuppressAllExceptions);
                    }

                    Console.WriteLine();
                }
            }
        }
    }
}