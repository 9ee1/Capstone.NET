using System;

// ReSharper disable InconsistentNaming

namespace Gee.External.Capstone.Arm {
    /// <summary>
    ///     ARM CPS Flag.
    /// </summary>
    [Flags]
    public enum ArmCpsFlag {
        /// <summary>
        ///     Invalid CPS Flag.
        /// </summary>
        Invalid = 0,

        F = 1,
        I = 2,
        A = 4,
        NONE = 16
    }
}