using NUnit.Framework;

namespace Mors.Maybes.Test.Side_effects
{
    public sealed class Tests_of_side_effects_with_two_maybes
    {
        private static Maybe<T> Instance<T>(T x) => new Maybe<T>(x);
        private static Maybe<int> Instance() => new Maybe<int>();
        private static Maybe<T> Instance<T>() => new Maybe<T>();

        public sealed class Two_maybes_with_values
        {
            [Test]
            public void MatchVoid_passes_first_value_to_first_function()
            {
                Assert.That(
                    a => Instance(1).MatchVoid(Instance(2f), (x, y) => a.Record(x), x => { }, x => { }, () => { }),
                    Is.RecordedValue.EqualTo(1));
            }

            [Test]
            public void MatchVoid_passes_second_value_to_first_function()
            {
                Assert.That(
                    a => Instance(1).MatchVoid(Instance(2f), (x, y) => a.Record(y), x => { }, x => { }, () => { }),
                    Is.RecordedValue.EqualTo(2f));
            }

            [Test]
            public void MatchVoid_calls_first_function()
            {
                Assert.That(
                    a => Instance(1).MatchVoid(Instance(2f), (x, y) => a.Record(true), x => { }, x => { }, () => { }),
                    Is.RecordedValue.True);
            }

            [Test]
            public void MatchVoid_does_not_call_second_function()
            {
                Assert.That(
                    a => Instance(1).MatchVoid(Instance(2f), (x, y) => { }, x => a.Record(true), x => { }, () => { }),
                    Is.RecordedValue.Not.True);
            }

            [Test]
            public void MatchVoid_does_not_call_third_function()
            {
                Assert.That(
                    a => Instance(1).MatchVoid(Instance(2f), (x, y) => { }, x => { }, x => a.Record(true), () => { }),
                    Is.RecordedValue.Not.True);
            }

            [Test]
            public void MatchVoid_does_not_call_fourth_function()
            {
                Assert.That(
                    a => Instance(1).MatchVoid(Instance(2f), (x, y) => { }, x => { }, x => { }, () => a.Record(true)),
                    Is.RecordedValue.Not.True);
            }

            [Test]
            public void MatchSome_with_one_function_calls_that_function()
            {
                Assert.That(
                    a => Instance(1).MatchSome(Instance(2f), (x, y) => a.Record(true)),
                    Is.RecordedValue.True);
            }

            [Test]
            public void MatchSome_with_one_function_passes_first_value_to_that_function()
            {
                Assert.That(
                    a => Instance(1).MatchSome(Instance(2f), (x, y) => a.Record(x)),
                    Is.RecordedValue.EqualTo(1));
            }

            [Test]
            public void MatchSome_with_one_function_passes_second_value_to_that_function()
            {
                Assert.That(
                    a => Instance(1).MatchSome(Instance(2f), (x, y) => a.Record(y)),
                    Is.RecordedValue.EqualTo(2f));
            }

            [Test]
            public void MatchSome_with_three_functions_calls_first_function()
            {
                Assert.That(
                    a => Instance(1).MatchSome(Instance(2f), (x, y) => a.Record(true), x => { }, x => { }),
                    Is.RecordedValue.True);
            }

            [Test]
            public void MatchSome_with_three_functions_does_not_call_second_function()
            {
                Assert.That(
                    a => Instance(1).MatchSome(Instance(2f), (x, y) => { }, x => a.Record(true), x => { }),
                    Is.RecordedValue.Not.True);
            }

            [Test]
            public void MatchSome_with_three_functions_does_not_call_third_function()
            {
                Assert.That(
                    a => Instance(1).MatchSome(Instance(2f), (x, y) => { }, x => { }, x => a.Record(true)),
                    Is.RecordedValue.Not.True);
            }

            [Test]
            public void MatchSome_with_three_functions_passes_first_value_to_first_function()
            {
                Assert.That(
                    a => Instance(1).MatchSome(Instance(2f), (x, y) => a.Record(x), x => { }, x => { }),
                    Is.RecordedValue.EqualTo(1));
            }

            [Test]
            public void MatchSome_with_three_functions_passes_second_value_to_first_function()
            {
                Assert.That(
                    a => Instance(1).MatchSome(Instance(2f), (x, y) => a.Record(y), x => { }, x => { }),
                    Is.RecordedValue.EqualTo(2f));
            }

