namespace Mors.Maybes
{
    public static class Maybe
    {
        public static Maybe<T> Some<T>(in T value) => new Maybe<T>(value);
        public static Maybe<T> None<T>() => new Maybe<T>();
        public static None None() => new None();
    }
}
