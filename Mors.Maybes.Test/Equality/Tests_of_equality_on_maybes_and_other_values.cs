using System;
using NUnit.Framework;

namespace Mors.Maybes.Test.Equality
{
    [TestFixtureSource(
        typeof(Implementations_of_equality_on_maybes_and_other_types),
        nameof(Implementations_of_equality_on_maybes_and_other_types.TestFixtureData))]
    public sealed class Tests_of_equality_on_maybes_and_other_values
    {
        private readonly Func<object, object, bool> _equalsImplementation;

        public Tests_of_equality_on_maybes_and_other_values(
            Func<object, object, bool> equalsImplementation)
        {
            _equalsImplementation = equalsImplementation;
        }

        public static TestFixtureData TestFixtureData(
            Func<object, object, bool> equals)
        {
            return new TestFixtureData(equals);
        }

        [Test]
        public void Equals_returns_false_for_maybe_with_value_and_non_maybe_object()
        {
            Assert.That(
                _equalsImplementation(new Maybe<int>(1), new object()),
                Is.False);
        }

        [Test]
        public void Equals_returns_false_for_maybe_with_value_and_maybe_with_value_of_different_type()
        {
            Assert.That(
                _equalsImplementation(new Maybe<int>(1), new Maybe<string>("2")),
                Is.False);
        }

        [Test]
        public void Equals_returns_false_for_maybes_without_value_with_different_types()
        {
            Assert.That(
                _equalsImplementation(new Maybe<int>(), new Maybe<string>()),
                Is.False);
        }

        [Test]
        public void Equals_returns_false_for_non_maybe_object_and_maybe_with_value()
        {
            Assert.That(
                _equalsImplementation(new object(), new Maybe<int>(1)),
                Is.False);
        }

        [Test]
        public void Equals_returns_false_for_maybe_without_value_and_non_maybe_object()
        {
            Assert.That(
                _equalsImplementation(new Maybe<int>(), new object()),
                Is.False);
        }

        [Test]
        public void Equals_returns_false_for_non_maybe_object_and_maybe_without_value()
        {
            Assert.That(
                _equalsImplementation(new object(), new Maybe<int>()),
                Is.False);
        }
    }
}
