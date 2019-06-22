namespace Mors.Maybes
{
    public static class ExtensionsOfObject
    {
        public static Maybe<T> TryCast<T>(this object value) =>
            value is T x
                ? new Maybe<T>(x)
                : new Maybe<T>();
    }
}
