using System;
using NUnit.Framework;

namespace Mors.Maybes.Test.Creation_of_maybes
{
    [TestFixtureSource(
        typeof(Exceptions),
        nameof(Exceptions.TestFixtureData))]
    public sealed class Tests_of_exceptions
    {
        private readonly Action _action;
        private readonly Type _exception;
        private readonly string _exceptionMessage;

        public Tests_of_exceptions(
            Action action,
            Type exception,
            string exceptionMessage)
        {
            _action = action;
            _exception = exception;
            _exceptionMessage = exceptionMessage;
        }

        [Test]
        public void Exception_is_thrown()
        {
            Assert.That(
                _action,
                Throws.TypeOf(_exception).And.Message.EqualTo(_exceptionMessage));
        }

        internal static TestFixtureData TestFixtureData(
            Action action,
            Type exception,
            string exceptionMessage)
        {
            return new TestFixtureData(
                action,
                exception,
                exceptionMessage);
        }
    }
}