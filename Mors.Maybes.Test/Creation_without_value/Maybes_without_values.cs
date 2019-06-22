using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Mors.Maybes.Test.Creation_without_value
{
    public static class Maybes_without_values
    {
        public static IEnumerable<TestFixtureData> TestFixtureData()
        {
            yield return Data<int>(
                "Maybe.None()",
                 () => Maybe.None());
            yield return Data(
                "Maybe.None<T>()",
                 () => Maybe.None<int>());
            yield return Data(
                "new Maybe<T>()",
                 () => new Maybe<int>());
            yield return Data<int>(
                "default(Maybe<T>)",
                 () => default);
            yield return Data(
                "x.SomeNotNull(), x : T, T : class, x == null",
                 () => default(object).SomeNotNull());
            yield return Data(
                "x.SomeNotNull(), x : T?, x == null",
                 () => default(int?).SomeNotNull());
            yield return Data(
                "x.NoneWhen(true)",
                 () => 1.NoneWhen(true));
            yield return Data(
                "x.NoneWhen(() => true)",
                 () => 1.NoneWhen(() => true));
            yield return Data(
                "x.NoneWhen(_ => true)",
                 () => 1.NoneWhen(y => y == 1));
            yield return Data(
                "x.SomeWhen(false)",
                 () => 1.SomeWhen(false));
            yield return Data(
                "x.SomeWhen(() => false)",
                 () => 1.SomeWhen(() => false));
            yield return Data(
                "x.SomeWhen(_ => false)",
                 () => 1.SomeWhen(y => y != 1));
            yield return Data(
                "x.SomeNotEmpty(), x : T, T : IEnumerable, x.Any() == false",
                 () => new int[0].SomeNotEmpty());
            yield return Data(
                "x.TryCast<U>(), x : T, U : T",
                 () => new Base().TryCast<Derived>());
            yield return Data(
                "x.TryCast<U>(), x : T, neither T : U, nor U : T",
                 () => "1".TryCast<int>());

            TestFixtureData Data<T>(string maybeDescription, Func<Maybe<T>> maybe)
            {
                return Tests_of_creation_without_values<T>
                    .TestFixtureData(maybe)
                    .SetArgDisplayNames(maybeDescription);
            }
        }

        private class Base
        {
            public override bool Equals(object obj) => obj?.GetType() == GetType();
            public override int GetHashCode() => GetType().GetHashCode();
        }

        private sealed class Derived : Base { }
    }
}
