using NUnit.Framework;

namespace Mors.Maybes.Test.Manipulation_of_values
{
    public sealed class Tests_of_manipulating_values
    {
        public sealed class Maybe_with_stored_value
        {
            private static Maybe<int> Instance() => new Maybe<int>();
            private static Maybe<T> Instance<T>(T x) => new Maybe<T>(x);

            [Test]
            public void FlatMap_passes_stored_value_to_function()
            {
                Assert.That(
                    a => Instance(2).FlatMap(x => a.Record(x).Return(Instance())),
                    Is.RecordedValue.EqualTo(2));
            }

            [Test]
            public void FlatMap_with_function_returning_maybe_with_value_returns_maybe_with_that_value()
            {
                Assert.That(
                    Instance(2).FlatMap(x => Instance("1")),
                    Is.EqualTo(Instance("1")));
            }

            [Test]
            public void Map_passes_stored_value_to_function()
            {
                Assert.That(
                    a => Instance(2).Map(x => a.Record(x).Return(5)),
                    Is.RecordedValue.EqualTo(2));
            }

            [Test]
            public void Map_with_function_returning_value_returns_maybe_with_that_value()
            {
                Assert.That(
                    Instance(2).Map(x => "1"),
                    Is.EqualTo(Instance("1")));
            }

            [Test]
            public void Match_passes_stored_value_to_function()
            {
                Assert.That(
                    a => Instance(2).Match(x => a.Record(x).Return(3), () => 4),
                    Is.RecordedValue.EqualTo(2));
            }

            [Test]
            public void Match_with_functions_returns_value_returned_by_some_function()
            {
                Assert.That(
                    Instance(3).Match(x => "1", () => "2"),
                    Is.EqualTo("1"));
            }
        }

        public sealed class Maybe_without_value
        {
            private static Maybe<int> Instance() => new Maybe<int>();
            private static Maybe<T> Instance<T>() => new Maybe<T>();
            private static Maybe<T> Instance<T>(T x) => new Maybe<T>(x);

            [Test]
            public void FlatMap_with_function_returning_maybe_with_value_returns_maybe_without_value_of_that_type()
            {
                Assert.That(
                    Instance().FlatMap(x => Instance("1")),
                    Is.EqualTo(Instance<string>()));
            }

            [Test]
            public void Map_with_function_returning_value_returns_maybe_without_value_of_that_type()
            {
                Assert.That(
                    Instance().Map(x => "1"),
                    Is.EqualTo(Instance<string>()));
            }

            [Test]
            public void Match_with_functions_returns_value_returned_by_none_function()
            {
                Assert.That(
                    Instance().Match(x => "1", () => "2"),
                    Is.EqualTo("2"));

            }
        }
    }
}
