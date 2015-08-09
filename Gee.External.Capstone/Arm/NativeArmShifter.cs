﻿using System.Runtime.InteropServices;

namespace Gee.External.Capstone.Arm {
    /// <summary>
    ///     Native ARM Instruction Operand Shift.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct NativeArmShifter {
        /// <summary>
        ///     Operand's Shift Type.
        /// </summary>
        public int Type;

        /// <summary>
        ///     Operand's Shift Value.
        /// </summary>
        public uint Value;
    }
}