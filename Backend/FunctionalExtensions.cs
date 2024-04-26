namespace NewsMap;

public static class FunctionalExtensions
{
    public static TOut Apply<TThis, TOut>(this TThis @this, Func<TThis, TOut> func) => func(@this);
}