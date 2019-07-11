using NUnit.Framework;

namespace Mors.Maybes.Test.Manipulation_of_values
{
    public static class Tests_of_manipulation_of_nested_values
    {
        public static Maybe<T> Instance<T>(T value) => new Maybe<T>(value);
        public static Maybe<T> Instance<T>() => new Maybe<T>();
        public static Maybe<int> Instance() => new Maybe<int>();

        [Test]
        public static void Flatten_returns_maybe_with_value_stored_in_a_maybe_within_a_maybe()
        {
            Assert.That(
                Instance(Instance(1)).Flatten(),
                Is.EqualTo(Instance(1)));
        }

        [Test]
        public static void Flatten_with_maybe_without_maybe_value_returns_maybe_without_value()
        {
            Assert.That(
                Instance<Maybe<int>>().Flatten(),
                Is.EqualTo(Instance()));
        }

        [Test]
        public static void Flatten_with_maybe_with_maybe_without_value_returns_maybe_without_value()
        {
            Assert.That(
                Instance(Instance()).Flatten(),
                Is.EqualTo(Instance()));
        }
    }
}
