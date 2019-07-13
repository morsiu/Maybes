using System;
using System.Collections.Generic;

namespace Mors.Maybes
{
    internal readonly struct SingleOfEnumerable<T>
    {
        private readonly IEnumerable<T> _value;

        public SingleOfEnumerable(IEnumerable<T> value)
        {
            _value = value;
        }

        public Maybe<T> Value()
        {
            if (_value is IList<T> value)
            {
                switch (value.Count)
                {
                    case 0:
                        return new Maybe<T>();
                    case 1:
                        return new Maybe<T>(value[0]);
                }
            }
            else
            {
                using var enumerator = _value.GetEnumerator();
                if (!enumerator.MoveNext())
                {
                    return new Maybe<T>();
                }
                var result = enumerator.Current;
                if (!enumerator.MoveNext())
                {
                    return new Maybe<T>(result);
                }
            }
            throw new InvalidOperationException("Sequence contains more than one element");
        }
    }
}