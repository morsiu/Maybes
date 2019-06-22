using System;
using System.Collections;
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
            object actualFirst = 1;
            var comparer = new EqualityComparer((x, y) => { actualFirst = x; return true; });
            var _ = Equals(2, 3, comparer);
            Assert.That(actualFirst, Is.EqualTo(2));
        }

        [Test]
        public void Equals_passes_second_value_to_comparer()
        {
            object actualSecond = 1;
            var comparer = new EqualityComparer((x, y) => { actualSecond = y; return true; });
            var _ = Equals(2, 3, comparer);
            Assert.That(actualSecond, Is.EqualTo(3));
        }

        [Test]
        public void Equals_returns_result_of_comparer()
        {
            var comparer = new EqualityComparer((x, y) => false);
            var actualResult = Equals(1, 1, comparer);
            Assert.That(actualResult, Is.False);
        }

        private static int GetHashCode(int x, IEqualityComparer e) =>
            new Maybe<int>(x).GetHashCode(e);

        [Test]
        public void GetHashCode_passes_value_to_comparer()
        {
            object actualValue = 0;
            var comparer = new EqualityComparer(x => { actualValue = x; return 0; });
            var _ = GetHashCode(1, comparer);
            Assert.That(actualValue, Is.EqualTo(1));
        }

        [Test]
        public void GetHashCode_returns_result_of_comparer()
        {
            var comparer = new EqualityComparer(x => 1);
            var actualResult = GetHashCode(1, comparer);
            Assert.That(actualResult, Is.EqualTo(1));
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
