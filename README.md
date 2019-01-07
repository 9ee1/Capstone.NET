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
    var code = new byte[] { 0x8d, 0x4c, 0x32, 0x08, 0x01, 0xd8, 0x81, 0xc6, 0x34, 0x12, 0x00, 0x00, 0x05, 0x23, 0x01, 0x00, 0x00, 0x36, 0x8b, 0x84, 0x91 };
    var instructions = disassembler.DisassembleAll(code);
    
    // Loop Through Each Disassembled Instruction.
    // ...
    foreach (var instruction in instructions) {
        // ...
    }
}
```

## Iterator Example
```C#
// Create ARM Disassembler.
//
// Creating the disassembler in a "using" statement ensures that resources get cleaned up automatically
// when it is no longer needed.
using (var disassembler = CapstoneDisassembler.CreateArmDisassembler(DisassembleMode.ArmThumb)) {
    // Enable Disassemble Details.
    //
    // Enables disassemble details, which are disabled by default, to provide more detailed information on
    // disassembled binary code.
    disassembler.EnableDetails = true;

    // Set Disassembler's Syntax.
    //
    // Make the disassembler generate instructions in Intel syntax.
    disassembler.Syntax = DisassembleSyntaxOptionValue.Intel;

    // Disassemble Code One Instruction at a Time.
    //
    // This internally uses a deferred enumerator that dissembles the code one instruction at a time. It pins the
    // memory block in place to avoid exessive copying between managed and unmanaged land. Pinning will only occur
    // when enumeration begins and will be unpinned when the enumerator is disposed of at the end of enumeration.
    //
    // This is an alternative to the native approach that Capstone uses which requires a callback function to be
    // registered. Instead of depending on a delegate, user code can decide when to break out of the loop.
    code = new byte[] { 0x70, 0x47, 0xeb, 0x46, 0x83, 0xb0, 0xc9, 0x68, 0x1f, 0xb1, 0x30, 0xbf, 0xaf, 0xf3, 0x20, 0x84 };
    var instructions = disassembler.DisassembleStream(code, 0, 0x1000);
    
    // Loop Through Each Disassembled Instruction.
    // ...
    foreach (var instruction in instructions) {
        // ...
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