            [Test]
            public void MatchNone_does_not_call_function()
            {
                Assert.That(
                    a => Instance(1).MatchNone(Instance(2f), () => a.Record(true)),
                    Is.RecordedValue.Not.True);
            }
        }

        public sealed class Two_maybes_where_first_has_value
        {
            [Test]
            public void MatchVoid_passes_first_value_to_second_function()
            {
                Assert.That(
                    a => Instance(1).MatchVoid(Instance<float>(), (x, y) => { }, x => a.Record(x), x => { }, () => { }),
                    Is.RecordedValue.EqualTo(1));
            }

            [Test]
            public void MatchVoid_calls_second_function()
            {
                Assert.That(
                    a => Instance(1).MatchVoid(Instance<float>(), (x, y) => { }, x => a.Record(true), x => { }, () => { }),
                    Is.RecordedValue.True);
            }

            [Test]
            public void MatchVoid_does_not_call_first_function()
            {
                Assert.That(
                    a => Instance(1).MatchVoid(Instance<float>(), (x, y) => a.Record(true), x => { }, x => { }, () => { }),
                    Is.RecordedValue.Not.True);
            }

            [Test]
            public void MatchVoid_does_not_call_third_function()
            {
                Assert.That(
                    a => Instance(1).MatchVoid(Instance<float>(), (x, y) => { }, x => { }, x => a.Record(true), () => { }),
                    Is.RecordedValue.Not.True);
            }

            [Test]
            public void MatchVoid_does_not_call_fourth_function()
            {
                Assert.That(
                    a => Instance(1).MatchVoid(Instance<float>(), (x, y) => { }, x => { }, x => { }, () => a.Record(true)),
                    Is.RecordedValue.Not.True);
            }

            [Test]
            public void MatchSome_with_one_function_does_not_call_that_function()
            {
                Assert.That(
                    a => Instance(1).MatchSome(Instance<float>(), (x, y) => a.Record(true)),
                    Is.RecordedValue.Not.True);
            }

            [Test]
            public void MatchSome_with_three_functions_calls_second_function()
            {
                Assert.That(
                    a => Instance(1).MatchSome(Instance<float>(), (x, y) => { }, x => a.Record(true), x => { }),
                    Is.RecordedValue.True);
            }

            [Test]
            public void MatchSome_with_three_functions_does_not_call_first_function()
            {
                Assert.That(
                    a => Instance(1).MatchSome(Instance<float>(), (x, y) => a.Record(true), x => { }, x => { }),
                    Is.RecordedValue.Not.True);
            }

            [Test]
            public void MatchSome_with_three_functions_does_not_call_third_function()
            {
                Assert.That(
                    a => Instance(1).MatchSome(Instance<float>(), (x, y) => { }, x => { }, x => a.Record(true)),
                    Is.RecordedValue.Not.True);
            }

            [Test]
            public void MatchSome_with_three_functions_passes_first_value_to_second_function()
            {
                Assert.That(
                    a => Instance(1).MatchSome(Instance<float>(), (x, y) => { }, x => a.Record(x), x => { }),
                    Is.RecordedValue.EqualTo(1));
            }

            [Test]
            public void MatchNone_does_not_call_function()
            {
                Assert.That(
                    a => Instance(1).MatchNone(Instance<float>(), () => a.Record(true)),
                    Is.RecordedValue.Not.True);
            }
        }

        public sealed class Two_maybes_where_second_has_value
        {
            [Test]
            public void MatchVoid_passes_second_value_to_third_function()
            {
                Assert.That(
                    a => Instance().MatchVoid(Instance(2f), (x, y) => { }, x => { }, x => a.Record(x), () => { }),
                    Is.RecordedValue.EqualTo(2));
            }

            [Test]
            public void MatchVoid_calls_third_function()
            {
                Assert.That(
                    a => Instance().MatchVoid(Instance(2f), (x, y) => { }, x => { }, x => a.Record(true), () => { }),
                    Is.RecordedValue.True);
            }

            [Test]
            public void MatchVoid_does_not_call_first_function()
            {
                Assert.That(
                    a => Instance().MatchVoid(Instance(2f), (x, y) => a.Record(true), x => { }, x => { }, () => { }),
                    Is.RecordedValue.Not.True);
            }

            [Test]
            public void MatchVoid_does_not_call_second_function()
            {
                Assert.That(
                    a => Instance().MatchVoid(Instance(2f), (x, y) => { }, x => a.Record(true), x => { }, () => { }),
                    Is.RecordedValue.Not.True);
            }

