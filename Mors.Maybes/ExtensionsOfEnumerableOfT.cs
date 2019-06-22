using System.Collections;
using System.Collections.Generic;

namespace Mors.Maybes
{
    public static class ExtensionsOfEnumerableOfT
    {
        public static Maybe<IEnumerable<T>> SomeOfEnumerable<T>(this IEnumerable<T> value) =>
            new Maybe<IEnumerable<T>>(value);

        public static Maybe<TEnumerable> SomeNotEmpty<TEnumerable>(this TEnumerable value)
            where TEnumerable : IEnumerable
        {
            var enumerator = value.GetEnumerator();
            return enumerator.MoveNext()
                ? new Maybe<TEnumerable>(value)
                : new Maybe<TEnumerable>();
        }
    }
}
