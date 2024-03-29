﻿using System.Collections.Generic;

namespace Mors.Maybes
{
    public static partial class MaybeExtensions
    {
        public static Maybe<TValue> GetOrNone<TKey, TValue>(
            this IReadOnlyDictionary<TKey, TValue> dictionary, in TKey key) =>
            dictionary.TryGetValue(key, out var value)
                ? new Maybe<TValue>(value)
                : new Maybe<TValue>();
    }
}