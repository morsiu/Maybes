using System.Collections.Generic;
using NUnit.Framework;

namespace Mors.Maybes.Test.Inspection_of_values
{
    public sealed class Tests_whether_maybe_contains_specific_value
    {
        public sealed class Maybe_with_stored_value
        {
            private static Maybe<T> Instance<T>(T x) => new Maybe<T>(x);

            [Test]
            public void Contains_with_stored_value_returnsTrue()
            {
                Assert.That(
                    Instance(1).Contains(1),
                    Is.True);
            }

            [Test]
            public void Contains_with_non_stored_value_returnsTrue()
            {
                Assert.That(
                    Instance(1).Contains(2),
                    Is.False);
            }

            [Test]
            public void Contains_with_stored_value_and_EqualityComparer_returns_true()
            {
                Assert.That(
                    Instance(1).Contains(1, EqualityComparer<int>.Default),
                    Is.True);
            }

            [Test]
            public void Contains_with_non_stored_value_and_EqualityComparer_returns_true()
            {
                Assert.That(
                    Instance(1).Contains(0, EqualityComparer<int>.Default),
                    Is.False);
            }

            [Test]
            public void Contains_with_predicate_returns_true_from_predicate()
            {
                Assert.That(
                    Instance(1).Contains(x => true),
                    Is.True);
            }

            [Test]
            public void Contains_with_predicate_returns_false_from_predicate()
            {
                Assert.That(
                    Instance(1).Contains(x => false),
                    Is.False);
            }

            [Test]
            public void Contains_with_predicate_passes_value_to_predicate()
            {
                Assert.That(
                    a => Instance(1).Contains(x => a.Record(x).Return(true)),
                    Is.RecordedValue.EqualTo(1));
            }
        }

        public sealed class Maybe_without_value
        {
            private static Maybe<int> Instance() => new Maybe<int>();

            [Test]
            public void Contains_with_value_returns_false()
            {
                Assert.That(
                    Instance().Contains(1),
                    Is.False);
            }

            [Test]
            public void Contains_with_value_and_EqualityComparer_returns_false()
            {
                Assert.That(
                    Instance().Contains(1, EqualityComparer<int>.Default),
                    Is.False);
            }

            [Test]
            public void Contains_with_predicate_returns_false()
            {
                Assert.That(
                    Instance().Contains(x => true),
                    Is.False);
            }
        }
    }
}
