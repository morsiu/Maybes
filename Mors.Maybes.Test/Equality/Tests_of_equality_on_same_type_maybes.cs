using System;
using NUnit.Framework;

namespace Mors.Maybes.Test.Equality
{
    [TestFixtureSource(
        typeof(Implementations_of_equality_on_maybes_of_same_type),
        nameof(Implementations_of_equality_on_maybes_of_same_type.TestFixtureData))]
    public sealed class Tests_of_equality_on_same_type_maybes
    {
        private readonly Func<Maybe<int>, Maybe<int>, bool> _equalsImplementation;

        public Tests_of_equality_on_same_type_maybes(
            Func<Maybe<int>, Maybe<int>, bool> equalsImplementation)
        {
            _equalsImplementation = equalsImplementation;
        }

        public static TestFixtureData TestFixtureData(
            Func<Maybe<int>, Maybe<int>, bool> equals)
        {
            return new TestFixtureData(equals);
        }

        [Test]
        public void Equals_returns_true_for_two_maybes_without_values()
        {
            Assert.That(
                _equalsImplementation(new Maybe<int>(), new Maybe<int>()),
                Is.True);
        }

        [Test]
        public void Equals_returns_true_for_two_maybes_with_equal_values()
        {
            Assert.That(
                _equalsImplementation(new Maybe<int>(1), new Maybe<int>(1)),
                Is.True);
        }

        [Test]
        public void Equals_returns_false_for_one_maybe_with_value_and_second_without_value()
        {
            Assert.That(
                _equalsImplementation(new Maybe<int>(1), new Maybe<int>()),
                Is.False);
        }

        [Test]
        public void Equals_returns_false_for_one_maybe_without_value_and_second_with_value()
        {
            Assert.That(
                _equalsImplementation(new Maybe<int>(), new Maybe<int>(1)),
                Is.False);
        }

        [Test]
        public void Equals_returns_false_for_two_maybes_with_different_values()
        {
            Assert.That(
                _equalsImplementation(new Maybe<int>(1), new Maybe<int>(2)),
                Is.False);
        }
    }
}
