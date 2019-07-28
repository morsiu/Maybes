using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Mors.Maybes.Test.Inspection_of_values
{
    public sealed class Tests_of_extraction_of_values
    {
        public sealed class Maybe_with_stored_value
        {
            private static Maybe<T> Instance<T>(T x) => new Maybe<T>(x);

            [Test]
            public static void ToEnumerable_returns_enumerable_with_stored_value()
            {
                Assert.That(
                    Instance(1).ToEnumerable(),
                    Is.EquivalentTo(new[] { 1 }));
            }

            [Test]
            public static void ToNullable_returns_stored_value()
            {
                Assert.That(
                    Instance(2).ToNullable(),
                    Is.EqualTo(2));
            }

            [Test]
            public void Value_returns_stored_value()
            {
                Assert.That(
                    Instance(1).Value,
                    Is.EqualTo(1));
            }

            [Test]
            public void ValueOr_with_value_returns_stored_value()
            {
                Assert.That(
                    Instance(1).ValueOr(2),
                    Is.EqualTo(1));
            }

            [Test]
            public void ValueOr_with_value_of_base_type_returns_stored_value()
            {
                Assert.That(
                    Instance(new Derived()).ValueOr(new Base()),
                    Is.EqualTo(new Derived()));
            }

            [Test]
            public void ValueOr_with_value_of_derived_type_returns_stored_value()
            {
                Assert.That(
                    Instance(new Base()).ValueOr(new Derived()),
                    Is.EqualTo(new Base()));
            }

            [Test]
            public void ValueOr_with_function_returning_value_returns_stored_value()
            {
                Assert.That(
                    Instance(1).ValueOr(() => 2),
                    Is.EqualTo(1));
            }

            [Test]
            public void ValueOr_with_function_returning_value_of_base_type_returns_stored_value()
            {
                Assert.That(
                    Instance(new Derived()).ValueOr(() => new Base()),
                    Is.EqualTo(new Derived()));
            }

            [Test]
            public void ValueOr_with_function_returning_value_of_derived_type_returns_stored_value()
            {
                Assert.That(
                    Instance(new Base()).ValueOr(() => new Derived()),
                    Is.EqualTo(new Base()));
            }

            [Test]
            public void ValueOrDefault_returns_stored_value()
            {
                Assert.That(
                    Instance(2).ValueOrDefault(),
                    Is.EqualTo(2));
            }
        }

        public sealed class Maybe_without_value
        {
            private static Maybe<int> Instance() => new Maybe<int>();
            private static Maybe<T> Instance<T>() => new Maybe<T>();

            [Test]
            public static void ToEnumerable_returns_empty_enumerable()
            {
                Assert.That(
                    Instance<int>().ToEnumerable(),
                    Is.EquivalentTo(Enumerable.Empty<int>()));
            }

            [Test]
            public static void ToNullable_returns_null()
            {
                Assert.That(
                    Instance<int>().ToNullable(),
                    Is.EqualTo(null));
            }

            [Test]
            public void Value_throws_InvalidOperationException()
            {
                Assert.That(
                    () => Instance().Value,
                    Throws.Exception.TypeOf<InvalidOperationException>());
            }

            [Test]
            public void ValueOr_with_value_returns_that_value()
            {
                Assert.That(
                    Instance().ValueOr(1),
                    Is.EqualTo(1));
            }

            [Test]
            public void ValueOr_with_value_of_base_type_returns_that_value()
            {
                Assert.That(
                    Instance<Derived>().ValueOr(new Base()),
                    Is.EqualTo(new Base()));
            }

            [Test]
            public void ValueOr_with_value_of_derived_type_returns_that_value()
            {
                Assert.That(
                    Instance<Base>().ValueOr(new Derived()),
                    Is.EqualTo(new Derived()));
            }

            [Test]
            public void ValueOr_with_function_returning_value_returns_that_value()
            {
                Assert.That(
                    Instance().ValueOr(() => 1),
                    Is.EqualTo(1));
            }

            [Test]
            public void ValueOr_with_function_returning_value_of_base_type_returns_that_value()
            {
                Assert.That(
                    Instance<Derived>().ValueOr(() => new Base()),
                    Is.EqualTo(new Base()));
            }

            [Test]
            public void ValueOr_with_function_returning_value_of_derived_type_returns_that_value()
            {
                Assert.That(
                    Instance<Base>().ValueOr(() => new Derived()),
                    Is.EqualTo(new Derived()));
            }

            [Test]
            public void ValueOrDefault_returns_default_value()
            {
                Assert.That(
                    Instance<int>().ValueOrDefault(),
                    Is.EqualTo(0));
            }
        }

        public sealed class Maybe_of_enumerable_type
        {
            private static Maybe<T> Instance<T>() => new Maybe<T>();
            private static Maybe<T> Instance<T>(T x) => new Maybe<T>(x);

            [Test]
            public void ValueOrEmpty_on_maybe_without_value_returns_empty_enumerable()
            {
                Assert.That(
                    Instance<IEnumerable<int>>().ValueOrEmpty(),
                    Is.EquivalentTo(Enumerable.Empty<int>()));
            }

            [Test]
            public void ValueOrEmpty_on_maybe_with_empty_value_returns_empty_enumerable()
            {
                Assert.That(
                    Instance(Enumerable.Empty<int>()).ValueOrEmpty(),
                    Is.EquivalentTo(Enumerable.Empty<int>()));
            }

            [Test]
            public void ValueOrEmpty_on_maybe_with_non_empty_value_returns_that_value()
            {
                Assert.That(
                    Instance(Enumerable.Repeat(1, 1)).ValueOrEmpty(),
                    Is.EquivalentTo(Enumerable.Repeat(1, 1)));
            }
        }

        public static class Enumerable_of_maybe_type
        {
            private static Maybe<int> Instance() => new Maybe<int>();
            private static Maybe<int> Instance(int x) => new Maybe<int>(x);

            public static IEnumerable<TestCaseData> MaybesWithValues()
            {
                yield return Row(
                    Enumerable<Maybe<int>>(),
                    Enumerable<int>(),
                    "Empty");
                yield return Row(
                    Enumerable(Instance()),
                    Enumerable<int>(),
                    "Maybe.None<T>()");
                yield return Row(
                    Enumerable(Instance(1)),
                    Enumerable(1),
                    "T.Some()");
                yield return Row(
                    Enumerable(Instance(1), Instance()),
                    Enumerable(1),
                    "T.Some(), T.Some()");
                yield return Row(
                    Enumerable(Instance(1), Instance(), Instance(2)),
                    Enumerable(1, 2),
                    "T.Some(), T.Some(), T.Some()");

                static TestCaseData Row(
                    IEnumerable<Maybe<int>> maybes,
                    IEnumerable<int> values,
                    string description) =>
                    new TestCaseData(maybes, values)
                        .WithArgsDisplayName(description);

                static IEnumerable<T> Enumerable<T>(params T[] values) =>
                    values;
            }

            [TestCaseSource(nameof(MaybesWithValues))]
            public static void WhereSome_returns_values_of_non_empty_maybes(
                IEnumerable<Maybe<int>> maybes,
                IEnumerable<int> values)
            {
                Assert.That(
                    maybes.WhereSome(),
                    Is.EqualTo(values));
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