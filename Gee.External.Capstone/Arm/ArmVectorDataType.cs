#pragma warning disable 1591

namespace Gee.External.Capstone.Arm {
    /// <summary>
    ///     ARM Vector Data Type.
    /// </summary>
    public enum ArmVectorDataType {
        /// <summary>
        ///     Invalid Data Type.
        /// </summary>
        Invalid = 0,

        I8,
        I16,
        I32,
        I64,
        S8,
        S16,
        S32,
        S64,
        U8,
        U16,
        U32,
        U64,
        P8,
        F32,
        F64,
        F16F64,
        F64F16,
        F32F16,
        F16F32,
        F64F32,
        F32F64,
        S32F32,
        U32F32,
        F32S32,
        F32U32,
        F64S16,
        F32S16,
        F64S32,
        S16F64,
        S16F32,
        S32F64,
        U16F64,
        U16F32,
        U32F64,
        F64U16,
        F32U16,
        F64U32
    }
}