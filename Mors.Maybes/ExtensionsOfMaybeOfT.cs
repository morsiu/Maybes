using System;

namespace Mors.Maybes
{
    public static class ExtensionsOfMaybeOfT
    {
        public static Maybe<TU> Cast<T, TU>(in this Maybe<T> maybe)
            where T : TU =>
            maybe.HasValue
                ? new Maybe<TU>(maybe.Value)
                : new Maybe<TU>();

        public static Maybe<TU> Else<T, TU>(in this Maybe<T> maybe, in TU other)
            where T : TU =>
            maybe.HasValue
                ? new Maybe<TU>(maybe.Value)
                : new Maybe<TU>(other);

        public static Maybe<TU> Else<T, TU>(in this Maybe<T> maybe, Func<TU> other)
            where T : TU =>
            maybe.HasValue
                ? new Maybe<TU>(maybe.Value)
                : new Maybe<TU>(other());

        public static Maybe<TU> Else<T, TU>(in this Maybe<T> maybe, in Maybe<TU> other)
            where T : TU =>
            maybe.HasValue
                ? new Maybe<TU>(maybe.Value)
                : other;

        public static Maybe<TU> Else<T, TU>(in this Maybe<T> maybe, Func<Maybe<TU>> other)
            where T : TU =>
            maybe.HasValue
                ? new Maybe<TU>(maybe.Value)
                : other();

        public static TU ValueOr<T, TU>(in this Maybe<T> maybe, in TU value)
            where T : TU =>
            maybe.HasValue
                ? maybe.Value
                : value;

        public static TU ValueOr<T, TU>(in this Maybe<T> maybe, Func<TU> value)
            where T : TU =>
            maybe.HasValue
                ? maybe.Value
                : value();
    }
}
