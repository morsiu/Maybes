using System;
using System.Collections.Generic;

namespace Mors.Maybes
{
    internal readonly struct LastOfEnumerableWithPredicate<T>
    {
        private readonly IEnumerable<T> _value;
        private readonly Predicate<T> _predicate;

        public LastOfEnumerableWithPredicate(
            IEnumerable<T> value,
            Predicate<T> predicate)
        {
            _value = value;
            _predicate = predicate;
        }

        public Maybe<T> Value()
        {
            if (_value is IList<T> list)
            {
                for (var x = list.Count - 1; x >= 0; --x)
                {
                    var result = list[x];
                    if (_predicate(result))
                    {
                        return new Maybe<T>(result);
                    }
                }
                return new Maybe<T>();
            }
            using var enumerator = _value.GetEnumerator();
            while (enumerator.MoveNext())
            {
                var result = enumerator.Current;
                if (_predicate(result))
                {
                    while (enumerator.MoveNext())
                    {
                        var element = enumerator.Current;
                        if (_predicate(element))
                        {
                            result = element;
                        }
                    }
                    return new Maybe<T>(result);
                }
            }
            return new Maybe<T>();
        }
    }
}