using System;
using System.Linq;

namespace QuickTests.ConsoleApp
{
    public static class HourGlassSum
    {
        public static int GetHighestSum(int[][] arr)
        {
            if (!IsValid2dArray(arr, -9, 9))
            {
                throw new InvalidOperationException();
            }

            int? result = null;
            for (var row = 0; row < arr.Length - 2; row++)
            {
                for (var col = 0; col < arr[row].Length - 2; col++)
                {
                    var sum = 0;
                    sum += arr[row][col];
                    sum += arr[row][col + 1];
                    sum += arr[row][col + 2];
                    sum += arr[row + 1][col + 1];
                    sum += arr[row + 2][col];
                    sum += arr[row + 2][col + 1];
                    sum += arr[row + 2][col + 2];
                    result = result.HasValue && result > sum ?  result : sum;
                }
            }

            return result ?? 0;
        }

        private static bool IsValid2dArray(int[][] numbers, int min, int max)
        {
            if (numbers.Length < 6 || numbers.Length > 6)
            {
                return false;
            }

            foreach (var row in numbers)
            {
                if (row.Length < 6 || row.Length > 6)
                {
                    return false;
                }

                if (row.Any(r => r < min || r > max))
                {
                    return false;

                }
            }

            return true;
        }
    }

}
