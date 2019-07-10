using NUnit.Framework;

namespace Mors.Maybes.Test.Manipulation_of_values
{
    public static class Tests_of_manipulating_two_values
    {
        private static Maybe<int> Instance() => new Maybe<int>();
        private static Maybe<T> Instance<T>() => new Maybe<T>();
        private static Maybe<T> Instance<T>(T x) => new Maybe<T>(x);

        public static class Two_maybes_with_stored_values
        {
            [Test]
            public static void FlatMap_passes_first_stored_value_to_function()
            {
                Assert.That(
                    a => Instance(1).FlatMap(Instance(2f), (x, y) => a.Record(x).Return(Instance())),
                    Is.RecordedValue.EqualTo(1));
            }

            [Test]
            public static void FlatMap_passes_second_stored_value_to_function()
            {
                Assert.That(
                    a => Instance(1).FlatMap(Instance(2f), (x, y) => a.Record(y).Return(Instance())),
                    Is.RecordedValue.EqualTo(2f));
            }

            [Test]
            public static void FlatMap_returns_value_returned_from_function()
            {
                Assert.That(
                    Instance(1).FlatMap(Instance(2f), (x, y) => Instance("3")),
                    Is.EqualTo(Instance("3")));
            }

            [Test]
            public static void Map_passes_first_stored_value_to_function()
            {
                Assert.That(
                    a => Instance(1).Map(Instance(2f), (x, y) => a.Record(x).Return("a")),
                    Is.RecordedValue.EqualTo(1));
            }

            [Test]
            public static void Map_passes_second_stored_value_to_function()
            {
                Assert.That(
                    a => Instance(1).Map(Instance(2f), (x, y) => a.Record(y).Return("a")),
                    Is.RecordedValue.EqualTo(2f));
            }

            [Test]
            public static void Map_returns_maybe_with_value_returned_from_function()
            {
                Assert.That(
                    Instance(1).Map(Instance(2f), (x, y) => "3"),
                    Is.EqualTo(Instance("3")));
            }

            [Test]
            public static void Match_passes_first_stored_value_to_first_function()
            {
                Assert.That(
                    a => Instance(1).Match(Instance(2f), (x, y) => a.Record(x).Return("a"), x => "b", x => "c", () => "d"),
                    Is.RecordedValue.EqualTo(1));
            }

            [Test]
            public static void Match_passes_second_stored_value_to_first_function()
            {
                Assert.That(
                    a => Instance(1).Match(Instance(2f), (x, y) => a.Record(y).Return("a"), x => "b", x => "c", () => "d"),
                    Is.RecordedValue.EqualTo(2f));
            }

            [Test]
            public static void Match_returns_value_from_first_function()
            {
                Assert.That(
                    Instance(1).Match(Instance(2f), (x, y) => "a", x => "b", y => "c", () => "d"),
                    Is.EqualTo("a"));
            }
        }

        public static class Two_maybes_without_stored_values
        {
            [Test]
            public static void FlatMap_returns_maybe_without_value()
            {
                Assert.That(
                    Instance().FlatMap(Instance<float>(), (x, y) => Instance("a")),
                    Is.EqualTo(Instance<string>()));
            }

            [Test]
            public static void Map_returns_maybe_without_value()
            {
                Assert.That(
                    Instance().Map(Instance<float>(), (x, y) => "a"),
                    Is.EqualTo(Instance<string>()));
            }

            [Test]
            public static void Match_returns_value_from_fourth_function()
            {
                Assert.That(
                    Instance().Match(Instance<float>(), (x, y) => "a", x => "b", y => "c", () => "d"),
                    Is.EqualTo("d"));
            }
        }

        public static class Two_maybes_where_first_has_value
        {
            [Test]
            public static void FlatMap_returns_maybe()
            {
                Assert.That(
                    Instance(1).FlatMap(Instance<float>(), (x, y) => Instance("a")),
                    Is.EqualTo(Instance<string>()));
            }

            [Test]
            public static void Map_returns_maybe_without_value()
            {
                Assert.That(
                    Instance(1).Map(Instance<float>(), (x, y) => "a"),
                    Is.EqualTo(Instance<string>()));
            }

            [Test]
            public static void Match_passes_first_stored_value_to_second_function()
            {
                Assert.That(
                    a => Instance(1).Match(Instance<float>(), (x, y) => "a", x => a.Record(x).Return("b"), x => "c", () => "d"),
                    Is.RecordedValue.EqualTo(1));
            }

            [Test]
            public static void Match_returns_value_from_second_function()
            {
                Assert.That(
                    Instance(1).Match(Instance<float>(), (x, y) => "a", x => "b", x => "c", () => "d"),
                    Is.EqualTo("b"));
            }
        }

        public static class Two_maybes_where_second_has_value
        {
            [Test]
            public static void FlatMap_returns_maybe_without_value()
            {
                Assert.That(
                    Instance().FlatMap(Instance(2f), (x, y) => Instance("a")),
                    Is.EqualTo(Instance<string>()));
            }

            [Test]
            public static void Map_returns_maybe_without_value()
            {
                Assert.That(
                    Instance().Map(Instance(2f), (x, y) => "a"),
                    Is.EqualTo(Instance<string>()));
            }

            [Test]
            public static void Match_passes_second_stored_value_to_third_function()
            {
                Assert.That(
                    a => Instance().Match(Instance(2f), (x, y) => "a", x => "b", x => a.Record(x).Return("c"), () => "d"),
                    Is.RecordedValue.EqualTo(2f));
            }

            [Test]
            public static void Match_returns_value_from_third_function()
            {
                Assert.That(
                    Instance().Match(Instance(2f), (x, y) => "a", x => "b", x => "c", () => "d"),
                    Is.EqualTo("c"));
            }
        }
    }
}
