using System;
using System.Collections;
using NUnit.Framework;

namespace Mors.Maybes.Test.Creation_with_value
{
    [TestFixtureSource(
        typeof(Maybes_with_values),
        nameof(Maybes_with_values.TestFixtureData))]
    public sealed class Tests_of_creation_with_value<T>
    {
        private readonly Func<Maybe<T>> _createdMaybe;
        private readonly T _expectedValue;

        public Tests_of_creation_with_value(Func<Maybe<T>> createdMaybe, T expectedValue)
        {
            _createdMaybe = createdMaybe;
            _expectedValue = expectedValue;
        }

        public static TestFixtureData TestFixtureData(Func<Maybe<T>> createdMaybe, T expectedValue) =>
            new TestFixtureData(typeof(T), createdMaybe, expectedValue);

        [Test]
        public void Created_maybe_equals_expected_maybe()
        {
            Assert.That(_createdMaybe(), Is.EqualTo(new Maybe<T>(_expectedValue)).Using(StructuralComparisons.StructuralEqualityComparer));
        }
    }
}
