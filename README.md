# Capstone.NET
Capstone.NET is a .NET Framework binding for the Capstone disassembly framework. It is written in C#, supports Capstone 3, and has a friendly and simple type safe object oriented (OO) API that is ridiculously easy to learn and quick to pick up.

## Features
(+) Supports Capstone 3. Only the ARM64 and X86 architectures are supported right now

(+) A friendly and simple to use type safe object oriented (OO) API that is ridiculously easy to learn and pick up

(+) One of the best documented source code you'll find in an open source project, guaranteed or your money back

## Quick Example
```C#
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

    // Disassemble All Code.
    //
    // ...
    var code = new byte[] { 0x8d, 0x4c, 0x32, 0x08, 0x01, 0xd8, 0x81, 0xc6, 0x34, 0x12, 0x00, 0x00, 0x05, 0x23, 0x01, 0x00, 0x00, 0x36, 0x8b, 0x84, 0x91, 0x23, 0x01, 0x00, 0x00, 0x41, 0x8d, 0x84, 0x39, 0x89, 0x67, 0x00, 0x00, 0x8d, 0x87, 0x89, 0x67, 0x00, 0x00, 0xb4, 0xc6 };
    var instructions = disassembler.DisassembleAll(code);
    
    // Loop Through Each Disassembled Instruction.
    // ...
    foreach (var instruction in instructions) {
        Console.WriteLine("{0:X}: \t {1} \t {2}", instruction.Address, instruction.Mnemonic, instruction.Operand);
        Console.WriteLine("\t Id = {0}", instruction.Id);

        if (instruction.ArchitectureDetail != null) {
            Console.WriteLine("\t Address Size = {0}", instruction.ArchitectureDetail.AddressSize);
            Console.WriteLine("\t AVX Code Condition = {0}", instruction.ArchitectureDetail.AvxCodeCondition);
            Console.WriteLine("\t AVX Rounding Mode = {0}", instruction.ArchitectureDetail.AvxRoundingMode);
            Console.WriteLine("\t Displacement = {0:X}", instruction.ArchitectureDetail.Displacement);
            Console.WriteLine("\t Mod/Rm = {0:X}", instruction.ArchitectureDetail.ModRm);
            Console.WriteLine("\t Operand Count: {0}", instruction.ArchitectureDetail.Operands.Length);

            // Loop Through Each Instruction's Operands.
            //
            // ...
            foreach (var operand in instruction.ArchitectureDetail.Operands) {
                string operandValue = null;
                switch (operand.Type) {
                    case X86InstructionOperandType.FloatingPoint:
                        operandValue = operand.FloatingPointValue.Value.ToString("X");
                        break;
                    case X86InstructionOperandType.Immediate:
                        operandValue = operand.ImmediateValue.Value.ToString("X");
                        break;
                    case X86InstructionOperandType.Memory:
                        operandValue = "-->";
                        break;
                    case X86InstructionOperandType.Register:
                        operandValue = operand.RegisterValue.Value.ToString();
                        break;
                }
                
                Console.WriteLine("\t\t {0} = {1}", operand.Type, operandValue);
                
                // Handle Memory Operand.
                //
                // ...
                if (operand.Type == X86InstructionOperandType.Memory) {
                    Console.WriteLine("\t\t\t Base Register = {0} ", operand.MemoryValue.BaseRegister);
                    Console.WriteLine("\t\t\t Displacement = {0:X} ", operand.MemoryValue.Displacement);
                    Console.WriteLine("\t\t\t Index Register = {0}", operand.MemoryValue.IndexRegister);
                    Console.WriteLine("\t\t\t Index Register Scale = {0}", operand.MemoryValue.IndexRegisterScale);
                    Console.WriteLine("\t\t\t Segment Register = {0}", operand.MemoryValue.SegmentRegister);
                    Console.WriteLine();
                }
            }
        }
    }
}
```

## Requirements
(+) **.NET Framework 4.5**: Capstone.NET is compiled against the .NET Framework 4.5. It is the latest and greatest version of .NET and has been released for quite some time now. Unless you are working with legacy applications, there is really no reason to be using an older version of the .NET Framework. If this is a problem for you, feel free to either open an issue or fork the project and make it compatible with your desired version of the .NET Framework. Little or no changes might be required.

(+) **Capstone 3 (X86)**: Capstone.NET is compatible **only** with the X86 version of Capstone 3. Please make sure you only use that version before you open an issue. Down the road, I will definitely have support for the X64 version of Capstone. If this is a problem for you, feel free to either open an issue or fork the project and make it compatible with both X86 and X64. Significant changes might be required to deal with structure alignment issues when interfacing with the native Capstone API.

