using System;
using System.Runtime.InteropServices;

namespace Gee.External.Capstone
{
#if STRONG_IMPORT_TYPES
    public static partial class CapstoneImport
    {
        [DllImport("capstone.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "cs_option")]
        private static extern ErrorCode SetOption(IntPtr pHandle, Option option, IntPtr value);

    //CS_OPT_MEM,	// User-defined dynamic memory related functions
    //CS_OPT_SKIPDATA_SETUP, // Setup user-defined function for SKIPDATA option

        public static ErrorCode EnableInstructionDetails(IntPtr pHandle, bool enable)
        {
            return SetOption(pHandle, Option.EnableInstructionDetails,
                enable ? OptionOn : OptionOff);
        }

        public static ErrorCode EnableSkipData(IntPtr pHandle, bool enable)
        {
            return SetOption(pHandle, Option.SkipData,
                enable ? OptionOn : OptionOff);
        }

        public static ErrorCode SetAssemblySyntax(IntPtr pHandle, AssemblySyntax syntax)
        {
            return SetOption(pHandle, Option.AssemblySyntax, new IntPtr((uint)syntax));
        }

        public static ErrorCode SetDisassemblerMode(IntPtr pHandle, DisassemblerMode newMode)
        {
            return SetOption(pHandle, Option.DynamicEngineModeChange, new IntPtr((uint)newMode));
        }

        // TODO : CS_OPT_SKIPDATA_SETUP

        // Turn OFF an option - default option of CS_OPT_DETAIL, CS_OPT_SKIPDATA.
        private static readonly IntPtr OptionOff = IntPtr.Zero;
        // Turn ON an option (CS_OPT_DETAIL, CS_OPT_SKIPDATA).
        private static readonly IntPtr OptionOn = new IntPtr(3);

        // Mode type
        [Flags()]
        public enum DisassemblerMode : uint
        {
            LittleEndian = 0,// little-endian mode (default mode)
            BigEndian = 0x80000000,	// big-endian mode
            
            Arm32 = 0, // 32-bit ARM
            Intel16Bits = 0x00000001, // 16-bit mode (X86)
            Intel32Bits = 0x00000002, // 32-bit mode (X86)
            Intel64Bits = 0x00000004, // 64-bit mode (X86, PPC)
            PowerPC64Bits = 0x00000004, // 64-bit mode (X86, PPC)
            
            ArmThumb = 0x00000008, // ARM's Thumb mode, including Thumb-2
            ArmCortexM = 0x00000010, // ARM's Cortex-M series
            ArmV8 = 0x00000020, // ARMv8 A32 encodings for ARM

            Mips32 = 0x00000002, // Mips32 ISA (Mips)
            Mips64 = 0x00000004, // Mips64 ISA (Mips)
            MicroMips = 0x00000010, // MicroMips mode (MIPS)
            Mips3 = 0x00000020, // Mips III ISA
            Mips32R6 = 0x00000040, // Mips32r6 ISA
            MipsCPS64Bits = 0x00000080, // General Purpose Registers are 64-bit wide (MIPS)
            SparcV9 = 0x00000010, // SparcV9 mode (Sparc)
        }

        public enum AssemblySyntax
        {
            Default = 0, // Default asm syntax (CS_OPT_SYNTAX).
            Intel, // X86 Intel asm syntax - default on X86 (CS_OPT_SYNTAX).
            ATT,   // X86 ATT asm syntax (CS_OPT_SYNTAX).
            NoRegisterName, // Prints register name with only number (CS_OPT_SYNTAX)
        }

        // Runtime option for the disassembled engine
        private enum Option
        {
            AssemblySyntax = 1,	// Assembly output syntax
            EnableInstructionDetails,	// Break down instruction structure into details
            DynamicEngineModeChange,	// Change engine's mode at run-time
            MemoryFunctions,	// User-defined dynamic memory related functions
            SkipData, // Skip data when disassembling. Then engine is in SKIPDATA mode.
            SkipDataCallback, // Setup user-defined function for SKIPDATA option
        }
    }
#endif
}
