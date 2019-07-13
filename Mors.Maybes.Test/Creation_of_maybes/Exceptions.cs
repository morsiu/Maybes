using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Mors.Maybes.Test.Creation_of_maybes
{
    public static class Exceptions
    {
        public static IEnumerable<TestFixtureData> TestFixtureData()
        {
            yield return Data<InvalidOperationException>(
                "x.SingleOrNone(), x : IEnumerable<T>, x.Count() > 1",
                () => new[] { 1, 2 }.SingleOrNone(),
                "Sequence contains more than one element");
            yield return Data<InvalidOperationException>(
                "x.SingleOrNone(predicate), x : IEnumerable<T>, x.Count(predicate) > 1",
                () => new[] { 1, 2, 3, 4 }.SingleOrNone(x => x % 2 == 0),
                "Sequence contains more than one matching element");

            static TestFixtureData Data<TException>(
                string actionDescription,
                Action action,
                string exceptionMessage)
            {
                return Tests_of_exceptions.TestFixtureData(
                        action,
                        typeof(TException),
                        exceptionMessage)
                    .WithDisplayName(actionDescription);
            }
        }
    }
}