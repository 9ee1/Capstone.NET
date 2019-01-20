using System;

namespace Gee.External.Capstone.M68K {
    /// <summary>
    ///     M68K Operation Size.
    /// </summary>
    public sealed class M68KOperationSize {
        /// <summary>
        ///     CPU Operation Size.
        /// </summary>
        private readonly M68KCpuOperationSize _cpuOperationSize;

        /// <summary>
        ///     FPU Operation Size.
        /// </summary>
        private readonly M68KFpuOperationSize _fpuOperationSize;

        /// <summary>
        ///     Get CPU Operation Size.
        /// </summary>
        public M68KCpuOperationSize CpuOperationSize {
            get {
                if (this.Type != M68KOperationSizeType.Cpu) {
                    const string valueName = nameof(M68KOperationSize.CpuOperationSize);
                    var detailMessage = $"A value ({valueName}) is invalid when the type is ({this.Type}).";
                    throw new InvalidOperationException(detailMessage);
                }

                return this._cpuOperationSize;
            }
        }

        /// <summary>
        ///     Get FPU Operation Size.
        /// </summary>
        public M68KFpuOperationSize FpuOperationSize {
            get {
                if (this.Type != M68KOperationSizeType.Fpu) {
                    const string valueName = nameof(M68KOperationSize.FpuOperationSize);
                    var detailMessage = $"A value ({valueName}) is invalid when the type is ({this.Type}).";
                    throw new InvalidOperationException(detailMessage);
                }

                return this._fpuOperationSize;
            }
        }

        /// <summary>
        ///     Get Operation Size Type.
        /// </summary>
        public M68KOperationSizeType Type { get; }

        /// <summary>
        ///     Create an M68K Operation Size.
        /// </summary>
        /// <param name="nativeOperationSize">
        ///     A native M68K operation size.
        /// </param>
        internal M68KOperationSize(ref NativeM68KOperationSize nativeOperationSize) {
            this.Type = nativeOperationSize.Type;
            // ...
            //
            // ...
            switch (this.Type) {
                case M68KOperationSizeType.Cpu:
                    this._cpuOperationSize = nativeOperationSize.Value.CpuOperationSize;
                    break;
                case M68KOperationSizeType.Fpu:
                    this._fpuOperationSize = nativeOperationSize.Value.FpuOperationSize;
                    break;
            }
        }
    }
}