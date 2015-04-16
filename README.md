# Capstone.NET
Capstone.NET is a .NET Framework binding for the Capstone disassembly framework. It is written in C#, supports Capstone 3, and has a friendly and simple OOP API that is easy and quick to pick up.

The initial release right now only has support for the X86 architecture, with support for the remaining architectures coming in incremental updates.

Greetings and respect to my sensi @halsten and all the great folks @capstone_engine ...

## Features
(+) Supports Capstone 3. Only the X86 architecture is supported right now, but more are on the way!

(+) 3 different API layers to choose from. Want to use something as close to the native C API as possible but too lazy to write all the required P/Invoke definitions? Use the P/Invoke APIs. Don't like using an OOP API (though, why are you even using C# if that is the case)? Use the P/Invoke Wrapper APIs. The OOP API is the recommended one to use.

(+) One of the best documented source code you'll find in an open source project, guaranteed or your money back!

## Examples
Take a look at the unit tests and the example command line application for an example on how to use. It is ridiculously simple. More unit tests and examples are on the way!
