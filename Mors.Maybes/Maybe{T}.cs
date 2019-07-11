using System;
using System.Collections;
using System.Collections.Generic;

namespace Mors.Maybes
{
    public readonly struct Maybe<T> : IEquatable<Maybe<T>>, IStructuralEquatable
    {
        private readonly T _value;

        public Maybe(in T value)
        {
            HasValue = true;
            _value = value;
        }

        public bool HasValue { get; }
        public bool HasNone => !HasValue;

        public T Value =>
            HasValue
                ? _value
                : throw new InvalidOperationException("The maybe has no value.");

        public bool Contains(in T value) =>
            HasValue && EqualityComparer<T>.Default.Equals(_value, value);

        public bool Contains(in T value, IEqualityComparer<T> comparer) =>
            HasValue && comparer.Equals(_value, value);

        public bool Contains(Predicate<T> predicate) =>
            HasValue && predicate(_value);

        public Maybe<T> Else(in T other) =>
            HasValue
                ? this
                : new Maybe<T>(other);

        public Maybe<T> Else<TU>(in TU other)
            where TU : T =>
            HasValue
                ? this
                : new Maybe<T>(other);

        public Maybe<T> Else(Func<T> other) =>
            HasValue
                ? this
                : new Maybe<T>(other());

        public Maybe<T> Else<TU>(Func<TU> other)
            where TU : T =>
            HasValue
                ? this
                : new Maybe<T>(other());

        public Maybe<T> Else(in Maybe<T> other) =>
            HasValue
                ? this
                : other;

        public Maybe<T> Else<TU>(in Maybe<TU> other)
            where TU : T =>
            HasValue
                ? this
                : other.HasValue
                    ? new Maybe<T>(other.Value)
                    : new Maybe<T>();

        public Maybe<T> Else(Func<Maybe<T>> other) =>
            HasValue
                ? this
                : other();

        public Maybe<T> Else<TU>(Func<Maybe<TU>> other)
            where TU : T
        {
            if (HasValue)
            {
                return this;
            }
            var otherMaybe = other();
            return otherMaybe.HasValue
                ? new Maybe<T>(otherMaybe.Value)
                : new Maybe<T>();
        }

        public Maybe<TU> FlatMap<TU>(Func<T, Maybe<TU>> map) =>
            HasValue
                ? map(_value)
                : new Maybe<TU>();

        public Maybe<TV> FlatMap<TU, TV>(in Maybe<TU> other, Func<T, TU, Maybe<TV>> map) =>
            HasValue && other.HasValue
                ? map(_value, other._value)
                : new Maybe<TV>();

        public Maybe<TU> Map<TU>(Func<T, TU> map) =>
            HasValue
                ? new Maybe<TU>(map(_value))
                : new Maybe<TU>();

        public Maybe<TV> Map<TU, TV>(in Maybe<TU> other, Func<T, TU, TV> map) =>
            HasValue && other.HasValue
                ? new Maybe<TV>(map(_value, other._value))
                : new Maybe<TV>();

        public TU Match<TU>(Func<T, TU> matchSome, Func<TU> matchNone) =>
            HasValue
                ? matchSome(_value)
                : matchNone();

        public TV Match<TU, TV>(
            in Maybe<TU> other,
            Func<T, TU, TV> matchBothSome,
            Func<T, TV> matchFirstSome,
            Func<TU, TV> matchSecondSome,
            Func<TV> matchBothNone) =>
            (HasValue, other.HasValue) switch
            {
                (true, true) => matchBothSome(_value, other._value),
                (true, false) => matchFirstSome(_value),
                (false, true) => matchSecondSome(other._value),
                _ => matchBothNone()
            };

        public void MatchVoid(Action<T> some, Action none)
        {
            if (HasValue)
            {
                some(_value);
            }
            else
            {
                none();
            }
        }

        public void MatchVoid<TU>(
            in Maybe<TU> other,
            Action<T, TU> matchBothSome,
            Action<T> matchFirstSome,
            Action<TU> matchSecondSome,
            Action matchBothNone)
        {
            switch (HasValue, other.HasValue)
            {
                case (true, true):
                    matchBothSome(_value, other._value);
                    break;
                case (true, false):
                    matchFirstSome(_value);
                    break;
                case (false, true):
                    matchSecondSome(other._value);
                    break;
                default:
                    matchBothNone();
                    break;
            }
        }

        public void MatchSome(Action<T> match)
        {
            if (HasValue)
            {
                match(_value);
            }
        }

        public void MatchSome<TU>(in Maybe<TU> other, Action<T, TU> match)
        {
            if (HasValue && other.HasValue)
            {
                match(_value, other._value);
            }
        }

        public void MatchSome<TU>(
            in Maybe<TU> other,
            Action<T, TU> matchBoth,
            Action<T> matchFirst,
            Action<TU> matchSecond)
        {
            switch (HasValue, other.HasValue)
            {
                case (true, true):
                    matchBoth(_value, other._value);
                    break;
                case (true, false):
                    matchFirst(_value);
                    break;
                case (false, true):
                    matchSecond(other._value);
                    break;
            }
        }

        public void MatchNone(Action match)
        {
            if (!HasValue)
            {
                match();
            }
        }

        public void MatchNone<TU>(in Maybe<TU> other, Action match)
        {
            if (!HasValue && !other.HasValue)
            {
                match();
            }
        }

        public Maybe<T> NoneWhen(bool condition) =>
            HasValue && condition
                ? new Maybe<T>()
                : this;

        public Maybe<T> NoneWhen(Predicate<T> predicate) =>
            HasValue && predicate(_value)
                ? new Maybe<T>()
                : this;

        public Maybe<T> SomeWhen(bool condition) =>
            HasValue && condition
                ? this
                : new Maybe<T>();

        public Maybe<T> SomeWhen(Predicate<T> predicate) =>
            HasValue && predicate(_value)
                ? this
                : new Maybe<T>();

        public Maybe<TU> TryCast<TU>()
            where TU : T =>
            HasValue
                ? new Maybe<TU>((TU)_value)
                : new Maybe<TU>();

        public T ValueOr(in T value) =>
            HasValue
                ? _value
                : value;

        public T ValueOr<TU>(in TU value)
            where TU : T =>
            HasValue
                ? _value
                : value;

        public T ValueOr(Func<T> value) =>
            HasValue
                ? _value
                : value();

        public T ValueOr<TU>(Func<TU> value)
            where TU : T =>
            HasValue
                ? _value
                : value();

        public T ValueOrDefault() =>
            HasValue
                ? _value
                : default;

        public static implicit operator Maybe<T>(None _) => new Maybe<T>();

        public static bool operator ==(in Maybe<T> left, in Maybe<T> right) => left.Equals(right);
        public static bool operator !=(in Maybe<T> left, in Maybe<T> right) => !left.Equals(right);

        public bool Equals(Maybe<T> other) =>
            (HasValue == other.HasValue)
            && (!HasValue || EqualityComparer<T>.Default.Equals(_value, other._value));

        public bool Equals(Maybe<T> other, IEqualityComparer<T> comparer) =>
            (HasValue == other.HasValue)
            && (!HasValue || comparer.Equals(_value, other._value));

        public override bool Equals(object obj) =>
            obj is Maybe<T> other && Equals(other);

        public bool Equals(object obj, IEqualityComparer comparer) =>
            obj is Maybe<T> other
            && (HasValue == other.HasValue)
            && (!HasValue || comparer.Equals(_value, other._value));

        private const int NoValueHash = 0;

        public override int GetHashCode() =>
            HasValue
                ? EqualityComparer<T>.Default.GetHashCode(_value)
                : NoValueHash;

        public int GetHashCode(IEqualityComparer<T> comparer) =>
            HasValue
                ? comparer.GetHashCode(_value)
                : NoValueHash;

        public int GetHashCode(IEqualityComparer comparer) =>
            HasValue
                ? comparer.GetHashCode(_value)
                : NoValueHash;

        public override string ToString() =>
            HasValue
                ? _value?.ToString() ?? string.Empty
                : string.Empty;
    }
}
