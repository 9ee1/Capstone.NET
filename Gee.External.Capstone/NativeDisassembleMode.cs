using System;

namespace Gee.External.Capstone {
    /// <summary>
    ///     Disassemble Mode.
    /// </summary>
    [Flags]
    internal enum NativeDisassembleMode {
        /// <summary>
        ///     Indicates binary code should be disassembled in little-endian mode.
        /// </summary>
        LittleEndian = 0,

        /// <summary>
        ///     Indicates binary code should be disassembled in 32-bit ARM mode.
        /// </summary>
        Arm = 0,

        /// <summary>
        ///     Indicates binary code should be disassembled in 16-bit mode.
        /// </summary>
        Bit16 = 1 << 1,

        /// <summary>
        ///     Indicates binary code should be disassembled in 32-bit mode.
        /// </summary>
        Bit32 = 1 << 2,

        /// <summary>
        ///     Indicates binary code should be disassembled in 64-bit mode.
        /// </summary>
        Bit64 = 1 << 3,

        /// <summary>
        ///     Indicates binary code should be disassembled with support for the ARM Thumb and ARM Thumb-2
        ///     instruction sets.
        /// </summary>
        ArmThumb = 1 << 4,

        /// <summary>
        ///     Indicates binary code should be disassembled with support for the ARM Cortex-M processor cores.
        /// </summary>
        ArmCortexM = 1 << 5,

        /// <summary>
        ///     Indicates binary code should be disassembled with support for the ARMv8 instruction set.
        /// </summary>
        ArmV8 = 1 << 6,

        /// ARMv8 A32 encodings for ARM
        MipsMicro = 1 << 4,

        /// MicroMips mode (MIPS)
        Mips3 = 1 << 5,

        /// Mips III ISA
        Mips32R6 = 1 << 6,

        /// Mips32r6 ISA
        Mips2 = 1 << 7,

        /// Mips II ISA
        SparcV9 = 1 << 4,

        /// SparcV9 mode (Sparc)
        PowerPcQuadProcessingExtensions = 1 << 4,

        /// <summary>
        ///     Indicates binary code should be disassembled with support for the M68K000 instruction set.
        /// </summary>
        M68K000 = 1 << 1,

        /// <summary>
        ///     Indicates binary code should be disassembled with support for the M68K010 instruction set.
        /// </summary>
        M68K010 = 1 << 2,

        /// <summary>
        ///     Indicates binary code should be disassembled with support for the M68K020 instruction set.
        /// </summary>
        M68K020 = 1 << 3,

        /// <summary>
        ///     Indicates binary code should be disassembled with support for the M68K030 instruction set.
        /// </summary>
        M68K030 = 1 << 4,

        /// <summary>
        ///     Indicates binary code should be disassembled with support for the M68K040 instruction set.
        /// </summary>
        M68K040 = 1 << 5,

        /// <summary>
        ///     Indicates binary code should be disassembled with support for the M68K060 instruction set.
        /// </summary>
        M68K060 = 1 << 6,
        BigEndian = 1 << 31,
        Mips32 = NativeDisassembleMode.Bit32,
        Mips64 = NativeDisassembleMode.Bit64,
        M680X6301 = 1 << 1,
        M680X6309 = 1 << 2,
        M680X6800 = 1 << 3,
        M680X6801 = 1 << 4,
        M680X6805 = 1 << 5,
        M680X6808 = 1 << 6,
        M680X6809 = 1 << 7,
        M680X6811 = 1 << 8,
        M680XCpu12 = 1 << 9,
        M680XHcS08 = 1 << 10
    }
}