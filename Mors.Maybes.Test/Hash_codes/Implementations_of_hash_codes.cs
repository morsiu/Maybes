using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;

namespace Mors.Maybes.Test.Hash_codes
{
    public static class Implementations_of_hash_codes
    {
        public static IEnumerable<TestFixtureData> TestFixtureData()
        {
            yield return TestFixtureData(new Maybe_GetHashCode());
            yield return TestFixtureData(new Maybe_GetHashCode_with_EqualityComparer());
            yield return TestFixtureData(new Maybe_GetHashCode_with_EqualityComparerOfT());
            yield return TestFixtureData(new Maybe_GetHashCode_with_StructuralEqualityComparer());
            yield return TestFixtureData(new EqualityComparer_Default_GetHashCode());
            yield return TestFixtureData(new MaybeEqualityComparer_GetHashCode());
            yield return TestFixtureData(new MaybeEqualityComparer_with_EqualityComparer_GetHashCode());

            static TestFixtureData TestFixtureData(
                Tests_of_hash_codes.IHashCodeImplementation implementation)
            {
                return Tests_of_hash_codes.TestFixtureData(implementation);
            }
        }

        private sealed class Maybe_GetHashCode : Tests_of_hash_codes.IHashCodeImplementation
        {
            public int Invoke<T>(Maybe<T> maybe) => maybe.GetHashCode();
        }

        private sealed class Maybe_GetHashCode_with_EqualityComparerOfT : Tests_of_hash_codes.IHashCodeImplementation
        {
            public int Invoke<T>(Maybe<T> maybe) => maybe.GetHashCode((IEqualityComparer<T>)EqualityComparer<T>.Default);
        }

        private sealed class Maybe_GetHashCode_with_EqualityComparer : Tests_of_hash_codes.IHashCodeImplementation
        {
            public int Invoke<T>(Maybe<T> maybe) => maybe.GetHashCode((IEqualityComparer)EqualityComparer<T>.Default);
        }

        private sealed class Maybe_GetHashCode_with_StructuralEqualityComparer : Tests_of_hash_codes.IHashCodeImplementation
        {
            public int Invoke<T>(Maybe<T> maybe) => maybe.GetHashCode(StructuralComparisons.StructuralEqualityComparer);
        }

        private sealed class EqualityComparer_Default_GetHashCode : Tests_of_hash_codes.IHashCodeImplementation
        {
            public int Invoke<T>(Maybe<T> maybe) => EqualityComparer<Maybe<T>>.Default.GetHashCode(maybe);
        }

        private sealed class MaybeEqualityComparer_GetHashCode : Tests_of_hash_codes.IHashCodeImplementation
        {
            public int Invoke<T>(Maybe<T> maybe) => new MaybeEqualityComparer<T>().GetHashCode(maybe);
        }

        private sealed class MaybeEqualityComparer_with_EqualityComparer_GetHashCode : Tests_of_hash_codes.IHashCodeImplementation
        {
            public int Invoke<T>(Maybe<T> maybe) => new MaybeEqualityComparer<T>(EqualityComparer<T>.Default).GetHashCode(maybe);
        }
    }
}