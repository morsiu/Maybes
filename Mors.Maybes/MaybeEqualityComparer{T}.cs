using System.Collections.Generic;

namespace Mors.Maybes
{
    public readonly struct MaybeEqualityComparer<T> : IEqualityComparer<Maybe<T>>
    {
        private readonly IEqualityComparer<T> _inner;

        public MaybeEqualityComparer(IEqualityComparer<T> inner) => _inner = inner;

        public bool Equals(Maybe<T> x, Maybe<T> y) =>
            _inner != null
                ? x.Equals(y, _inner)
                : x.Equals(y);

        public int GetHashCode(Maybe<T> obj) =>
            _inner != null
                ? obj.GetHashCode(_inner)
                : obj.GetHashCode();
    }
}
