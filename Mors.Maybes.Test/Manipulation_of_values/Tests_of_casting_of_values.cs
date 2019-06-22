using NUnit.Framework;

namespace Mors.Maybes.Test.Manipulation_of_values
{
    public sealed class Tests_of_casting_of_values
    {
        public sealed class Maybe_with_stored_value
        {
            private static Maybe<T> Instance<T>() => new Maybe<T>();
            private static Maybe<T> Instance<T>(T x) => new Maybe<T>(x);

            [Test]
            public void Cast_with_base_type_returns_maybe_of_base_type_with_stored_value()
            {
                Assert.That(
                    () => Instance(new Derived()).Cast<Derived, Base>(),
                    Is.EqualTo(Instance<Base>(new Derived())));
            }

            [Test]
            public void Cast_with_stored_type_returns_maybe_with_stored_value()
            {
                Assert.That(
                    () => Instance(3).Cast<int, int>(),
                    Is.EqualTo(Instance(3)));
            }

            [Test]
            public void TryCast_with_type_incompatible_with_stored_value_returns_maybe_of_that_type_without_value()
            {
                Assert.That(
                    () => Instance(2).TryCast<string>(),
                    Is.EqualTo(Instance<string>()));
            }

            [Test]
            public void TryCast_with_type_compatible_with_stored_value_returns_maybe_of_that_type_with_stored_value()
            {
                Assert.That(
                    () => Instance<Base>(new Derived()).TryCast<Derived>(),
                    Is.EqualTo(Instance(new Derived())));
            }

            [Test]
            public void TryCast_with_type_of_stored_value_returns_maybe_of_that_type_without_value()
            {
                Assert.That(
                    () => Instance<int>().TryCast<int>(),
                    Is.EqualTo(Instance<int>()));
            }
        }

        public sealed class Maybe_without_value
        {
            private static Maybe<T> Instance<T>() => new Maybe<T>();

            [Test]
            public void Cast_with_base_type_returns_maybe_of_base_type_without_value()
            {
                Assert.That(
                    () => Instance<Derived>().Cast<Derived, Base>(),
                    Is.EqualTo(Instance<Base>()));
            }

            [Test]
            public void Cast_with_stored_type_returns_maybe_of_that_type_without_value()
            {
                Assert.That(
                    () => Instance<int>().Cast<int, int>(),
                    Is.EqualTo(Instance<int>()));
            }

            [Test]
            public void TryCast_with_type_incompatible_with_stored_value_returns_maybe_of_that_type_without_value()
            {
                Assert.That(
                    () => Instance<int>().TryCast<string>(),
                    Is.EqualTo(Instance<string>()));
            }

            [Test]
            public void TryCast_with_type_compatible_with_stored_value_returns_maybe_of_that_type_without_value()
            {
                Assert.That(
                    () => Instance<Derived>().TryCast<Base>(),
                    Is.EqualTo(Instance<Base>()));
            }

            [Test]
            public void TryCast_with_stored_type_returns_maybe_of_that_type_without_value()
            {
                Assert.That(
                    () => Instance<int>().TryCast<int>(),
                    Is.EqualTo(Instance<int>()));
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