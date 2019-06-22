﻿using NUnit.Framework;

namespace Mors.Maybes.Test.Manipulation_of_values
{
    public class Tests_of_swapping_values
    {
        public sealed class Maybe_with_stored_value
        {
            private static Maybe<int> Instance() => new Maybe<int>();
            private static Maybe<T> Instance<T>() => new Maybe<T>();
            private static Maybe<T> Instance<T>(T x) => new Maybe<T>(x);

            [Test]
            public void NoneWhen_passes_stored_value_to_predicate()
            {
                var actualValue = 1;
                var _ = Instance(2).NoneWhen(x => { actualValue = x; return true; });
                Assert.That(actualValue, Is.EqualTo(2));
            }

            [Test]
            public void NoneWhen_with_predicate_returning_false_returns_maybe_with_stored_value()
            {
                Assert.That(
                    Instance(1).NoneWhen(x => false),
                    Is.EqualTo(Instance(1)));
            }

            [Test]
            public void NoneWhen_with_predicate_returning_true_returns_maybe_without_value()
            {
                Assert.That(
                    Instance(1).NoneWhen(x => true),
                    Is.EqualTo(Instance()));
            }

            [Test]
            public void SomeWhen_passes_stored_value_to_predicate()
            {
                var actualValue = 1;
                var _ = Instance(2).SomeWhen(x => { actualValue = x; return true; });
                Assert.That(actualValue, Is.EqualTo(2));
            }

            [Test]
            public void SomeWhen_with_predicate_returning_false_returns_maybe_without_value()
            {
                Assert.That(
                    Instance(1).SomeWhen(x => false),
                    Is.EqualTo(Instance()));
            }

            [Test]
            public void SomeWhen_with_predicate_returning_true_returns_maybe_with_stored_value()
            {
                Assert.That(
                    Instance(1).SomeWhen(x => true),
                    Is.EqualTo(Instance(1)));
            }
        }

        public sealed class Maybe_without_value
        {
            private static Maybe<int> Instance() => new Maybe<int>();
            [Test]
            public void NoneWhen_with_predicate_returning_false_returns_maybe_without_value()
            {
                Assert.That(
                    Instance().NoneWhen(x => false),
                    Is.EqualTo(Instance()));
            }

            [Test]
            public void NoneWhen_with_predicate_returning_true_returns_maybe_without_value()
            {
                Assert.That(
                    Instance().NoneWhen(x => true),
                    Is.EqualTo(Instance()));
            }

            [Test]
            public void SomeWhen_with_predicate_returning_false_returns_maybe_without_value()
            {
                Assert.That(
                    Instance().SomeWhen(x => false),
                    Is.EqualTo(Instance()));
            }

            [Test]
            public void SomeWhen_with_predicate_returning_true_returns_maybe_without_value()
            {
                Assert.That(
                    Instance().SomeWhen(x => true),
                    Is.EqualTo(Instance()));
            }
        }
    }
}