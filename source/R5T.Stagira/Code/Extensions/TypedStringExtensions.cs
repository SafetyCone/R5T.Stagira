using System;


namespace R5T.Stagira
{
    public static class TypedStringExtensions
    {
        public static bool ValueEquals(TypedString a, TypedString b)
        {
            var valueEquals = a.Value.Equals(b.Value);
            return valueEquals;
        }
    }
}
