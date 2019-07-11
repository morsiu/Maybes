using NUnit.Framework;

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
            public void NoneWhen_with_false_returns_maybe_with_stored_value()
            {
                Assert.That(
                    Instance(1).NoneWhen(false),
                    Is.EqualTo(Instance(1)));
            }

            [Test]
            public void NoneWhen_with_true_returns_maybe_without_value()
            {
                Assert.That(
                    Instance(1).NoneWhen(true),
                    Is.EqualTo(Instance()));
            }

            [Test]
            public void NoneWhen_with_predicate_passes_stored_value_to_predicate()
            {
                Assert.That(
                    a => Instance(2).NoneWhen(x => a.Record(x).Return(true)),
                    Is.RecordedValue.EqualTo(2));
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
            public void NoneWhenDefault_with_null_of_class_type_returns_maybe_without_value()
            {
                Assert.That(
                    Instance(default(string)).NoneWhenDefault(),
                    Is.EqualTo(Instance<string>()));
            }

            [Test]
            public void NoneWhenDefault_with_null_of_nullable_type_returns_maybe_without_value()
            {
                Assert.That(
                    Instance(default(int?)).NoneWhenDefault(),
                    Is.EqualTo(Instance<int>()));
            }

            [Test]
            public void NoneWhenDefault_with_default_value_of_struct_type_returns_maybe_without_value()
            {
                Assert.That(
                    Instance(default(float)).NoneWhenDefault(),
                    Is.EqualTo(Instance<float>()));
            }

            [Test]
            public void NoneWhenDefault_with_non_null_value_of_class_type_returns_maybe_with_the_value()
            {
                Assert.That(
                    Instance("a").NoneWhenDefault(),
                    Is.EqualTo(Instance("a")));
            }

            [Test]
            public void NoneWhenDefault_with_non_null_value_of_nullable_type_returns_maybe_with_the_value()
            {
                Assert.That(
                    Instance<int?>(5).NoneWhenDefault(),
                    Is.EqualTo(Instance(5)));
            }

            [Test]
            public void NoneWhenDefault_with_non_default_value_of_struct_type_returns_maybe_with_the_value()
            {
                Assert.That(
                    Instance(4f).NoneWhenDefault(),
                    Is.EqualTo(Instance(4f)));
            }

            [Test]
            public void SomeWhen_with_false_returns_maybe_without_value()
            {
                Assert.That(
                    Instance(1).SomeWhen(false),
                    Is.EqualTo(Instance()));
            }

            [Test]
            public void SomeWhen_with_true_returns_maybe_with_stored_value()
            {
                Assert.That(
                    Instance(1).SomeWhen(true),
                    Is.EqualTo(Instance(1)));
            }

            [Test]
            public void SomeWhen_with_predicate_passes_stored_value_to_predicate()
            {
                Assert.That(
                    a => Instance(2).SomeWhen(x => a.Record(x).Return(true)),
                    Is.RecordedValue.EqualTo(2));
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
            public void NoneWhen_with_false_returns_maybe_without_value()
            {
                Assert.That(
                    Instance().NoneWhen(false),
                    Is.EqualTo(Instance()));
            }

            [Test]
            public void NoneWhen_with_true_returns_maybe_without_value()
            {
                Assert.That(
                    Instance().NoneWhen(true),
                    Is.EqualTo(Instance()));
            }

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
            public void SomeWhen_with_false_returns_maybe_without_value()
            {
                Assert.That(
                    Instance().SomeWhen( false),
                    Is.EqualTo(Instance()));
            }

            [Test]
            public void SomeWhen_with_true_returns_maybe_without_value()
            {
                Assert.That(
                    Instance().SomeWhen(true),
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