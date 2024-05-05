namespace NewsMap;

public static class AsyncEnumerableExtensions
{
    public static async Task<IEnumerable<TOut>> Select<TIn, TOut>(this Task<TIn[]> source, Func<TIn, TOut> selector) =>
        (await source).Select(selector);

    public static async Task<IEnumerable<TOut>> Select<TIn, TOut>(
        this Task<IList<TIn>> source,
        Func<TIn, TOut> selector) =>
        (await source).Select(selector);
}