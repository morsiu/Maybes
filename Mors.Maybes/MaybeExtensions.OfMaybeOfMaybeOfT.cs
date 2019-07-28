namespace Mors.Maybes
{
    public static partial class MaybeExtensions
    {
        public static Maybe<T> Flatten<T>(in this Maybe<Maybe<T>> maybe) =>
            maybe.HasValue
                ? maybe.Value
                : new Maybe<T>();
    }
}