using System;


namespace R5T.Stagira
{
    /// <summary>
    /// Allow wrapping a string with a specific type.
    /// This is helpful in creating strongly-typed strings for stringly-typed data. Examples: diretory path.
    /// Value is read-only (just like the value of a string) and internal to allow descendents to name the property they publically expose.
    /// </summary>
    /// <remarks>
    /// See further remarks for <see cref="TypedString"/>.
    /// </remarks>
    public abstract class InternalValueTypedString : IEquatable<InternalValueTypedString>, IComparable<InternalValueTypedString>
    {
        #region Static

        public static bool operator== (InternalValueTypedString a, InternalValueTypedString b)
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

        public static bool operator !=(InternalValueTypedString a, InternalValueTypedString b)
        {
            var output = !(a == b);
            return output;
        }

        #endregion


        protected string Value { get; }


        public InternalValueTypedString(string value)
        {
            this.Value = value;
        }

        public override bool Equals(object obj)
        {
            // No type-check required since (obj as TypedString).GetType() will still return the actual type.

            var objAsTypedString = obj as InternalValueTypedString;

            var isEqual = this.Equals(objAsTypedString);
            return isEqual;
        }

        protected virtual bool Equals_Value(InternalValueTypedString other)
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

        public bool Equals(InternalValueTypedString other)
        {
            // Required type-check for derived classes using the base class TypedString.Equals(TypedString).
            if (other == null || !other.GetType().Equals(this.GetType()))
            {
                return false;
            }

            var isEqual = this.Equals_Value(other);
            return isEqual;
        }

        public int CompareTo(InternalValueTypedString other)
        {
            var output = this.Value.CompareTo(other.Value);
            return output;
        }
    }
}
