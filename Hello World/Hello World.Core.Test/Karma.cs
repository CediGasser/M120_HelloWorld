using System.Collections.Generic;
using System.Linq;

namespace Hello_World.Core.Test
{
    public class Karma
    {
        private const long Base = 1_000_000;

        /// <summary>
        ///     Constructor to create Karma with one digit.
        /// </summary>
        /// <param name="power">Defines the digit position of number.</param>
        /// <param name="number">Defines the value to be set at position of power.</param>
        public Karma(int power, long number)
        {
            for (int i = 0; i < power; i++)
            {
                this.Value.Add(0);
            }
            this.Value.Add(number);
        }

        /// <summary>
        ///     Constructor to create Karma with several digits.
        /// </summary>
        /// <param name="karma"></param>
        public Karma(IEnumerable<long> karma)
        {
            this.Value = CleanList(karma.ToList());
        }

        public List<long> Value { get; } = new List<long>();

        public static Karma operator +(Karma a, Karma b)
        {
            IEnumerable<(long, long)> longerListZip = a.Value.LongerListZip(b.Value);
            IEnumerable<long> zippedList = longerListZip.Select(t => t.Item1 + t.Item2);
            return new Karma(zippedList);
        }

        public static Karma operator *(int a, Karma b)
        {
            IEnumerable<long> multipliedList = b.Value.Select(n => n * a);
            return new Karma(multipliedList);
        }

        private static List<long> CleanList(IEnumerable<long> uncleanedList)
        {
            List<long> cleanedList = new List<long>();
            long carryover = 0;
            foreach (long number in uncleanedList)
            {
                long numberNow = number + carryover;
                long leftover = numberNow % Base;
                carryover = numberNow / Base;
                cleanedList.Add(leftover);
            }

            while (carryover != 0)
            {
                long leftover = carryover % Base;
                carryover /= Base;
                cleanedList.Add(leftover);
            }

            return cleanedList;
        }
    }
}