using System.Collections.Generic;

namespace Mors.Maybes
{
    internal readonly struct LastOfEnumerable<T>
    {
        private readonly IEnumerable<T> _value;

        public LastOfEnumerable(IEnumerable<T> value) => _value = value;

        public Maybe<T> Value()
        {
            if (_value is IList<T> list)
            {
                var count = list.Count;
                return count > 0
                    ? new Maybe<T>(list[count - 1])
                    : new Maybe<T>();
            }
            using var enumerator = _value.GetEnumerator();
            if (!enumerator.MoveNext())
            {
                return new Maybe<T>();
            }
            T last;
            do
            {
                last = enumerator.Current;
            }
            while (enumerator.MoveNext());
            return new Maybe<T>(last);
        }
    }
}