using System;

namespace QuickTests.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "a";
            long n = 1000000000000;

            //s = "aba";
            //n = 10;

            long result = RepeatedString.GetTotal(s, n);

            Console.WriteLine(result);
        }

    }
}
