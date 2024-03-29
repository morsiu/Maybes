﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Mors.Maybes
{
    public static partial class MaybeExtensions
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

        public static Maybe<T> NoneWhenDefault<T>(in this Maybe<T> maybe) =>
            maybe.HasValue && EqualityComparer<T>.Default.Equals(maybe.Value, default)
                ? new Maybe<T>()
                : maybe;

        public static Maybe<T> NoneWhenDefault<T>(in this Maybe<T?> maybe)
            where T : struct =>
            maybe.HasValue
                ? maybe.Value == null
                    ? new Maybe<T>()
                    : new Maybe<T>(maybe.Value.Value)
                : new Maybe<T>();

        public static IEnumerable<T> ToEnumerable<T>(in this Maybe<T> maybe) =>
            maybe.HasValue
                ? new[] { maybe.Value }
                : Enumerable.Empty<T>();

        public static T? ToNullable<T>(in this Maybe<T> maybe)
            where T : struct =>
            maybe.HasValue
                ? maybe.Value
                : default(T?);

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
