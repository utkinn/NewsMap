namespace NewsMap.Controllers;

public static class AsyncEnumerableExtensions
{
	public static async Task<IEnumerable<TOut>> Select<TIn, TOut>(this Task<TIn[]> source, Func<TIn, TOut> selector) =>
		(await source).Select(selector);
}