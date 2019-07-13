using System;
using System.Collections.Generic;

namespace Mors.Maybes
{
    internal readonly struct SingleOfEnumerableWithPredicate<T>
    {
        private readonly IEnumerable<T> _value;
        private readonly Predicate<T> _predicate;

        public SingleOfEnumerableWithPredicate(
            IEnumerable<T> value,
            Predicate<T> predicate)
        {
            _value = value;
            _predicate = predicate;
        }

        public Maybe<T> Value()
        {
            using var enumerator = _value.GetEnumerator();
            while (enumerator.MoveNext())
            {
                var result = enumerator.Current;
                if (_predicate(result))
                {
                    while (enumerator.MoveNext())
                    {
                        if (_predicate(enumerator.Current))
                        {
                            throw new InvalidOperationException("Sequence contains more than one matching element");
                        }
                    }
                    return new Maybe<T>(result);
                }
            }
            return new Maybe<T>();
        }
    }
}