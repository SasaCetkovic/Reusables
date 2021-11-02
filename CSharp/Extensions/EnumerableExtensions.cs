using System.Linq;

namespace System.Collections.Generic
{
	public static class EnumerableExtensions
	{
		public static IEnumerable<T> ToEnumerable<T>(this T item)
		{
			yield return item;
		}

		public static IEnumerable<T> Concat<T>(this IEnumerable<T> source, T value)
		{
			if (source == null)
			{
				throw new ArgumentNullException(nameof(source));
			}

			foreach (var item in source)
			{
				yield return item;
			}

			if (value != null)
			{
				yield return value;
			}
		}

		public static IEnumerable<T> Concat<T>(this IEnumerable<T> source, IEnumerable<T> value)
		{
			if (source == null)
			{
				throw new ArgumentNullException(nameof(source));
			}

			foreach (T v in source)
			{
				yield return v;
			}

			if (value != null)
			{
				foreach (var item in value)
				{
					yield return item;
				}
			}
		}

		public static bool IsNullOrEmpty<T>(this IEnumerable<T> list)
		{
			if (list == null)
			{
				return true;
			}

			return !list.Any();
		}

		public static IEnumerable<IEnumerable<T>> GetBatches<T>(this IEnumerable<T> source, int batchSize)
        {
            using (var e = source.GetEnumerator())
            {
                while (e.MoveNext())
                {
                    yield return GetBatchElements(e, batchSize - 1);
                }
            }
        }

        private static IEnumerable<T> GetBatchElements<T>(IEnumerator<T> source, int batchSize)
        {
            yield return source.Current;

            for (int i = 0; i < batchSize && source.MoveNext(); i++)
            {
                yield return source.Current;
            }
        }
    }
}