(+) **X86 Compiled Binary**: Capstone.NET is compiled as an X86 DLL. This, obviously, means you should only reference it from a X86 binary. The word **should** should be taken with a grain of salt here because the C# compiler will only trigger a warning if you reference it from an X64 binary but please be aware that Capstone.NET has **not** been tested when referenced from an X64 binary so possible runtime exceptions or errors might occur. If this is a problem for you, feel free to either open an issue or fork the project and make it compatible with both X86 and X64. Significant changes might be required to deal with structure alignment issues when interfacing with the native Capstone API.

(+) *Unsafe Binary (Optional)*: Deep under the hood, some Capstone.NET APIs use unsafe code when interfacing with the native Capstone API. These APIs are abstracted away from you behind the object oriented (OO) API that is recommended you use when using Capstone.NET in your application or library. However, **if**, and only **if**, you want to use these unsafe APIs in your code, you **must** compile your binary with the C# compiler switch */unsafe*. Just to make sure this is clear, you **only** need to compile your binary with the */unsafe* switch if you use any unsafe APIs **directly** from your code. Otherwise you are fine and you do not need to use this switch. See MSDN for more information.

## Packaged Installation
The simplest way to get started with Capstone.NET is to download the latest release package. It will contain all the compiled binaries you need to get started. The latest release will usually be backwards compatible with older releases but as both Capstone.NET and Capstone mature, this might not always be the case. Please make sure to read the release notes for each release before upgrading!

As of Capstone.NET 1.1.0, each release package will contain 2 folders:

(+) **CapstoneCMD**: This is an example command line application that shows you how to use Capstone.NET. It highlights usage for all the supported architectures.

(+) **Gee.External.Capstone**: This is the main Capstone.NET DLL and all dependencies, including the native Capstone 3 DLL. You'll need to copy all the DLLs you find in the folder to a location where you can reference them from your project. **Gee.External.Capstone.dll** is the DLL you will need to reference from your project in order to use Capstone.NET. If you compile your project as a DLL, you will need to make sure both **capstone.dll** and **Gee.External.Capstone.Proxy.dll** are distributed along with your compiled DLL and **Gee.External.Capstone.dll** otherwise you will get a runtime exception. If you compile your project as an EXE, you will need to make sure both **capstone.dll** and  **Gee.External.Capstone.Proxy.dll** are available in the same directory as your compiled EXE and **Gee.External.Capstone.dll** otherwise you will get a runtime exception.

## Upgrading Capstone
The Capstone team is always hard at work at upgrading Capstone. It is entirely possible that the copy of Capstone that is distributed with a Capstone.NET release is out of date when you download it. You can feel free to replace the **capstone.dll** that is distributed with Capstone.NET with the latest copy you download from the Capstone website. However, please make sure it is **always** named **capstone.dll**. Capstone.NET looks for this DLL when it goes to work and if it can't find it, you will get a runtime exception.

There are several important thing to look out for if you decide to replace the **capstone.dll** with one you download from the Capstone website. Failing to consider these points will usually result in undefined runtime behavior. If you replace **capstone.dll** with one you download from the Capstone website, do so at your own risk:

(+) Capstone.NET **only** supports Capstone 3. Please do not try to use any other major version. If you do, a definite runtime exception is guaranteed!

(+) With every minor release of Capstone, the Capstone team usually adds support for new instructions or new APIs. These will not be available in Capstone.NET! New APIs are usually not a problem since they simply will not be exposed in Capstone.NET. New instructions however might cause undefined runtime behavior. Best case scenario, your application will continue to run fine but you'll notice some disassembled instructions do not make sense. Worst case scenario, you'll get a runtime exception because something from the native API could not be translated correctly to the wonderful managed world of the .NET Framework.

(+) If a minor release of Capstone changes the layout of **any** structures, kiss your application goodbye. This means a definite runtime exception. Sorry folks!

## More Examples
Take a look at the unit tests and the example command line application for an example on how to use. It is ridiculously simple!

## Acknowledgments
Greetings to my sensi Mohamed Saher ([@halsten](https://twitter.com/@halsten)) who suggested I take on this project and was a major help in debugging some stucture alignment issues, the Capstone team ([@capstone_engine](https://twitter.com/@capstone_engine)) for all the great work they are doing, and Matt Graeber ([@mattifestation](https://twitter.com/@mattifestation)) who wrote the original binding for Capstone 2 and whose work was a starting point for this project.
