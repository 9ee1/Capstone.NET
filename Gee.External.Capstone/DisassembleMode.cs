using System;

namespace Gee.External.Capstone {
    /// <summary>
    ///     Disassemble Mode.
    /// </summary>
    [Flags]
    public enum DisassembleMode {
        /// <summary>
        ///     Little Endian Disassemble Mode.
        /// </summary>
        LittleEndian = 0,

        /// <summary>
        ///     32-Bit ARM Disassemble Mode.
        /// </summary>
        Arm32 = 0,

        /// <summary>
        ///     16-Bit Disassemble Mode.
        /// </summary>
        Bit16 = 1 << 1,

        /// <summary>
        ///     32-Bit Disassemble Mode.
        /// </summary>
        Bit32 = 1 << 2,

        /// <summary>
        ///     64-Bit Disassemble Mode.
        /// </summary>
        Bit64 = 1 << 3,

        /// <summary>
        ///     ARM Thumb Disassemble Mode.
        /// </summary>
        ArmThumb = 1 << 4,

        /// <summary>
        ///     ARM Cortex-M Disassemble Mode.
        /// </summary>
        ArmCortexM = 1 << 5,

        /// <summary>
        ///     ARMv8 Disassemble Mode.
        /// </summary>
        ArmV8 = 1 << 6,

        /// <summary>
        ///     Micro-MIPS Disassemble Mode.
        /// </summary>
        MipsMicro = 1 << 4,

        /// <summary>
        ///     MIPS-III Disassemble Mode.
        /// </summary>
        Mips3 = 1 << 5,

        /// <summary>
        ///     MIPS-32R6 Disassemble Mode.
        /// </summary>
        Mips32R6 = 1 << 6,

        /// <summary>
        ///     MIPS 64-Bit Wide General Purpose Disassemble Mode.
        /// </summary>
        MipsGp64 = 1 << 7,

        /// <summary>
        ///     SPARCv9 Disassemble Mode.
        /// </summary>
        SparcV9 = 1 << 4,

        /// <summary>
        ///     Big Endian Disassemble Mode.
        /// </summary>
        BigEndian = 1 << 31,

        /// <summary>
        ///     MIPS-32 Disassemble Mode.
        /// </summary>
        Mips32 = Bit32,

        /// <summary>
        ///     MIPS-64 Disassemble Mode.
        /// </summary>
        Mips64 = Bit64
    }
}