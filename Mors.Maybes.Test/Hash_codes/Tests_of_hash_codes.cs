using NUnit.Framework;

namespace Mors.Maybes.Test.Hash_codes
{
    [TestFixtureSource(
        typeof(Implementations_of_hash_codes),
        nameof(Implementations_of_hash_codes.TestFixtureData))]
    public sealed class Tests_of_hash_codes
    {
        private readonly IHashCodeImplementation _implementation;

        public Tests_of_hash_codes(IHashCodeImplementation implementation) =>
            _implementation = implementation;

        public static TestFixtureData TestFixtureData(IHashCodeImplementation implementation) =>
            new TestFixtureData(implementation);

        [Test]
        public void Maybe_with_value_has_hash_code_of_value()
        {
            Assert.That(
                _implementation.Invoke(new Maybe<Foo>(new Foo(10))),
                Is.EqualTo(10));
        }

        [Test]
        public void Maybe_with_null_has_zero_hash_code()
        {
            Assert.That(
                _implementation.Invoke(new Maybe<object>(null)),
                Is.EqualTo(0));
        }

        [Test]
        public void Maybe_without_value_has_zero_hash_code()
        {
            Assert.That(
                _implementation.Invoke(new Maybe<int>()),
                Is.EqualTo(0));
        }

        public sealed class Foo
        {
            private readonly int _hashCode;
            public Foo(int hashCode) => _hashCode = hashCode;
            public override int GetHashCode() => _hashCode;
        }

        public interface IHashCodeImplementation
        {
            int Invoke<T>(Maybe<T> maybe);
        }
    }
}