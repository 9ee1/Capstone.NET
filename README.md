# Capstone.NET
Capstone.NET is an opinionated .NET Core and a .NET Framework binding for the [Capstone disassembly framework](http://www.capstone-engine.org). It is written in C#, supports _Capstone 4_, and has a friendly and simple type safe API that is ridiculously easy to learn and quick to pick up.

[![Nuget](https://img.shields.io/nuget/dt/Gee.External.Capstone?label=Capstone.NET%20V2.0.2&style=for-the-badge)](https://www.nuget.org/packages/Gee.External.Capstone)

## Features
(+) Supports _Capstone 4_. Only the ARM, ARM64, M68K, MIPS, PowerPC, X86, and XCore architectures are supported right now

(+) Supports _.NET Core 2.0+_ and _.NET Framework 4.0+_

(+) A friendly and simple to use type safe API that is ridiculously easy to learn and pick up

(+) One of the best documented source code you'll find in an open source project, guaranteed or your money back!

## Upgrading from Capstone.NET 1.x to Capstone.NET 2.x
If you are actively developing an application or library, or have a stable application or library released, that has a dependency on _Capstone.NET 1.x_, **please note _Capstone.NET 2.x_ is absolutely NOT backwards-compatible with _Capstone.NET 1.x_**.

If you are interested in understanding why, please see this [WIKI article](https://github.com/9ee1/Capstone.NET/wiki/What-is-New-in-Capstone.NET-2.x).

## Requirements
(+) **Capstone 4 (X86/X64)**: Capstone.NET is compatible with the X86 and X64 versions of _Capstone 4_. Older versions of Capstone are not supported!

(+) **.NET Core 2.0+ (X86/X64)**: Capstone.NET is compatible with the X86 and X64 versions of _.NET Core 2.0_ and newer. Older versions of .NET Core are not supported!

(+) **.NET Framework 4.0+ (X86/X64)**: Capstone.NET is compatible with the X86 and X64 versions of _.NET Framework 4.0_ and newer. Older versions of .NET Framework are not supported!

## Installation
Either open the NuGet Package Manager in Visual Studio and search for "Capstone.NET" or head over to the [NuGet website](https://www.nuget.org/packages/Gee.External.Capstone) and download the NuGet package yourself. You can also clone this repository and build Capstone.NET yourself.

The NuGet package bundles Capstone. If your referencing project targets the .NET Core runtime, it will 1) automatically load the correct version of Capstone when you build the project and 2) will automatically bundle the correct version of Capstone when you deploy the project.

If your referencing project targets the .NET Framework runtime, the NuGet package will automatically copy the correct version of Capstone to the project's output directory when you build the project.

## Building
You can build Capstone.NET by opening the Visual Studio solution in _Visual Studio 2017_ and building from there. The Visual Studio solution has "Debug" and "Release" configurations for multiple platforms. Make sure you select the combination you're targeting before you build.

If you're like me and get a headache when looking at the [.NET Compatibility Matrix](https://docs.microsoft.com/en-us/dotnet/standard/net-standard), you'll appreciate the fact that the Visual Studio solution actually builds 3 assemblies with a single build command. The first assembly targets _.NET Framework 4.0_, the second targets _.NET Framework 4.5_, and the third targets _.NET Standard 2.0_. Those 3 assemblies allow Capstone.NET to support a wide range of .NET Core and .NET Framework versions.

The Visual Studio solution is a _Visual Studio 2017_ solution. This is the most stable version of Visual Studio that has support for .NET Core, .NET Framework, and the _C# 7.3_ compiler. I have not tried any other version of Visual Studio so I am not sure if there will be problems if you attempt to open the solution file in an older version of Visual Studio.

## Acknowledgments
Greetings to my sensi Mohamed Saher ([@halsten](https://twitter.com/@halsten)) who suggested I take on this project and was a major help in debugging some stucture alignment issues, the Capstone team ([@capstone_engine](https://twitter.com/@capstone_engine)) for all the great work they are doing, and Matt Graeber ([@mattifestation](https://twitter.com/@mattifestation)) who wrote the original binding for _Capstone 2_ and whose work was a starting point for this project.

## Short Example
```C#
using Gee.External.Capstone;
using Gee.External.Capstone.Arm64;

namespace Example {
    /// <summary>
    ///     Example Program.
    /// </summary>
    internal static class Program {
        /// <summary>
        ///     Run Program.
        /// </summary>
        /// <param name="args">
        ///     An array of arguments passed from the command line.
        /// </param>
        internal static void Main(string[] args) {
            // ...
            //
            // Creating the disassembler in a "using" statement ensures that resources get cleaned up automatically
            // when it is no longer needed.
            const Arm64DisassembleMode disassembleMode = Arm64DisassembleMode.Arm;
            using (CapstoneArm64Disassembler disassembler = CapstoneDisassembler.CreateArm64Disassembler(disassembleMode)) {
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

                Arm64Instruction[] instructions = disassembler.Disassemble(binaryCode);
                foreach (Arm64Instruction instruction in instructions) {
                    // ...
                    //
                    // Do your magic!
                }
            }
        }
    }
}
```

## Complete Example
```C#
using Gee.External.Capstone;
using Gee.External.Capstone.Arm64;
using System;

namespace Example {
    /// <summary>
    ///     Example Program.
    /// </summary>
    internal static class Program {
        /// <summary>
        ///     Run Program.
        /// </summary>
        /// <param name="args">
        ///     An array of arguments passed from the command line.
        /// </param>
        internal static void Main(string[] args) {
            // ...
            //
            // Creating the disassembler in a "using" statement ensures that resources get cleaned up automatically
            // when it is no longer needed.
            const Arm64DisassembleMode disassembleMode = Arm64DisassembleMode.Arm;
            using (CapstoneArm64Disassembler disassembler = CapstoneDisassembler.CreateArm64Disassembler(disassembleMode)) {
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

                Arm64Instruction[] instructions = disassembler.Disassemble(binaryCode);
                foreach (Arm64Instruction instruction in instructions) {
                    var address = instruction.Address;
                    Arm64InstructionId id = instruction.Id;
                    if (!instruction.IsDietModeEnabled) {
                        // ...
                        //
                        // An instruction's mnemonic and operand text are only available when Diet Mode is disabled.
                        // An exception is thrown otherwise!
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

                    if (instruction.HasDetails) {
                        Console.WriteLine("\t Condition Code = {0}", instruction.Details.ConditionCode);
                        Console.WriteLine("\t Update Flags? = {0}", instruction.Details.UpdateFlags);
                        Console.WriteLine("\t Write Back? = {0}", instruction.Details.WriteBack);

                        if (!instruction.IsDietModeEnabled) {
                            // ...
                            //
                            // Instruction groups are only available when Diet Mode is disabled. An exception is
                            // thrown otherwise!
                            Arm64InstructionGroup[] instructionGroups = instruction.Details.Groups;
                            Console.WriteLine("\t # of Instruction Groups: {0}", instructionGroups.Length);
                            for (var i = 0; i < instructionGroups.Length; i++) {
                                // ...
                                //
                                // A instruction group's name is only available when Diet Mode is disabled. An
                                // exception is thrown otherwise! But since we already checked that it is disabled, we
                                // don't need to perform another check.
                                Arm64InstructionGroup instructionGroup = instructionGroups[i];
                                Console.Write("\t\t {0}) ", i + 1);
                                Console.WriteLine("Id = {0}, Name = {1}", instructionGroup.Id, instructionGroup.Name);
                            }

                            // ...
                            //
                            // Explicitly read registers are only available when Diet Mode is disabled. An exception
                            // is thrown otherwise!
                            Arm64Register[] registers = instruction.Details.ExplicitlyReadRegisters;
                            Console.WriteLine("\t # of Explicitly Read Registers: {0}", registers.Length);
                            for (var i = 0; i < registers.Length; i++) {
                                // ...
                                //
                                // A register's name is only available when Diet Mode is disabled. An exception is
                                // thrown otherwise! But since we already checked that it is disabled, we don't need
                                // to perform another check.
                                Arm64Register register = registers[i];
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
                                Arm64Register register = registers[i];
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
                                Arm64Register register = registers[i];
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
                                Arm64Register register = registers[i];
                                Console.Write("\t\t {0}) ", i + 1);
                                Console.WriteLine("Id = {0}, Name = {1}", register.Id, register.Name);
                            }
                        }

                        // ...
                        //
                        // An Instruction's operands are always available.
                        Arm64Operand[] operands = instruction.Details.Operands;
                        Console.WriteLine("\t # of Operands: {0}", operands.Length);
                        for (var i = 0; i < operands.Length; i++) {
                            // ...
                            //
                            // Always check the operand's type before retrieving the associated property. An exception
                            // is thrown otherwise!
                            Arm64Operand operand = operands[i];
                            Arm64OperandType operandType = operand.Type;
                            Console.WriteLine("\t\t {0}) Operand Type: {1}", i + 1, operandType);
                            if (operand.Type == Arm64OperandType.AtOperation) {
                                Arm64AtOperation atOperation = operand.AtOperation;
                                Console.WriteLine("\t\t\t Address Translation (AT) Operation = {0}", atOperation);
                            }
                            else if (operand.Type == Arm64OperandType.BarrierOperation) {
                                Arm64BarrierOperation barrierOperation = operand.BarrierOperation;
                                Console.WriteLine("\t\t\t Barrier Operation = {0}", barrierOperation);
                            }
                            else if (operand.Type == Arm64OperandType.DcOperation) {
                                Arm64DcOperation dcOperation = operand.DcOperation;
                                Console.WriteLine("\t\t\t Data Cache (DC) Operation = {0}", dcOperation);
                            }
                            else if (operand.Type == Arm64OperandType.FloatingPoint) {
                                var floatingPoint = operand.FloatingPoint;
                                Console.WriteLine("\t\t\t Floating Point Value = {0}", floatingPoint);
                            }
                            else if (operand.Type == Arm64OperandType.IcOperation) {
                                Arm64IcOperation icOperation = operand.IcOperation;
                                Console.WriteLine("\t\t\t Instruction Cache (IC) Operation = {0}", icOperation);
                            }
                            else if (operand.Type == Arm64OperandType.Immediate) {
                                var immediate = operand.Immediate;
                                Console.WriteLine("\t\t\t Immediate Value = {0:X}", immediate);
                            }
                            else if (operand.Type == Arm64OperandType.Memory) {
                                Arm64MemoryOperandValue memory = operand.Memory;
                                Console.WriteLine("\t\t\t Memory Value:");

                                // ...
                                //
                                // For a memory operand, an irrelevant base register will be a null reference!
                                Arm64Register @base = memory.Base;
                                if (@base != null) {
                                    if (!@base.IsDietModeEnabled) {
                                        // ...
                                        //
                                        // A register's name is only available when Diet Mode is disabled. An
                                        // exception is thrown otherwise!
                                        Arm64RegisterId baseId = @base.Id;
                                        var baseName = @base.Name;
                                        Console.WriteLine("\t\t\t\t Base: Id = {0}, Name = {1}", baseId, baseName);
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
                                Arm64Register index = memory.Index;
                                if (index != null) {
                                    if (!index.IsDietModeEnabled) {
                                        Arm64RegisterId indexId = index.Id;
                                        var indexName = index.Name;
                                        Console.WriteLine("\t\t\t\t Index: Id = {0}, Name = {1}", indexId, indexName);
                                    }
                                    else {
                                        Console.WriteLine("\t\t\t\t Index: Id = {0}", index.Id);
                                    }
                                }
                            }
                            else if (operand.Type == Arm64OperandType.MrsSystemRegister) {
                                Arm64MrsSystemRegister mrsRegister = operand.MrsSystemRegister;
                                Console.WriteLine("\t\t\t MRS System Register = {0}", mrsRegister);
                            }
                            else if (operand.Type == Arm64OperandType.MsrSystemRegister) {
                                Arm64MsrSystemRegister msrRegister = operand.MsrSystemRegister;
                                Console.WriteLine("\t\t\t MSR System Register = {0}", msrRegister);
                            }
                            else if (operand.Type == Arm64OperandType.PStateField) {
                                Arm64PStateField pStateField = operand.PStateField;
                                Console.WriteLine("\t\t\t Processor State (PSTATE) Field = {0}", pStateField);
                            }
                            else if (operand.Type == Arm64OperandType.PrefetchOperation) {
                                Arm64PrefetchOperation prefetchOperation = operand.PrefetchOperation;
                                Console.WriteLine("\t\t\t Prefetch Operation = {0}", prefetchOperation);
                            }
                            else if (operand.Type == Arm64OperandType.Register) {
                                Arm64Register register = operand.Register;
                                if (!register.IsDietModeEnabled) {
                                    // ...
                                    //
                                    // A register's name is only available when Diet Mode is disabled. An exception is
                                    // thrown otherwise!
                                    Arm64RegisterId registerId = register.Id;
                                    var name = register.Name;
                                    Console.WriteLine("\t\t\t Register: Id = {0}, Name = {1}", registerId, name);
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
                                OperandAccessType accessType = operand.AccessType;
                                Console.WriteLine("\t\t\t Access Type = {0}", accessType);
                            }

                            Arm64ExtendOperation extendOperation = operand.ExtendOperation;
                            Console.WriteLine("\t\t\t Extend Operation = {0}", extendOperation);

                            Arm64ShiftOperation shiftOperation = operand.ShiftOperation;
                            Console.WriteLine("\t\t\t Shift Operation: {0}", shiftOperation);
                            if (shiftOperation != Arm64ShiftOperation.Invalid) {
                                // ...
                                //
                                // An operand's shift value is only available if the shift operation is not invalid.
                                // An exception is thrown otherwise!
                                var shiftValue = operand.ShiftValue;
                                Console.WriteLine("\t\t\t\t Shift Value = {0}", shiftValue);
                            }

                            Arm64VectorArrangementSpecifier vas = operand.VectorArrangementSpecifier;
                            Console.WriteLine("\t\t\t Vector Arrangement Specifier = {0}", vas);

                            Arm64VectorElementSizeSpecifier vess = operand.VectorElementSizeSpecifier;
                            Console.WriteLine("\t\t\t Vector Element Size Specifier = {0}", vess);

                            var vectorIndex = operand.VectorIndex;
                            Console.WriteLine("\t\t\t Vector Index = {0}", vectorIndex);
                        }
                    }

                    Console.WriteLine();
                    Console.ReadLine();
                }
            }
        }
    }
}
```
