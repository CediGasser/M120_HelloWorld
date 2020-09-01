using System.Collections.Generic;

namespace Hello_World.Core
{
    public static class LongerListZipperExtension
    {
        public static IEnumerable<(TFirst, TSecond)> LongerListZip<TFirst, TSecond>(this IEnumerable<TFirst> first, IEnumerable<TSecond> second)
        {
            using IEnumerator<TSecond> e2 = second.GetEnumerator();
            using IEnumerator<TFirst> e1 = first.GetEnumerator();
            while (e1.MoveNext())
            {
                yield return e2.MoveNext()
                    ? (e1.Current, e2.Current)
                    : (e1.Current, default);
            }

            while (e2.MoveNext()) yield return (default, e2.Current);
        }
    }
}