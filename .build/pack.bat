@ECHO OFF
CALL rmdir /S /Q %~dp0\nuget
CALL mkdir %~dp0\nuget
CALL mkdir %~dp0\nuget\lib\net40
CALL mkdir %~dp0\nuget\lib\net45
CALL mkdir %~dp0\nuget\ref\netstandard2.0
CALL mkdir %~dp0\nuget\runtimes\win-x64\native
CALL mkdir %~dp0\nuget\runtimes\win-x64\lib\netstandard2.0
CALL mkdir %~dp0\nuget\runtimes\win-x86\native
CALL mkdir %~dp0\nuget\runtimes\win-x86\lib\netstandard2.0

CALL dotnet msbuild %~dp0\..\Capstone.NET.sln ^
	/property:Configuration="Release" ^
	/property:Platform="x64" ^
	/property:AssemblyVersion=2.0.0.0

CALL dotnet msbuild %~dp0\..\Capstone.NET.sln ^
	/property:Configuration="Release" ^
	/property:Platform="x86" ^
	/property:AssemblyVersion=2.0.0.0

CALL copy /V /Y %~dp0\..\Gee.External.Capstone\bin\x64\Release\net40\Gee.External.Capstone.dll ^
		  %~dp0\nuget\lib\net40\Gee.External.Capstone.dll