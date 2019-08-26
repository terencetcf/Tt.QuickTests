using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickTests.ConsoleApp
{
    public static class MakeAnagram
    {
        public static long GetDeletedCharacters(string a, string b)
        {
            var listA = a.ToArray().ToList();
            var listB = b.ToArray().ToList();

            var noOfMatch = 0;
            var offset = 0;
            for (var i =0; i < b.Length - offset; i++)
            {
                var foundIndex = listA.IndexOf(listB[i]);
                if (foundIndex > -1)
                {
                    listB.RemoveAt(i);
                    listA.RemoveAt(foundIndex);
                    noOfMatch += 2;
                    offset++;
                    i--;
                }
            }

            
            return a.Length + b.Length - noOfMatch;

            //RemoveMatching(listA, listB, a.Length);
            //RemoveMatching(listB, listA, b.Length);


            //foreach (var itemA in a.ToArray())
            //{
            //    if (listB.Any(l => l == itemA))
            //    {
            //        var itemB = listB.First(l => l == itemA);
            //        listA.Remove(itemA);
            //        listB.Remove(itemB);
            //    }
            //}

            //foreach (var itemB in b.ToArray())
            //{
            //    if (listA.Any(l => l == itemB))
            //    {
            //        var itemA = listA.First(l => l == itemB);
            //        listB.Remove(itemB);
            //        listA.Remove(itemA);
            //    }
            //}

            //var result = listA.Count() + listB.Count();

            ////var matchesA = listA.Where(i => listB.Contains(i));
            ////var matchesb = listB.Where(i => listA.Contains(i));

            ////var result = listA.Count() - matchesb.Count()
            ////    + listB.Count() - matchesA.Count();

            //return result;
        }

        private static void RemoveMatching(List<char> listA, List<char> listB, int lengthOfA)
        {
            for (var i = 0; i < lengthOfA; i++)
            {
                if (listB.Any(l => l == listA[i]))
                {
                    var itemB = listB.IndexOf(listA[i]);
                    listA.Remove(listA[i]);
                    listB.RemoveAt(itemB);
                }
            }
        }
    }
}
