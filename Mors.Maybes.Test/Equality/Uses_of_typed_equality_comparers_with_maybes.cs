using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Mors.Maybes.Test.Equality
{
    public static class Uses_of_typed_equality_comparers_with_maybes
    {
        public static IEnumerable<TestFixtureData> TestFixtureData()
        {
            yield return TestFixtureData(
                "Maybe<T>.Equals(Maybe<T>, IEqualityComparer<T>)",
                (x, y, e) => x.Some().Equals(y.Some(), e));
            yield return TestFixtureData(
                "new MaybeEqualityComparer<T>(IEqualityComparer<T>).Equals(Maybe<T>, Maybe<T>)",
                (x, y, e) => new MaybeEqualityComparer<int>(e).Equals(x.Some(), y.Some()));
            yield return TestFixtureData(
                "Maybe<T>.Contains(T, IEqualityComparer<T>)",
                (x, y, e) => x.Some().Contains(y, e));

            TestFixtureData TestFixtureData(
                string useDescription,
                Func<int, int, IEqualityComparer<int>, bool> useThatUsesComparer)
            {
                return Tests_of_maybes_with_typed_equality_comparers
                    .TestFixtureData(useThatUsesComparer)
                    .WithDisplayName(useDescription);
            }
        }
    }
}
