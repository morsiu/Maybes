using System;
using System.Collections.Generic;

namespace Mors.Maybes
{
    public static partial class MaybeExtensions
    {
        public static Maybe<T> NoneWhen<T>(this T value, bool condition) =>
            condition
                ? new Maybe<T>()
                : new Maybe<T>(value);

        public static Maybe<T> NoneWhen<T>(this T value, Func<bool> condition) =>
            condition()
                ? new Maybe<T>()
                : new Maybe<T>(value);

        public static Maybe<T> NoneWhen<T>(this T value, Func<T, bool> condition) =>
            condition(value)
                ? new Maybe<T>()
                : new Maybe<T>(value);

        public static Maybe<T> Some<T>(this T value) =>
            new Maybe<T>(value);

        public static Maybe<T> SomeNotNull<T>(this T value)
            where T : class => 
            value != null
                ? new Maybe<T>(value)
                : new Maybe<T>();

        public static Maybe<T> SomeNotDefault<T>(this T value) =>
            EqualityComparer<T>.Default.Equals(value, default)
                ? new Maybe<T>()
                : new Maybe<T>(value);

        public static Maybe<T> SomeWhen<T>(this T value, bool condition) =>
            condition
                ? new Maybe<T>(value)
                : new Maybe<T>();

        public static Maybe<T> SomeWhen<T>(this T value, Func<bool> predicate) =>
            predicate()
                ? new Maybe<T>(value)
                : new Maybe<T>();

        public static Maybe<T> SomeWhen<T>(this T value, Func<T, bool> predicate) =>
            predicate(value)
                ? new Maybe<T>(value)
                : new Maybe<T>();
    }
}
