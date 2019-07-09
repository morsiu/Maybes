using NUnit.Framework;

namespace Mors.Maybes.Test.Manipulation_of_values
{
    public sealed class Tests_of_ensuring_maybe_has_value
    {
        public sealed class Maybe_with_stored_value
        {
            private static Maybe<int> Instance() => new Maybe<int>();
            private static Maybe<T> Instance<T>(T x) => new Maybe<T>(x);

            [Test]
            public void Else_with_value_returns_maybe_with_stored_value()
            {
                Assert.That(
                    Instance(2).Else(1),
                    Is.EqualTo(Instance(2)));
            }

            [Test]
            public void Else_with_derived_value_returns_maybe_with_stored_value()
            {
                Assert.That(
                    Instance(new Base()).Else(new Derived()),
                    Is.EqualTo(Instance(new Base())));
            }

            [Test]
            public void Else_with_base_value_returns_maybe_with_stored_value()
            {
                Assert.That(
                    Instance(new Derived()).Else(new Base()),
                    Is.EqualTo(Instance<Base>(new Derived())));
            }

            [Test]
            public void Else_with_function_returning_value_returns_maybe_with_stored_value()
            {
                Assert.That(
                    Instance(2).Else(() => 1),
                    Is.EqualTo(Instance(2)));
            }

            [Test]
            public void Else_with_function_returning_derived_value_returns_maybe_with_stored_value()
            {
                Assert.That(
                    Instance(new Base()).Else(() => new Derived()),
                    Is.EqualTo(Instance(new Base())));
            }

            [Test]
            public void Else_with_function_returning_base_value_returns_maybe_with_stored_value()
            {
                Assert.That(
                    Instance(new Derived()).Else(() => new Base()),
                    Is.EqualTo(Instance<Base>(new Derived())));
            }

            [Test]
            public void Else_with_maybe_with_value_returns_maybe_with_stored_value()
            {
                Assert.That(
                    Instance(2).Else(Instance(1)),
                    Is.EqualTo(Instance(2)));
            }

            [Test]
            public void Else_with_maybe_with_derived_value_returns_maybe_with_stored_value()
            {
                Assert.That(
                    Instance(new Base()).Else(Instance(new Derived())),
                    Is.EqualTo(Instance(new Base())));
            }

            [Test]
            public void Else_with_maybe_with_base_value_returns_maybe_with_stored_value()
            {
                Assert.That(
                    Instance(new Derived()).Else(Instance(new Base())),
                    Is.EqualTo(Instance<Base>(new Derived())));
            }

            [Test]
            public void Else_with_function_returning_maybe_with_value_returns_maybe_with_stored_value()
            {
                Assert.That(
                    Instance(2).Else(() => Instance(1)),
                    Is.EqualTo(Instance(2)));
            }

            [Test]
            public void Else_with_function_returning_maybe_with_derived_value_returns_maybe_stored_value()
            {
                Assert.That(
                    Instance(new Base()).Else(() => Instance(new Derived())),
                    Is.EqualTo(Instance(new Base())));
            }

            [Test]
            public void Else_with_function_returning_maybe_with_base_value_returns_maybe_with_stored_value()
            {
                Assert.That(
                    Instance(new Derived()).Else(() => Instance(new Base())),
                    Is.EqualTo(Instance<Base>(new Derived())));
            }

            [Test]
            public void FlatMap_passes_stored_value_to_function()
            {
                Assert.That(
                   a => Instance(2).FlatMap(x => a.Record(x).Return(Instance())),
                   Is.RecordedValue.EqualTo(2));
            }
        }

        public sealed class Maybe_without_value
        {
            private static Maybe<int> Instance() => new Maybe<int>();
            private static Maybe<T> Instance<T>() => new Maybe<T>();
            private static Maybe<T> Instance<T>(T x) => new Maybe<T>(x);

            [Test]
            public void Else_with_value_returns_maybe_with_that_value()
            {
                Assert.That(
                    Instance().Else(1),
                    Is.EqualTo(Instance(1)));
            }

            [Test]
            public void Else_with_derived_value_returns_maybe_with_that_value()
            {
                Assert.That(
                    Instance<Base>().Else(new Derived()),
                    Is.EqualTo(Instance<Base>(new Derived())));
            }

            [Test]
            public void Else_with_base_value_returns_maybe_with_that_value()
            {
                Assert.That(
                    Instance<Derived>().Else(new Base()),
                    Is.EqualTo(Instance(new Base())));
            }

            [Test]
            public void Else_with_function_returning_value_returns_maybe_with_that_value()
            {
                Assert.That(
                    Instance().Else(() => 1),
                    Is.EqualTo(Instance(1)));
            }

            [Test]
            public void Else_with_function_returning_derived_value_returns_maybe_with_that_value()
            {
                Assert.That(
                    Instance<Base>().Else(() => new Derived()),
                    Is.EqualTo(Instance<Base>(new Derived())));
            }

            [Test]
            public void Else_with_function_returning_base_value_returns_maybe_with_that_value()
            {
                Assert.That(
                    Instance<Derived>().Else(() => new Base()),
                    Is.EqualTo(Instance(new Base())));
            }

            [Test]
            public void Else_with_maybe_with_value_returns_maybe_with_that_value()
            {
                Assert.That(
                    Instance().Else(Instance(1)),
                    Is.EqualTo(Instance(1)));
            }

            [Test]
            public void Else_with_maybe_with_derived_value_returns_maybe_with_that_value()
            {
                Assert.That(
                    Instance<Base>().Else(Instance(new Derived())),
                    Is.EqualTo(Instance<Base>(new Derived())));
            }

            [Test]
            public void Else_with_maybe_with_base_value_returns_maybe_with_that_value()
            {
                Assert.That(
                    Instance<Derived>().Else(Instance(new Base())),
                    Is.EqualTo(Instance(new Base())));
            }

            [Test]
            public void Else_with_function_returning_maybe_with_value_returns_maybe_with_that_value()
            {
                Assert.That(
                    Instance().Else(() => Instance(1)),
                    Is.EqualTo(Instance(1)));
            }

            [Test]
            public void Else_with_function_returning_maybe_with_derived_value_returns_maybe_with_that_value()
            {
                Assert.That(
                    Instance<Base>().Else(() => Instance(new Derived())),
                    Is.EqualTo(Instance<Base>(new Derived())));
            }

            [Test]
            public void Else_with_function_returning_maybe_with_base_value_returns_maybe_with_that_value()
            {
                Assert.That(
                    Instance<Derived>().Else(() => Instance(new Base())),
                    Is.EqualTo(Instance(new Base())));
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