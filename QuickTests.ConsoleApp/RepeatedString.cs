using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickTests.ConsoleApp
{
    public static class RepeatedString
    {
        private static int CountChars(string s)
        {
            return s.ToArray().Where(i => i == 'a').Count();
        }

        public static long GetTotal(string s, long n)
        {
            if (s == null || s.Length < 1 || s.Length > 100 || n < 1 || n > Math.Pow(10, 12))
            {
                throw new InvalidOperationException();
            }

            long toRepeatTimes = n / s.Length;
            var remaining = (int)(n - (s.Length * toRepeatTimes));

            return toRepeatTimes * CountChars(s) + CountChars(s.Substring(0, remaining));
        }
    }
}
