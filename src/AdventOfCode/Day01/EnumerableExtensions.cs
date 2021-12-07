using System;
using System.Collections.Generic;

namespace AdventOfCode.Day01
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<IList<TSource>> Window<TSource>(this IEnumerable<TSource> source, int size)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            if (size <= 0)
                throw new ArgumentOutOfRangeException(nameof(size));

            return _();

            IEnumerable<IList<TSource>> _()
            {
                using var iter = source.GetEnumerator();

                // generate the first window of items
                var window = new TSource[size];
                int i;
                for (i = 0; i < size && iter.MoveNext(); i++)
                    window[i] = iter.Current;

                if (i < size)
                    yield break;

                while (iter.MoveNext())
                {
                    // generate the next window by shifting forward by one item
                    // and do that before exposing the data
                    var newWindow = new TSource[size];
                    Array.Copy(window, 1, newWindow, 0, size - 1);
                    newWindow[size - 1] = iter.Current;

                    yield return window;
                    window = newWindow;
                }

                // return the last window.
                yield return window;
            }
        }
    }
}