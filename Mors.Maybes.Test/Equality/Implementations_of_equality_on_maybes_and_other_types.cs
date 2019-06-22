using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;

namespace Mors.Maybes.Test.Equality
{
    public static class Implementations_of_equality_on_maybes_and_other_types
    {
        public static IEnumerable<TestFixtureData> TestFixtureData()
        {
            yield return TestFixtureData(
                "object.Equals(object)",
                (x, y) => x.Equals(y));
            yield return TestFixtureData(
                "StructuralComparisons.StructuralEqualityComparer.Equals(object, object, IEqualityComparer)",
                (x, y) => StructuralComparisons.StructuralEqualityComparer.Equals(x, y));

            TestFixtureData TestFixtureData(
                string equalsDescription,
                Func<object, object, bool> equals)
            {
                return Tests_of_equality_on_maybes_and_other_values
                    .TestFixtureData(equals)
                    .SetArgDisplayNames(equalsDescription);
            }
        }
    }
}
