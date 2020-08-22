using System;
using System.Collections.Generic;


namespace R5T.Stagira
{
    public abstract class TypedStringsList<T>
        where T : TypedString
    {
        public List<T> Values { get; } = new List<T>();


        public TypedStringsList()
        {
        }

        public TypedStringsList(IEnumerable<T> values)
        {
            this.Values.AddRange(values);
        }
    }
}
