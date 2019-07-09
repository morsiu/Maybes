using System;
using System.Collections;
using Mors.Maybes.Test.Extensions;
using NUnit.Framework;

namespace Mors.Maybes.Test.Equality
{
    public sealed class Tests_of_maybes_with_untyped_equality_comparers
    {
        private static bool Equals(int x, int y, IEqualityComparer e) =>
            new Maybe<int>(x).Equals(new Maybe<int>(y), e);

        [Test]
        public void Equals_passes_first_value_to_comparer()
        {
            IEqualityComparer Comparer(RecordedValue a) =>
                new EqualityComparer((x, y) => a.Record(x).Return(true));
            Assert.That(
                a => Equals(2, 3, Comparer(a)),
                Is.RecordedValue.EqualTo(2));
        }

        [Test]
        public void Equals_passes_second_value_to_comparer()
        {
            IEqualityComparer Comparer(RecordedValue a) =>
                new EqualityComparer((x, y) => a.Record(y).Return(true));
            Assert.That(
               a => Equals(2, 3, Comparer(a)),
               Is.RecordedValue.EqualTo(3));
        }

        [Test]
        public void Equals_returns_result_of_comparer()
        {
            var comparer = new EqualityComparer((x, y) => false);
            Assert.That(
                Equals(1, 1, comparer),
                Is.False);
        }

        private static int GetHashCode(int x, IEqualityComparer e) =>
            new Maybe<int>(x).GetHashCode(e);

        [Test]
        public void GetHashCode_passes_value_to_comparer()
        {
            IEqualityComparer Comparer(RecordedValue a) =>
                new EqualityComparer(x => a.Record(x).Return(0));
            Assert.That(
                a => GetHashCode(1, Comparer(a)),
                Is.RecordedValue.EqualTo(1));
        }

        [Test]
        public void GetHashCode_returns_result_of_comparer()
        {
            var comparer = new EqualityComparer(x => 1);
            Assert.That(
                GetHashCode(1, comparer),
                Is.EqualTo(1));
        }

        private sealed class EqualityComparer : IEqualityComparer
        {
            private readonly Func<object, object, bool> _equals;
            private readonly Func<object, int> _getHashCode;

            public EqualityComparer(Func<object, object, bool> equals) => _equals = equals;
            public EqualityComparer(Func<object, int> getHashCode) => _getHashCode = getHashCode;

            public new bool Equals(object x, object y) => _equals(x, y);
            public int GetHashCode(object obj) => _getHashCode(obj);
        }
    }
}
