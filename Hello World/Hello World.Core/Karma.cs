using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace Hello_World.Core
{
    [DebuggerDisplay("{" + nameof(PrettyPrint) + "}")]
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
            for (int i = 0; i < power; i++) this.Value.Add(0);
            this.Value.Add(number);
        }

        public string PrettyPrint => string.Join(", ", this.Value.Select(v => v.ToString("0")));

        /// <summary>
        ///     Constructor to create Karma with several digits.
        /// </summary>
        /// <param name="karma"></param>
        public Karma(IEnumerable<long> karma)
        {
            this.Value = CleanList(karma.ToList());
        }
        
        public List<long> Value { get; } = new List<long>();

        private bool Equals(Karma other)
        {
            return Equals(this.Value, other.Value);
        }
        
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == this.GetType() && this.Equals((Karma) obj);
        }

        public override int GetHashCode()
        {
            return this.Value != null ? this.Value.GetHashCode() : 0;
        }
        
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

        public static Karma operator -(Karma a, Karma b)
        {
            IEnumerable<(long, long)> longerListZip = a.Value.LongerListZip(b.Value);
            IEnumerable<long> zippedList = longerListZip.Select(t => t.Item1 - t.Item2);
            return new Karma(zippedList);
        }

        public static bool operator >(Karma a, Karma b)
        {
            IEnumerable<(long, long)> longerListZip = a.Value.LongerListZip(b.Value);
            IEnumerable<long> zippedList = longerListZip.Select(t => t.Item1 - t.Item2);

            return zippedList.Reverse().Any(l => l ! > 0);
        }

        public static bool operator <(Karma a, Karma b)
        {
            IEnumerable<(long, long)> longerListZip = b.Value.LongerListZip(a.Value);
            IEnumerable<long> zippedList = longerListZip.Select(t => t.Item1 - t.Item2);

            return zippedList.Reverse().All(l => (l !> 0));
        }
    
        public static bool operator >=(Karma a, Karma b)
        {
            return a.Equals(b) || a > b;
        }

        public static bool operator <=(Karma a, Karma b)
        {
            return a.Equals(b) || a > b;
        }

        private static List<long> CleanList(IEnumerable<long> uncleanedList)
        {
            List<long> cleanedList = new List<long>();
            List<long> minusCleanedList = new List<long>();
            long carryover = 0;
            bool wasMinus = false;

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

            foreach (long number in cleanedList)
            {
                long numberNow = number;
                if (wasMinus)
                {
                    numberNow -= 1;
                }
                if (number < 0)
                {
                    minusCleanedList.Add(Base + numberNow);
                    wasMinus = true;    
                }
                else
                {
                    minusCleanedList.Add(numberNow);
                    wasMinus = false;
                }
            }

            if (wasMinus)
            {
                minusCleanedList.Add(-1);
            }

            return minusCleanedList;
        }
    }
}