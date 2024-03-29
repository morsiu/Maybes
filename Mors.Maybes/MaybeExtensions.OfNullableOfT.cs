﻿namespace Mors.Maybes
{
    public static partial class MaybeExtensions
    {
        public static Maybe<T> SomeNotNull<T>(in this T? value)
            where T : struct =>
            value.HasValue
                ? new Maybe<T>(value.Value)
                : new Maybe<T>();
    }
}
