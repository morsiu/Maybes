using NUnit.Framework;

namespace Mors.Maybes.Test.Inspection_of_values
{
    public sealed class Tests_whether_maybe_has_any_value
    {
        public sealed class Maybe_with_stored_value
        {
            private static Maybe<T> Instance<T>(T x) => new Maybe<T>(x);

            [Test]
            public void HasValueReturnsTrue()
            {
                Assert.That(
                    Instance(1).HasValue,
                    Is.True);
            }

            [Test]
            public void HasNoneReturnsFalse()
            {
                Assert.That(
                    Instance(1).HasNone,
                    Is.False);
            }
        }

        public sealed class Maybe_without_value
        {
            private static Maybe<int> Instance() => new Maybe<int>();

            [Test]
            public void HasValueReturnsFalse()
            {
                Assert.That(
                    Instance().HasValue,
                    Is.False);
            }

            [Test]
            public void HasNoneReturnsTrue()
            {
                Assert.That(
                    Instance().HasNone,
                    Is.True);
            }
        }
    }
}