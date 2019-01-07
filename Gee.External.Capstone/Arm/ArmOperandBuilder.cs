namespace Gee.External.Capstone.Arm {
    /// <summary>
    ///     ARM Operand Builder.
    /// </summary>
    internal sealed class ArmOperandBuilder {
        /// <summary>
        ///     Get and Set Operand's Access Type.
        /// </summary>
        internal OperandAccessType AccessType { get; private set; }

        /// <summary>
        ///     Get and Set Floating Point Value.
        /// </summary>
        internal double FloatingPoint { get; private set; }

        /// <summary>
        ///     Get and Set Immediate Value.
        /// </summary>
        internal int Immediate { get; private set; }

        /// <summary>
        ///     Get and Set Operand's Subtracted Flag.
        /// </summary>
        internal bool IsSubtracted { get; private set; }

        /// <summary>
        ///     Get and Set Memory Value.
        /// </summary>
        internal ArmMemoryOperandValue Memory { get; private set; }

        /// <summary>
        ///     Get and Set Neon Lane Value.
        /// </summary>
        internal sbyte NeonLane { get; private set; }

        /// <summary>
        ///     Get and Set Register.
        /// </summary>
        internal ArmRegister Register { get; private set; }

        /// <summary>
        ///     Get and Set SETEND Operation.
        /// </summary>
        internal ArmSetEndOperation SetEndOperation { get; private set; }

        /// <summary>
        ///     Get and Set Shift Constant.
        /// </summary>
        internal int ShiftConstant { get; private set; }

        /// <summary>
        ///     Get and Set Shift Operation.
        /// </summary>
        internal ArmShiftOperation ShiftOperation { get; private set; }

        /// <summary>
        ///     Get and Set Shift Register.
        /// </summary>
        internal ArmRegister ShiftRegister { get; private set; }

        /// <summary>
        ///     Get and Set System Register.
        /// </summary>
        internal ArmSystemRegister SystemRegister { get; private set; }

        /// <summary>
        ///     Get and Set Operand's Type.
        /// </summary>
        internal ArmOperandType Type { get; private set; }

        /// <summary>
        ///     Get and Set Vector Index.
        /// </summary>
        internal int VectorIndex { get; private set; }

        /// <summary>
        ///     Build an ARM Operand.
        /// </summary>
        /// <param name="disassembler">
        ///     A disassembler.
        /// </param>
        /// <param name="nativeOperand">
        ///     A native ARM operand.
        /// </param>
        /// <returns>
        ///     This builder.
        /// </returns>
        internal ArmOperandBuilder Build(CapstoneDisassembler disassembler, ref NativeArmOperand nativeOperand) {
            this.AccessType = !CapstoneDisassembler.IsDietModeEnabled ? nativeOperand.AccessType : OperandAccessType.Invalid;
            this.IsSubtracted = nativeOperand.IsSubtracted;
            this.NeonLane = nativeOperand.NeonLane;
            this.ShiftOperation = nativeOperand.Shift.Operation;
            this.Type = nativeOperand.Type;
            this.VectorIndex = nativeOperand.VectorIndex;
            // ...
            //
            // ...
            if (this.ShiftOperation < ArmShiftOperation.ARM_SFT_ASR_REG) {
                this.ShiftConstant = nativeOperand.Shift.Value;
            }
            else {
                this.ShiftRegister = ArmRegister.TryCreate(disassembler, (ArmRegisterId) nativeOperand.Shift.Value);
            }

            // ...
            //
            // ...

            switch (this.Type) {
                case ArmOperandType.CImmediate:
                    this.Immediate = nativeOperand.Value.Immediate;
                    break;
                case ArmOperandType.FloatingPoint:
                    this.FloatingPoint = nativeOperand.Value.FloatingPoint;
                    break;
                case ArmOperandType.Immediate:
                    this.Immediate = nativeOperand.Value.Immediate;
                    break;
                case ArmOperandType.Memory:
                    this.Memory = ArmMemoryOperandValue.Create(disassembler, ref nativeOperand.Value.Memory);
                    break;
                case ArmOperandType.PImmediate:
                    this.Immediate = nativeOperand.Value.Immediate;
                    break;
                case ArmOperandType.Register:
                    this.Register = ArmRegister.TryCreate(disassembler, (ArmRegisterId) nativeOperand.Value.Register);
                    break;
                case ArmOperandType.SetEndOperation:
                    this.SetEndOperation = nativeOperand.Value.SetEndOperation;
                    break;
                case ArmOperandType.SystemRegister:
                    this.SystemRegister = (ArmSystemRegister) nativeOperand.Value.Register;
                    break;
            }

            return this;
        }

        /// <summary>
        ///     Create an ARM Operand.
        /// </summary>
        /// <returns>
        ///     An ARM operand.
        /// </returns>
        internal ArmOperand Create() {
            return new ArmOperand(this);
        }
    }
}