using System;
using System.Collections.Generic;

using R5T.Magyar;


namespace R5T.Stagira
{
    public abstract class TypedStringsList<T> : TypedList<T>
        where T : TypedString
    {
        public TypedStringsList()
        {
        }

        public TypedStringsList(IEnumerable<T> values)
            : base(values)
        {
        }
    }
}
