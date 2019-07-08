using NUnit.Framework;

namespace Mors.Maybes.Test.Formatting
{
    public sealed class Tests_of_conversion_to_string
    {
        private static Maybe<T> Instance<T>(T x) => new Maybe<T>(x);
        private static Maybe<T> Instance<T>() => new Maybe<T>();

        [Test]
        public void ToString_with_maybe_with_value()
        {
            Assert.That(
                Instance(new Foo("value")).ToString(),
                Is.EqualTo("value"));
        }

        [Test]
        public void ToString_with_maybe_with_null()
        {
            Assert.That(
                Instance(default(object)).ToString(),
                Is.EqualTo(""));
        }

        [Test]
        public void ToString_with_maybe_without_value()
        {
            Assert.That(
                Instance<object>().ToString(),
                Is.EqualTo(""));
        }

        private sealed class Foo
        {
            private readonly string _toString;
            public Foo(string toString) => _toString = toString;
            public override string ToString() => _toString;
        }
    }
}