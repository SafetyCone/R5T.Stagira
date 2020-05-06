using System;


namespace R5T.Stagira.Construction
{
    static class Experiments
    {
        public static void SubMain()
        {
            //Experiments.DifferentTypesOperatorEquals();
            Experiments.DifferentTypesAsObjectEquals();
        }

        static void DifferentTypesAsObjectEquals()
        {
            object a = new TypedStringA("Value");
            var b = new TypedStringB("Value");

            var equal = b.Equals(a);

            Console.WriteLine($"{equal} = {nameof(a)} == {nameof(b)}");
        }

        /// <summary>
        /// What if we have two different <see cref="TypedString"/> types. Do they operator Equals (==) each other?
        /// They should *NOT* equal each other!
        /// </summary>
        static void DifferentTypesOperatorEquals()
        {
            var a = new TypedStringA("Value");
            var b = new TypedStringB("Value");

            var equal = a == b;

            Console.WriteLine($"{equal} = {nameof(a)} == {nameof(b)}");
        }
    }
}
