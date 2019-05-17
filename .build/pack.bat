@ECHO OFF
CALL rmdir /S /Q %~dp0\nuget
CALL mkdir %~dp0\nuget
CALL mkdir %~dp0\nuget\build
CALL mkdir %~dp0\nuget\lib\net40
CALL mkdir %~dp0\nuget\lib\net45
CALL mkdir %~dp0\nuget\ref\netstandard2.0
CALL mkdir %~dp0\nuget\runtimes\win-x64\native
CALL mkdir %~dp0\nuget\runtimes\win-x64\lib\netstandard2.0
CALL mkdir %~dp0\nuget\runtimes\win-x86\native
CALL mkdir %~dp0\nuget\runtimes\win-x86\lib\netstandard2.0

CALL dotnet msbuild %~dp0\..\Capstone.NET.sln ^
     /property:Configuration="Release" ^
     /property:Platform="Any CPU" ^
     /property:AssemblyVersion=2.0.2.0 ^
     /property:Copyright="Copyright (c) Ahmed Garhy" ^
     /property:FileVersion=2.0.2.0 ^
     /property:InformationalVersion=2.0.2.0 ^
     /property:Product="Capstone.NET"

CALL dotnet msbuild %~dp0\..\Capstone.NET.sln ^
     /property:Configuration="Release" ^
     /property:Platform="x64" ^
     /property:AssemblyVersion=2.0.2.0 ^
     /property:Copyright="Copyright (c) Ahmed Garhy" ^
     /property:FileVersion=2.0.2.0 ^
     /property:InformationalVersion=2.0.2.0 ^
     /property:Product="Capstone.NET"

CALL dotnet msbuild %~dp0\..\Capstone.NET.sln ^
     /property:Configuration="Release" ^
     /property:Platform="x86" ^
     /property:AssemblyVersion=2.0.2.0 ^
     /property:Copyright="Copyright (c) Ahmed Garhy" ^
     /property:FileVersion=2.0.2.0 ^
     /property:InformationalVersion=2.0.2.0 ^
     /property:Product="Capstone.NET"

CALL copy /V /Y ^
          %~dp0\..\LICENSE ^
          %~dp0\nuget\LICENSE

CALL copy /V /Y ^
          %~dp0\Gee.External.Capstone.targets ^
          %~dp0\nuget\build\Gee.External.Capstone.targets

CALL copy /V /Y ^
          %~dp0\..\.external\capstone-4.0.1\capstone-x64.dll ^
          %~dp0\nuget\build\capstone-x64.dll

CALL copy /V /Y ^
          %~dp0\..\.external\capstone-4.0.1\capstone-x86.dll ^
          %~dp0\nuget\build\capstone-x86.dll

CALL copy /V /Y ^
          %~dp0\..\Gee.External.Capstone\bin\Release\net40\Gee.External.Capstone.dll ^
          %~dp0\nuget\lib\net40\Gee.External.Capstone.dll

CALL copy /V /Y ^
          %~dp0\..\Gee.External.Capstone\Gee.External.Capstone.xml ^
          %~dp0\nuget\lib\net40\Gee.External.Capstone.xml

CALL copy /V /Y ^
          %~dp0\..\Gee.External.Capstone\bin\Release\net45\Gee.External.Capstone.dll ^
          %~dp0\nuget\lib\net45\Gee.External.Capstone.dll

CALL copy /V /Y ^
          %~dp0\..\Gee.External.Capstone\Gee.External.Capstone.xml ^
          %~dp0\nuget\lib\net45\Gee.External.Capstone.xml

CALL copy /V /Y ^
          %~dp0\..\Gee.External.Capstone\bin\Release\netstandard2.0\Gee.External.Capstone.dll ^
          %~dp0\nuget\ref\netstandard2.0\Gee.External.Capstone.dll

CALL copy /V /Y ^
          %~dp0\..\Gee.External.Capstone\Gee.External.Capstone.xml ^
          %~dp0\nuget\ref\netstandard2.0\Gee.External.Capstone.xml

CALL copy /V /Y ^
          %~dp0\..\Gee.External.Capstone\bin\x64\Release\netstandard2.0\Gee.External.Capstone.dll ^
          %~dp0\nuget\runtimes\win-x64\lib\netstandard2.0\Gee.External.Capstone.dll

CALL copy /V /Y ^
          %~dp0\..\.external\capstone-4.0.1\capstone-x64.dll ^
          %~dp0\nuget\runtimes\win-x64\native\capstone.dll

CALL copy /V /Y ^
          %~dp0\..\Gee.External.Capstone\bin\x86\Release\netstandard2.0\Gee.External.Capstone.dll ^
          %~dp0\nuget\runtimes\win-x86\lib\netstandard2.0\Gee.External.Capstone.dll

CALL copy /V /Y ^
          %~dp0\..\.external\capstone-4.0.1\capstone-x86.dll ^
          %~dp0\nuget\runtimes\win-x86\native\capstone.dll

CALL copy /V /Y ^
          %~dp0\Gee.External.Capstone.nuspec ^
          %~dp0\nuget\Gee.External.Capstone.nuspec

CALL cd %~dp0\nuget
CALL nuget pack