using System.Collections.Generic;

namespace Hello_World.Core.Test
{
    public static class LongerListZipperExtension
    {
        public static IEnumerable<(TFirst, TSecond)> LongerListZip<TFirst, TSecond>(this IEnumerable<TFirst> first, IEnumerable<TSecond> second)
        {
            using IEnumerator<TFirst> e1 = first.GetEnumerator();
            using IEnumerator<TSecond> e2 = second.GetEnumerator();
            while (e1.MoveNext())
            {
                if (e2.MoveNext())
                {
                    yield return (e1.Current, e2.Current);
                }
                else
                {
                    yield return (e1.Current, default);
                }

            }

            while (e2.MoveNext())
            {
                yield return (default, e2.Current);
            }
        }
    }
}