using System;

namespace Gee.External.Capstone {
    /// <summary>
    ///     Register.
    /// </summary>
    /// <typeparam name="TId">
    ///     The type of the register's unique identifiers.
    /// </typeparam>
    public abstract class Register<TId> where TId : Enum {
        /// <summary>
        ///     Register's Unique Identifier.
        /// </summary>
        private readonly TId _id;

        /// <summary>
        ///     Register's Name.
        /// </summary>
        private readonly string _name;

        /// <summary>
        ///     Get Register's Unique Identifier.
        /// </summary>
        public TId Id => this._id;

        /// <summary>
        ///     Determine if Diet Mode is Enabled.
        /// </summary>
        /// <value>
        ///     A boolean true if diet mode is enabled. A boolean false otherwise.
        /// </value>
        public bool IsDietModeEnabled => CapstoneDisassembler.IsDietModeEnabled;

        /// <summary>
        ///     Get Register's Name.
        /// </summary>
        /// <exception cref="System.NotSupportedException">
        ///     Thrown if diet mode is enabled.
        /// </exception>
        public string Name {
            get {
                CapstoneDisassembler.ThrowIfDietModeIsEnabled();
                return this._name;
            }
        }

        /// <summary>
        ///     Create a Register.
        /// </summary>
        /// <param name="id">
        ///     The register's unique identifier.
        /// </param>
        /// <param name="name">
        ///     The register's name.
        /// </param>
        private protected Register(TId id, string name) {
            this._id = id;
            this._name = name;
        }

        /// <summary>
        ///     Determine if This Object is Equal to Another Object.
        /// </summary>
        /// <param name="object">
        ///     An object to compare to. Should not be a null reference.
        /// </param>
        /// <returns>
        ///     A boolean true if this object is equal to the object. A boolean false otherwise.
        /// </returns>
        public override bool Equals(object @object) {
            var isEqual = @object != null;
            if (isEqual) {
                var register = @object as Register<TId>;
                isEqual = register != null;
                if (isEqual) {
                    isEqual = this._id.Equals(register._id);
                    isEqual = isEqual && this._name == register._name;
                }
            }

            return isEqual;
        }

        /// <summary>
        ///     Get Object's Hash Code.
        /// </summary>
        /// <returns>
        ///     The object's hash code.
        /// </returns>
        public override int GetHashCode() {
            var hashCode = 13;
            hashCode = hashCode * 7 + this._id.GetHashCode();
            hashCode = this._name != null ? hashCode * 7 + this._name.GetHashCode() : 0;

            return hashCode;
        }
    }
}