using System;
using System.Collections;
using NUnit.Framework;

namespace Mors.Maybes.Test.Creation_of_maybes
{
    [TestFixtureSource(
        typeof(Maybes_without_values),
        nameof(Maybes_without_values.TestFixtureData))]
    public sealed class Tests_of_creation_without_values<T>
    {
        private readonly Func<Maybe<T>> _createdMaybe;

        public Tests_of_creation_without_values(Func<Maybe<T>> createdMaybe)
        {
            _createdMaybe = createdMaybe;
        }

        public static TestFixtureData TestFixtureData(Func<Maybe<T>> createdMaybe) =>
            new TestFixtureData(typeof(T), createdMaybe);

        [Test]
        public void Created_maybe_equals_maybe_with_expected_value()
        {
            Assert.That(
                _createdMaybe(),
                Is.EqualTo(new Maybe<T>())
                    .Using(StructuralComparisons.StructuralEqualityComparer));
        }
    }
}
