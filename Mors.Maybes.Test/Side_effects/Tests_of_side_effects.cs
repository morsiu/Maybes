using NUnit.Framework;

namespace Mors.Maybes.Test.Side_effects
{
    public sealed class Tests_of_side_effects
    {
        public sealed class Maybe_with_value
        {
            private static Maybe<T> Instance<T>(T x) => new Maybe<T>(x);

            [Test]
            public void MatchVoid_calls_some_function()
            {
                var wasCalled = false;
                Instance(5).MatchVoid(x => { wasCalled = true; }, () => { });
                Assert.That(wasCalled, Is.True);
            }

            [Test]
            public void MatchVoid_passes_value_to_some_function()
            {
                var actualValue = 0;
                Instance(5).MatchVoid(x => { actualValue = x; }, () => { });
                Assert.That(actualValue, Is.EqualTo(5));
            }

            [Test]
            public void MatchVoid_does_not_call_none_function()
            {
                var wasCalled = false;
                Instance(5).MatchVoid(x => { }, () => { wasCalled = true; });
                Assert.That(wasCalled, Is.False);
            }

            [Test]
            public void MatchSome_calls_function()
            {
                var wasCalled = false;
                Instance(5).MatchSome(x => { wasCalled = true; });
                Assert.That(wasCalled, Is.True);
            }

            [Test]
            public void MatchSome_passes_value_to_function()
            {
                var actualValue = 0;
                Instance(5).MatchSome(x => { actualValue = 5; });
                Assert.That(actualValue, Is.EqualTo(5));
            }

            [Test]
            public void MatchNone_does_not_call_function()
            {
                var wasCalled = false;
                Instance(5).MatchNone(() => { wasCalled = true; });
                Assert.That(wasCalled, Is.False);
            }
        }

        public sealed class Maybe_without_value
        {
            private static Maybe<int> Instance() => new Maybe<int>();

            [Test]
            public void MatchVoid_does_not_call_some_function()
            {
                var wasCalled = false;
                Instance().MatchVoid(x => { wasCalled = true; }, () => { });
                Assert.That(wasCalled, Is.False);
            }

            [Test]
            public void MatchVoid_calls_none_function()
            {
                var wasCalled = false;
                Instance().MatchVoid(x => { }, () => { wasCalled = true; });
                Assert.That(wasCalled, Is.True);
            }

            [Test]
            public void MatchSome_does_not_call_function()
            {
                var wasCalled = false;
                Instance().MatchSome(x => { wasCalled = true; });
                Assert.That(wasCalled, Is.False);
            }

            [Test]
            public void MatchNone_calls_function()
            {
                var wasCalled = false;
                Instance().MatchNone(() => { wasCalled = true; });
                Assert.That(wasCalled, Is.True);
            }
        }
    }
}