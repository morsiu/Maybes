using System;
using System.Collections.Generic;
using Mors.Maybes.Test.Extensions;
using NUnit.Framework;

namespace Mors.Maybes.Test.Equality
{
    [TestFixtureSource(
        typeof(Uses_of_typed_equality_comparers_with_maybes),
        nameof(Uses_of_typed_equality_comparers_with_maybes.TestFixtureData))]
    public sealed class Tests_of_maybes_with_typed_equality_comparers
    {
        private readonly Func<int, int, IEqualityComparer<int>, bool> _useThatCallsComparer;

        public Tests_of_maybes_with_typed_equality_comparers(
            Func<int, int, IEqualityComparer<int>, bool> useThatCallsComparer)
        {
            _useThatCallsComparer = useThatCallsComparer;
        }

        public static TestFixtureData TestFixtureData(
            Func<int, int, IEqualityComparer<int>, bool> equalsThatUsesComparer) =>
            new TestFixtureData(equalsThatUsesComparer);

        [Test]
        public void Use_passes_first_value_to_comparer()
        {
            IEqualityComparer<int> Comparer(RecordedValue a) =>
                new EqualityComparer((x, y) => a.Record(x).Return(true));
            Assert.That(
                a => _useThatCallsComparer(2, 3, Comparer(a)),
                Is.RecordedValue.EqualTo(2));
        }

        [Test]
        public void Use_passes_second_value_to_comparer()
        {
            IEqualityComparer<int> Comparer(RecordedValue a) =>
                new EqualityComparer((x, y) => a.Record(y).Return(true));
            Assert.That(
                a => _useThatCallsComparer(2, 3, Comparer(a)),
                Is.RecordedValue.EqualTo(3));
        }

        [Test]
        public void Use_returns_result_of_comparer()
        {
            var comparer = new EqualityComparer((x, y) => false);
            Assert.That(
                _useThatCallsComparer(1, 1, comparer),
                Is.False);
        }

        private sealed class EqualityComparer : IEqualityComparer<int>
        {
            private readonly Func<int, int, bool> _equals;

            public EqualityComparer(Func<int, int, bool> equals) => _equals = equals;

            public bool Equals(int x, int y) => _equals(x, y);
            public int GetHashCode(int obj) => throw new NotImplementedException();
        }
    }
}
