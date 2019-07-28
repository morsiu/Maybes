using System;
using System.Collections;
using System.Collections.Generic;

namespace Mors.Maybes
{
    public static partial class MaybeExtensions
    {
        public static Maybe<T> FirstOrNone<T>(this IEnumerable<T> value)
        {
            using var enumerator = value.GetEnumerator();
            return enumerator.MoveNext()
                ? new Maybe<T>(enumerator.Current)
                : new Maybe<T>();
        }

        public static Maybe<T> FirstOrNone<T>(
            this IEnumerable<T> value,
            Predicate<T> predicate)
        {
            using var enumerator = value.GetEnumerator();
            while (enumerator.MoveNext())
            {
                var result = enumerator.Current;
                if (predicate(result))
                {
                    return new Maybe<T>(result);
                }
            }
            return new Maybe<T>();
        }

        public static Maybe<T> LastOrNone<T>(this IEnumerable<T> value) =>
            new LastOfEnumerable<T>(value).Value();

        public static Maybe<T> LastOrNone<T>(
            this IEnumerable<T> value,
            Predicate<T> predicate) =>
            new LastOfEnumerableWithPredicate<T>(value, predicate).Value();

        public static Maybe<T> SingleOrNone<T>(this IEnumerable<T> value) =>
            new SingleOfEnumerable<T>(value).Value();

        public static Maybe<T> SingleOrNone<T>(
            this IEnumerable<T> value,
            Predicate<T> predicate) =>
            new SingleOfEnumerableWithPredicate<T>(value, predicate).Value();

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

        public static Maybe<T> SomeWhenSingle<T>(this IEnumerable<T> value)
        {
            using var enumerator = value.GetEnumerator();
            if (enumerator.MoveNext())
            {
                var result = enumerator.Current;
                if (!enumerator.MoveNext())
                {
                    return new Maybe<T>(result);
                }
            }
            return new Maybe<T>();
        }
    }
}
