using System;


namespace R5T.Stagira
{
    /// <summary>
    /// Allow wrapping a string with a specific type.
    /// This is helpful in creating strongly-typed strings for stringly-typed data. Examples: diretory path.
    /// Value is read-only, just like the value of a string.
    /// </summary>
    /// <remarks>
    /// Many objects are "stringly-typed". For example, project name, project directory name, and project directory path are all strings, but are really different types of string.
    /// Creating methods that operate on these different types of string is clumsy. Because overloading is not possible (all methods take in the same argument type, string), methods must have different names.
    /// These extra names require more effort by the writer, but by the user, since they have to sort through the confusion caused by having multiple names for what is really the same operation being applied to different input types.
    /// The resolution to this difficulty is creating types that merely contain a string.
    /// This base type provides the actual functionality, inheritors just provide a name for their type of string.
    /// </remarks>
    public abstract class TypedString : IEquatable<TypedString>, IComparable<TypedString>
    {
        #region Static

        public static bool operator== (TypedString a, TypedString b)
        {
            if(a is null)
            {
                var output = b is null;
                return output;
            }
            else
            {
                var output = a.Equals(b);
                return output;
            }
        }

        public static bool operator !=(TypedString a, TypedString b)
        {
            var output = !(a == b);
            return output;
        }

        #endregion


        public string Value { get; }


        public TypedString(string value)
        {
            this.Value = value;
        }

        public override bool Equals(object obj)
        {
            // No type-check required since (obj as TypedString).GetType() will still return the actual type.

            var objAsTypedString = obj as TypedString;

            var isEqual = this.Equals(objAsTypedString);
            return isEqual;
        }

        protected virtual bool Equals_Value(TypedString other)
        {
            var isEqual = this.Value.Equals(other.Value);
            return isEqual;
        }

        public override int GetHashCode()
        {
            var hashCode = this.Value.GetHashCode();
            return hashCode;
        }

        public override string ToString()
        {
            return this.Value;
        }

        public bool Equals(TypedString other)
        {
            // Required type-check for derived classes using the base class TypedString.Equals(TypedString).
            if (other == null || !other.GetType().Equals(this.GetType()))
            {
                return false;
            }

            var isEqual = this.Equals_Value(other);
            return isEqual;
        }

        public int CompareTo(TypedString other)
        {
            var output = this.Value.CompareTo(other.Value);
            return output;
        }
    }
}
