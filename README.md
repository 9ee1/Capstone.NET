# Capstone.NET
Capstone.NET is a .NET Core and a .NET Framework binding for the [Capstone disassembly framework](http://www.capstone-engine.org). It is written in C#, supports Capstone 4, and has a friendly and simple type safe API that is ridiculously easy to learn and quick to pick up.

## Features
(+) Supports Capstone 4. Only the ARM, ARM64, and X86 architectures are supported right now

(+) Supports .NET Core and .NET Framework

(+) No external dependencies beside Capstone

(+) A friendly and simple to use type safe API that is ridiculously easy to learn and pick up

(+) One of the best documented source code you'll find in an open source project, guaranteed or your money back!

## Capstone.NET 1.x Developer Warning
If you are actively developing an application or library, or have a stable application or library released, that has a dependency on Capstone.NET 1.x, **PLEASE READ THIS WARNING BEFORE UPGRADING TO CAPSTONE.NET 2**.

Capstone.NET 2 **IS NOT BACKWARDS COMPATIBLE** with Capstone.NET 1.x. There are many, many API changes and if you do an in-place upgrade, your existing code **WILL BREAK** if you do not do significant refactoring!

I want to apologize to everyone in advance for these breaking changes. I know how incredibly frustrating it can be to have a library you depend on introduce breaking changes but ultimately I feel the new code base is much cleaner and will allow for easier integration moving forward. I have no plans to introduce further breaking changes in the future and I am hoping the 4 year gap between the release of Capstone.NET 1.x and Capstone 2.0 will make it a little easier for everyone to forgive these changes.

If you're interested in understanding why Capstone.NET 2 has these breaking changes, please read this section of this README.

## Requirements
(+) **Capstone 4 (X86/X64)**: Capstone.NET is compatible with the X86 and X64 versions of Capstone 4. Older versions of Capstone are not supported!

(+) **.NET Framework 4.0+ (X86/X64)**: Capstone.NET is compatible with the X86 and X64 versions of .NET Framework 4.0 and newer. Older versions of .NET Framework are not supported!

(+) **.NET Core 2.0+ (X86/X64)**: Capstone.NET is compatible with the X86 and X64 versions of .NET Core 2.0 and newer. Older versions of .NET Core are not supported!

(+) **C# 7.3+**: Capstone.NET can only be compiled by a C# 7.3 or newer compatible compiler. Older versions of a C# are not supported!

## Installation
(1) **Download Capstone**: Head over to the [Capstone website](http://www.capstone-engine.org/download.html) and download either the pre-built binaries or the source code and build Capstone yourself. You can also head over to the [Capstone GitHub repository](https://github.com/aquynh/capstone), clone the repository, and build Capstone yourself.

(2) **Download Capstone.NET**: Either open the NuGet Package Manager in Visual Studio and search for "_Capstone.NET_" or head over to the [NuGet website](https://www.nuget.org/packages/Gee.External.Capstone) and download the NuGet package yourself. You can also clone this repository and build Capstone.NET yourself.

(3) Before you run your application, make sure you place the "_capstone.dll_" binary you downloaded or built earlier in the same directory as your application's binary. You'll get a run-time exception otherwise! If you are distributing your application, make sure your distributable package either includes the "_capstone.dll_" binary or a note instructing your users to acquire it.

## Building
You can build Capstone.NET by opening the included Visual Studio solution file in Visual Studio 2017 and building from there. The Visual Studio solution has "_Debug_" and "_Release_" configurations for X86 and X64. Make sure you select the combination you're targeting before you build.

If you're like me and get a headache when looking at the [.NET Compatibility Matrix](https://docs.microsoft.com/en-us/dotnet/standard/net-standard), you'll appreciate the fact that the Visual Studio solution actually builds 3 assemblies with a single build command. The first assembly targets .NET Framework 4.0, the second targets .NET Framework 4.5, and the third targets .NET Standard 2.0. Those 3 assemblies allow Capstone.NET to support a wide range of .NET Core and .NET Framework versions.

The included Visual Studio solution file is a Visual Studio 2017 solution file. This is the most stable version of Visual Studio that has support for .NET Core, .NET Framework, and the C# 7.3 compiler. I have not tried any other version of Visual Studio so I am not sure if there will be problems if you attempt to open the solution file in an older version of Visual Studio.

## Examples
```C#
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
                    else if (operand.Type == Arm64OperandType.MrsRegister) {
                        var mrsRegister = operand.MrsRegister;
                        Console.WriteLine("\t\t\t MRS System Register = {0}", mrsRegister);
                    }
                    else if (operand.Type == Arm64OperandType.MsrRegister) {
                        var msrRegister = operand.MsrRegister;
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
```

## Upgrading Capstone
The Capstone team is always hard at work at upgrading Capstone. There are several important thing to look out for if you decide to upgrade Capstone. Failing to consider these points will usually result in undefined runtime behavior:

(+) Capstone.NET **only** supports Capstone 4. Please do not try to use any other major version. If you do, a definite runtime exception is guaranteed!

(+) With every minor release of Capstone, the Capstone team usually adds support for new instructions or new APIs. These will not be available in Capstone.NET! New APIs are usually not a problem since they simply will not be exposed in Capstone.NET. New instructions however might cause undefined runtime behavior. Best case scenario, your application will continue to run fine but you'll notice some disassembled instructions do not make sense. Worst case scenario, you'll get a runtime exception because something from the native API could not be translated correctly to the wonderful managed world of .NET.

(+) If a minor release of Capstone changes the layout of **any** structures, kiss your application goodbye. This means a definite runtime exception. Sorry folks!

## More Examples
Take a look at the unit tests and the example command line application for an example on how to use. It is ridiculously simple!

## Acknowledgments
Greetings to my sensi Mohamed Saher ([@halsten](https://twitter.com/@halsten)) who suggested I take on this project and was a major help in debugging some stucture alignment issues, the Capstone team ([@capstone_engine](https://twitter.com/@capstone_engine)) for all the great work they are doing, and Matt Graeber ([@mattifestation](https://twitter.com/@mattifestation)) who wrote the original binding for Capstone 2 and whose work was a starting point for this project.

Special thanks to John Källén ([@uxmal](https://github.com/uxmal)) for his contribution and for choosing to use Capstone.NET for his binary decompiler, [reko](https://github.com/uxmal/reko).
