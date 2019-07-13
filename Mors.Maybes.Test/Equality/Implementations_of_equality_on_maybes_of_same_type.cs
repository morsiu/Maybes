using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;

namespace Mors.Maybes.Test.Equality
{
    public static class Implementations_of_equality_on_maybes_of_same_type
    {
        public static IEnumerable<TestFixtureData> TestFixtureData()
        {
            yield return TestFixtureData(
                "Maybe<T>.Equals(Maybe<T>)",
                (x, y) => x.Equals(y));
            yield return TestFixtureData(
                "Maybe<T>.Equals(Maybe<T>, IEqualityComparer<T>)",
                (x, y) => x.Equals(y, EqualityComparer<int>.Default));
            yield return TestFixtureData(
                "Maybe<T>.Equals(object)",
                (x, y) => x.Equals((object)y));
            yield return TestFixtureData(
                "Maybe<T>.Equals(object, IEqualityComparer)",
                (x, y) => x.Equals((object)y, EqualityComparer<int>.Default));
            yield return TestFixtureData(
                "Maybe<T>.operator==(Maybe<T>)",
                (x, y) => x == y);
            yield return TestFixtureData(
                "Maybe<T>.operator!=(Maybe<T>)",
                (x, y) => !(x != y));
            yield return TestFixtureData(
                "StructuralComparisons.StructuralEqualityComparer.Equals(object, object, IEqualityComparer)",
                (x, y) => StructuralComparisons.StructuralEqualityComparer.Equals(x, y));
            yield return TestFixtureData(
                "EqualityComparer<Maybe<T>>.Default.Equals(Maybe<T>, Maybe<T>)",
                (x, y) => EqualityComparer<Maybe<int>>.Default.Equals(x, y));
            yield return TestFixtureData(
                "new MaybeEqualityComparer<T>().Equals(Maybe<T>, Maybe<T>)",
                (x, y) => new MaybeEqualityComparer<int>().Equals(x, y));
            yield return TestFixtureData(
                "new MaybeEqualityComparer<T>(IEqualityComparer<T>).Equals(Maybe<T>, Maybe<T>)",
                (x, y) => new MaybeEqualityComparer<int>(EqualityComparer<int>.Default).Equals(x, y));

            TestFixtureData TestFixtureData(
                string equalsDescription,
                Func<Maybe<int>, Maybe<int>, bool> equals)
            {
                return Tests_of_equality_on_same_type_maybes
                    .TestFixtureData(equals)
                    .WithDisplayName(equalsDescription);
            }
        }
    }
}