            [Test]
            public void MatchVoid_does_not_call_fourth_function()
            {
                Assert.That(
                    a => Instance().MatchVoid(Instance(2f), (x, y) => { }, x => { }, x => { }, () => a.Record(true)),
                    Is.RecordedValue.Not.True);
            }

            [Test]
            public void MatchSome_with_one_function_does_not_call_that_function()
            {
                Assert.That(
                    a => Instance().MatchSome(Instance(2f), (x, y) => a.Record(true)),
                    Is.RecordedValue.Not.True);
            }

            [Test]
            public void MatchSome_with_three_functions_calls_third_function()
            {
                Assert.That(
                    a => Instance().MatchSome(Instance(2f), (x, y) => { }, x => { }, x => a.Record(true)),
                    Is.RecordedValue.True);
            }

            [Test]
            public void MatchSome_with_three_functions_does_not_call_first_function()
            {
                Assert.That(
                    a => Instance().MatchSome(Instance(2f), (x, y) => a.Record(true), x => { }, x => { }),
                    Is.RecordedValue.Not.True);
            }

            [Test]
            public void MatchSome_with_three_functions_does_not_call_second_function()
            {
                Assert.That(
                    a => Instance().MatchSome(Instance(2f), (x, y) => { }, x => a.Record(true), x => { }),
                    Is.RecordedValue.Not.True);
            }

            [Test]
            public void MatchSome_with_three_functions_passes_second_value_to_third_function()
            {
                Assert.That(
                    a => Instance().MatchSome(Instance(2f), (x, y) => { }, x => { }, x => a.Record(x)),
                    Is.RecordedValue.EqualTo(2));
            }

            [Test]
            public void MatchNone_does_not_call_function()
            {
                Assert.That(
                    a => Instance().MatchNone(Instance(2f), () => a.Record(true)),
                    Is.RecordedValue.Not.True);
            }
        }

        public sealed class Two_maybes_without_value
        {
            [Test]
            public void MatchVoid_calls_fourth_function()
            {
                Assert.That(
                    a => Instance().MatchVoid(Instance<float>(), (x, y) => { }, x => { }, x => { }, () => a.Record(true)),
                    Is.RecordedValue.True);
            }

            [Test]
            public void MatchVoid_does_not_call_first_function()
            {
                Assert.That(
                    a => Instance().MatchVoid(Instance<float>(), (x, y) => a.Record(true), x => { }, x => { }, () => { }),
                    Is.RecordedValue.Not.True);
            }

            [Test]
            public void MatchVoid_does_not_call_second_function()
            {
                Assert.That(
                    a => Instance().MatchVoid(Instance<float>(), (x, y) => { }, x => a.Record(true), x => { }, () => { }),
                    Is.RecordedValue.Not.True);
            }

            [Test]
            public void MatchVoid_does_not_call_third_function()
            {
                Assert.That(
                    a => Instance().MatchVoid(Instance<float>(), (x, y) => { }, x => { }, x => a.Record(true), () => { }),
                    Is.RecordedValue.Not.True);
            }

            [Test]
            public void MatchSome_with_one_function_does_not_call_that_function()
            {
                Assert.That(
                    a => Instance().MatchSome(Instance<float>(), (x, y) => a.Record(true)),
                    Is.RecordedValue.Not.True);
            }

            [Test]
            public void MatchSome_with_three_functions_does_not_call_first_function()
            {
                Assert.That(
                    a => Instance().MatchSome(Instance<float>(), (x, y) => a.Record(true), x => { }, x => { }),
                    Is.RecordedValue.Not.True);
            }

            [Test]
            public void MatchSome_with_three_functions_does_not_call_second_function()
            {
                Assert.That(
                    a => Instance().MatchSome(Instance<float>(), (x, y) => { }, x => a.Record(true), x => { }),
                    Is.RecordedValue.Not.True);
            }

            [Test]
            public void MatchSome_with_three_functions_does_not_call_third_function()
            {
                Assert.That(
                    a => Instance().MatchSome(Instance<float>(), (x, y) => { }, x => { }, x => a.Record(true)),
                    Is.RecordedValue.Not.True);
            }

            [Test]
            public void MatchNone_calls_function()
            {
                Assert.That(
                    a => Instance().MatchNone(Instance<float>(), () => a.Record(true)),
                    Is.RecordedValue.True);
            }
        }
    }
}