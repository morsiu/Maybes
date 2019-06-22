using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Mors.Maybes.Test.Creation_with_value
{
    public static class Maybes_with_values
    {
        public static IEnumerable<TestFixtureData> TestFixtureData()
        {
            yield return TestFixtureData(
                "Maybe.Some(x)",
                () => Maybes.Maybe.Some(1),
                1);
            yield return TestFixtureData(
                "new Maybe<T>(x)",
                () => new Maybe<int>(1),
                1);
            yield return TestFixtureData(
                "x.Some()",
                () => 1.Some(),
                1);
            yield return TestFixtureData(
                "x.SomeNotNull(), x : T, T : class, x != null",
                () => "1".SomeNotNull(),
                "1");
            yield return TestFixtureData(
                "x.SomeNotNull(), x : T?, x != null",
                () => new int?(1).SomeNotNull(),
                1);
            yield return TestFixtureData(
                "x.SomeWhen(true)",
                () => 1.SomeWhen(true),
                1);
            yield return TestFixtureData(
                "x.SomeWhen(() => true)",
                () => 1.SomeWhen(() => true),
                1);
            yield return TestFixtureData(
                "x.SomeWhen(_ => true)",
                () => 1.SomeWhen(y => y == 1),
                1);
            yield return TestFixtureData(
                "x.SomeNotDefault(), x : T, x != default(T)",
                () => 1.SomeNotDefault(),
                1);
            yield return TestFixtureData(
                "x.NoneWhen(false)",
                () => 1.NoneWhen(false),
                1);
            yield return TestFixtureData(
                "x.NoneWhen(() => false)",
                () => 1.NoneWhen(() => false),
                1);
            yield return TestFixtureData(
                "x.NoneWhen(_ => false)",
                () => 1.NoneWhen(y => y != 1),
                1);
            yield return TestFixtureData(
                "x.SomeNotEmpty(), x : IEnumerable, x.Any() == true",
                () => new[] { 1 }.SomeNotEmpty(),
                new[] { 1 });
            yield return TestFixtureData(
                "x.SomeOfEnumerable(), x : IEnumerable<U>",
                () => new[] { 1 }.SomeOfEnumerable(),
                new[] { 1 }.AsEnumerable());
            yield return TestFixtureData(
                "x.TryCast<U>(), x : T, T : U",
                () => new Derived().TryCast<Base>(),
                Maybe<Base>(new Derived()));
            yield return TestFixtureData(
                "x.TryCast<T>(), x : T",
                () => new Derived().TryCast<Derived>(),
                new Derived());

            TestFixtureData TestFixtureData<T>(
                string maybeDescription,
                Func<Maybe<T>> maybe,
                T expectedValue)
            {
                return Tests_of_creation_with_value<T>
                    .TestFixtureData(maybe, expectedValue)
                    .SetArgDisplayNames(maybeDescription);
            }
        }

        private static T Maybe<T>(T x) => x;

        private class Base
        {
            public override bool Equals(object obj) => obj?.GetType() == GetType();
            public override int GetHashCode() => GetType().GetHashCode();
        }

        private sealed class Derived : Base { }
    }
}
