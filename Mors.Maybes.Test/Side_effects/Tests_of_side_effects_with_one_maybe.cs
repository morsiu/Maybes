using NUnit.Framework;

namespace Mors.Maybes.Test.Side_effects
{
    public sealed class Tests_of_side_effects_with_one_maybe
    {
        public sealed class Maybe_with_value
        {
            private static Maybe<T> Instance<T>(T x) => new Maybe<T>(x);

            [Test]
            public void MatchVoid_calls_some_function()
            {
                Assert.That(
                    a => Instance(5).MatchVoid(x => a.Record(true), () => { }),
                    Is.RecordedValue.True);
            }

            [Test]
            public void MatchVoid_passes_value_to_some_function()
            {
                Assert.That(
                    a => Instance(5).MatchVoid(x => a.Record(x), () => { }),
                    Is.RecordedValue.EqualTo(5));
            }

            [Test]
            public void MatchVoid_does_not_call_none_function()
            {
                Assert.That(
                    a => Instance(5).MatchVoid(x => { }, () => a.Record(true)),
                    Is.RecordedValue.Not.True);
            }

            [Test]
            public void MatchSome_calls_function()
            {
                Assert.That(
                    a => Instance(5).MatchSome(x => a.Record(true)),
                    Is.RecordedValue.True);
            }

            [Test]
            public void MatchSome_passes_value_to_function()
            {
                Assert.That(
                    a => Instance(5).MatchSome(x => a.Record(x)),
                    Is.RecordedValue.EqualTo(5));
            }

            [Test]
            public void MatchNone_does_not_call_function()
            {
                Assert.That(
                    a => Instance(5).MatchNone(() => a.Record(true)),
                    Is.RecordedValue.Not.True);
            }
        }

        public sealed class Maybe_without_value
        {
            private static Maybe<int> Instance() => new Maybe<int>();

            [Test]
            public void MatchVoid_does_not_call_some_function()
            {
                Assert.That(
                    a => Instance().MatchVoid(x => a.Record(true), () => { }),
                    Is.RecordedValue.Not.True);
            }

            [Test]
            public void MatchVoid_calls_none_function()
            {
                Assert.That(
                    a => Instance().MatchVoid(x => { }, () => a.Record(true)),
                    Is.RecordedValue.True);
            }

            [Test]
            public void MatchSome_does_not_call_function()
            {
                Assert.That(
                    a => Instance().MatchSome(x => a.Record(true)),
                    Is.RecordedValue.Not.True);
            }

            [Test]
            public void MatchNone_calls_function()
            {
                Assert.That(
                    a => Instance().MatchNone(() => a.Record(true)),
                    Is.RecordedValue.True);
            }
        }
    }
}