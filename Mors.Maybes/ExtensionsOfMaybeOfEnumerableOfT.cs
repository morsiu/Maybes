using System.Collections.Generic;
using System.Linq;

namespace Mors.Maybes
{
    public static class ExtensionsOfMaybeOfEnumerableOfT
    {
        public static IEnumerable<T> ValueOrEmpty<T>(in this Maybe<IEnumerable<T>> maybe)
        {
            if (maybe.HasNone)
            {
                return Enumerable.Empty<T>();
            }
            using (var enumerator = maybe.Value.GetEnumerator())
            {
                return enumerator.MoveNext()
                    ? maybe.Value
                    : Enumerable.Empty<T>();
            }
        }
    }
}
